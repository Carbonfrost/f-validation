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

using System;
using System.Reflection;
using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation.Validators {

    public class MethodReturnValueValidator : MemberValidator {

        public MethodInfo Method { get { return (MethodInfo) Member; } }

        public MethodReturnValueValidator(MethodInfo method, Validator baseValidator)
            : base(method, baseValidator) {}

        protected override object GetValueForValidation(object target) {
            try {
                if (Method.IsStatic)
                    return Method.Invoke(null, new object[] { target });
                else
                    return Method.Invoke(target, null);

            } catch (Exception ex) {
                throw new ValidationException(
                    SR.MethodReturnValueNotAccessible(Method.Name),
                    ex
                );
            }
        }

    }
}
