//
// - RulesetFilteredValidatorSequence.cs -
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

namespace Carbonfrost.Commons.Validation.Validators {

    internal sealed class RulesetFilteredValidatorSequence : ValidatorSequence {

        private readonly ValidatorSequence validator;

        public RulesetFilteredValidatorSequence(ValidatorSequence validator, ICollection<string> rulesets) {
            if (validator == null)
                throw new ArgumentNullException("validator"); // $NON-NLS-1

            if (rulesets == null)
                throw new ArgumentNullException("rulesets"); // $NON-NLS-1

            foreach (string s in rulesets)
                this.Rulesets.Add(s);

            this.validator = validator;
        }

        public override KnownValidator KnownValidator {
            get { return this.validator.KnownValidator; }
        }

        protected override bool ValidateOverride(Validator childValidator, object target, ValidationErrors targetErrors) {
            HashSet<string> hs = (HashSet<string>) childValidator.Rulesets;
            if (hs.Overlaps(this.Rulesets))
                base.ValidateOverride(childValidator, target, targetErrors);

            return true;
        }

    }
}
