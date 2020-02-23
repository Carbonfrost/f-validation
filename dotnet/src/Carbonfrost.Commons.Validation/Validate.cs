//
// Copyright 2010, 2012, 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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
using System.Diagnostics;
using System.Reflection;
using Carbonfrost.Commons.Validation.Validators;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    public static partial class Validate {

        public static ValidationErrors Arguments(params object[] values) {
            var method = new StackFrame(1, false).GetMethod();
            return Arguments(method, values);
        }

        public static ValidationErrors Arguments(MethodBase method, params object[] values) {
            if (method == null) {
                throw new ArgumentNullException(nameof(method));
            }
            if (values == null) {
                throw new ArgumentNullException(nameof(values));
            }
            return new MethodParametersValidator(method).Validate(values);
        }

        public static ValidationErrors Value(object target) {
            if (target == null) {
                throw new ArgumentNullException("target");
            }

            // Self validation should be tried first; then the validator should be created
            ISelfValidation sv = target.Adapt<ISelfValidation>();
            if (sv != null) {
                return sv.Validate();
            }

            Validator v = Validator.CreateSelfValidator(target.GetType());
            if (v != null)
                return v.Validate(target);

            v = Validator.Create(target.GetType());
            if (v != null)
                return v.Validate(target);

            throw ValidationFailure.ValidationNotDefined();
        }

    }
}
