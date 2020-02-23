//
// Copyright 2010, 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Carbonfrost.Commons.Validation.Validators {

    public abstract class ValueValidator : Validator {

        public virtual string Name {
            get {
                return Utility.GetValidatorName(this);
            }
        }

        public sealed override ValidationErrors Validate(object target) {
            if (!IsValid(target)) {
                return new ValidationErrors(
                    new ValidationError(Key, FailureMessage, Name)
                );
            }

            return ValidationErrors.None;
        }

        public abstract bool IsValid(object value);

    }
}
