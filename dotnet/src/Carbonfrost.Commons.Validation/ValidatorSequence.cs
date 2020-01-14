//
// Copyright 2010 Carbonfrost Systems, Inc. (http://carbonfrost.com)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Carbonfrost.Commons.Validation {

    public class ValidatorSequence : Validator {

        private readonly List<Validator> validators;

        public ValidatorSequenceKind Kind { get; set; }
        public IList<Validator> Validators { get { return validators; } }

        public ValidatorSequence() {
            this.validators = new List<Validator>();
        }

        internal ValidatorSequence(int capacity) {
            this.validators = new List<Validator>(capacity);
        }

        public ValidatorSequence Clone() {
            return Clone(false);
        }

        public ValidatorSequence Clone(bool deep) {
            ValidatorSequence vs = new ValidatorSequence();
            vs.Kind = this.Kind;

            if (deep) {
                foreach (Validator v in this.validators)
                    vs.validators.Add(_TryClone(v));
            } else
                vs.validators.AddRange(this.validators);

            return vs;
        }

        protected virtual bool ValidateOverride(
            Validator childValidator,
            object target,
            ValidationErrors targetErrors)  {

            if (childValidator == null)
                throw new ArgumentNullException("childValidator"); // $NON-NLS-1

            if (targetErrors == null)
                throw new ArgumentNullException("targetErrors"); // $NON-NLS-1

            return childValidator.Validate(target, targetErrors);
        }

        // `Validator' overrides.
        public override string Name {
            get { return ValidatorNames.Sequence; } } // $NON-NLS-1

        public sealed override bool Validate(object target, ValidationErrors targetErrors) {
            if (targetErrors == null)
                throw new ArgumentNullException("targetErrors"); // $NON-NLS-1

            // If we are looking for any, then we only expose the results of the one that worked
            Func<Validator, bool> predicate = t => ValidateOverride(t, target, targetErrors);
            if (this.Kind == ValidatorSequenceKind.All)
                return this.Validators.All(predicate);
            else
                return this.Validators.Any(predicate);
        }

        private static Validator _TryClone(Validator v) {
            return Utility.TryClone(v);
        }
    }
}
