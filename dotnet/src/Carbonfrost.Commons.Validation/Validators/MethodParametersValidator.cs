//
// - MethodParametersValidator.cs -
//
// Copyright 2012 Carbonfrost Systems, Inc. (http://carbonfrost.com)
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

using System.Linq;
using System.Reflection;

namespace Carbonfrost.Commons.Validation.Validators {

    sealed class MethodParametersValidator : Validator {

        private readonly MethodBase method;
        private readonly Validator[] validators;

        public MethodParametersValidator(MethodBase method) {
            this.method = method;
            this.validators = this.method.GetParameters().Select(p => Create(p)).ToArray();
        }

        static ValidatorSequence Create(ParameterInfo pi) {
            var validatorAttributes = pi.GetCustomAttributes(typeof(AbstractValidatorAttribute), false).ToArray();
            ValidatorSequence validatorSequence = new ValidatorSequence(validatorAttributes.Length);

            foreach (AbstractValidatorAttribute ava in validatorAttributes)
                validatorSequence.Validators.Add(ava.CreateValidator(pi.Name));

            return validatorSequence;
        }

        public override bool Validate(object target,
                                      ValidationErrors targetErrors) {
            int index = 0;
            foreach (var o in target.Enumerable()) {
                Validator v = validators[index++];
                v.Validate(o, targetErrors);
            }

           return true;
        }

        public override string Name {
            get { return "parameters"; }
        }
    }
}
