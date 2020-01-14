//
// Copyright 2010, 2020 Carbonfrost Systems, Inc. (http://carbonfrost.com)
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
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(AbstractValidatorAttribute.COMMON_TARGETS,
                    AllowMultiple = true, Inherited = true)]
    public sealed class ValidatorAttribute : AbstractValidatorAttribute {

        private readonly Type _validatorType;

        public string Properties {
            get;
            set;
        }

        public Type ValidatorType {
            get {
                return _validatorType;
            }
        }

        public ValidatorAttribute(string validatorType) {
            _validatorType = Type.GetType(validatorType, true, false);
        }

        public ValidatorAttribute(Type validatorType) {
            if (validatorType == null)
                throw new ArgumentNullException("validatorType"); // $NON-NLS-1
            _validatorType = validatorType;
        }

        protected override Validator CreateValidatorCore() {
            Validator result = Activation.CreateInstance<Validator>(ValidatorType);
            Activation.Initialize(result, ParseProperties(Properties), null);

            // UNDONE It is possible that there are properties specified that don't exist
            // e.g throw ValidationFailure.CannotUseMissingOrErrorProperties(string.Join(", ", badProperties.ToArray()));

            return result;
        }

        private static IEnumerable<KeyValuePair<string, object>> ParseProperties(string props) {
            return Carbonfrost.Commons.Core.Runtime.Properties.Parse(props);
        }
    }
}
