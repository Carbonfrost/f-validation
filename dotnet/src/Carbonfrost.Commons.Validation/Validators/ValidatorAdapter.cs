//
// - ValidatorAdapter.cs -
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

namespace Carbonfrost.Commons.Validation.Validators {

    public abstract class ValidatorAdapter : Validator {

        private readonly Validator baseValidator;

        public Validator BaseValidator { get { return baseValidator; } }

        protected ValidatorAdapter(Validator validator) {
            if (validator == null)
                throw new ArgumentNullException("validator"); // $NON-NLS-1

            this.baseValidator = validator;
        }

        public override bool Validate(object target, ValidationErrors targetErrors) {
            string message = null;
            object value = GetValueForValidation(target, out message);

            // UNDONE Implement inner validation - need the key to use
            if (message == null) {
                // this.InnerValidator.Validate(value);
                ValidationError s = new ValidationError(
                    "<unknown>",
                    message,
                    this.Name,
                    1);

            } else {
                ValidationError s = new ValidationError(
                    "<unknown>",
                    FormatFailureMessage(),
                    this.Name,
                    1);
            }

            throw new NotImplementedException();
        }

        protected abstract object GetValueForValidation(
            object target, out string accessFailureMessage);

        // TODO Maybe a better tag name here?
        public override string Name {
            get { return baseValidator.Name; } }

    }
}
