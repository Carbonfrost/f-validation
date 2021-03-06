//
// Copyright 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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

using System;
using System.Linq;

namespace Carbonfrost.Commons.Validation.Validators {

    internal sealed class EachValueValidatorAdapter : Validator {

        private readonly Validator _baseValidator;

        public EachValueValidatorAdapter(Validator validator) {
            if (validator == null) {
                throw new ArgumentNullException(nameof(validator));
            }

            _baseValidator = validator;
        }

        public override ValidationErrors Validate(object target) {
            if (target == null) {
                return ValidationErrors.None;
            }

            var values = ReflectionHelper.GetDictionaryValues(target);
            return ValidationErrors.Flatten(
                values.Cast<object>().Select(v => _baseValidator.Validate(v))
            );
        }
    }
}
