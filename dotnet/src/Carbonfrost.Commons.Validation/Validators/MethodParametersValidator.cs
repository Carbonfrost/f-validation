//
// Copyright 2012, 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Carbonfrost.Commons.Validation.Validators {

    sealed class MethodParametersValidator : Validator {

        private readonly MethodBase _method;
        private readonly Validator[] _validators;

        public MethodParametersValidator(MethodBase method) {
            _method = method;
            _validators = _method.GetParameters().Select(p => Create(p)).ToArray();
        }

        static ValidatorSequence Create(ParameterInfo pi) {
            var attrs = pi.GetCustomAttributes<ValidatorAttribute>();
            return ValidatorSequence.All(
                attrs.Select(ava => ava.CreateValidator(pi.Name))
            );
        }

        public override ValidationErrors Validate(object target) {
            int index = 0;
            var result = new List<ValidationErrors>();
            foreach (var o in target.Enumerable()) {
                Validator v = _validators[index++];
                result.Add(v.Validate(o));
            }

           return ValidationErrors.Flatten(result);
        }
    }
}
