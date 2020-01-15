//
// - Validate.cs -
//
// Copyright 2010, 2012 Carbonfrost Systems, Inc. (http://carbonfrost.com)
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using Carbonfrost.Commons.Core;
using Carbonfrost.Commons.Validation.Validators;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    public static partial class Validate {

#if NET
        public static ValidationErrors Arguments(params object[] values) {
            var method = new StackFrame(1, false).GetMethod();
            return Arguments(method, values);
        }
#endif

        public static ValidationErrors Arguments(MethodBase method, params object[] values) {
            if (method == null)
                throw new ArgumentNullException("method");
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length == 0)
                throw Failure.EmptyCollection();

            return new MethodParametersValidator(method).Validate(values);
        }

        public static ValidationErrors Value(object target) {
            if (target == null)
                throw new ArgumentNullException("target"); // $NON-NLS-1

            ISelfValidation sv = target.Adapt<ISelfValidation>();
            if (sv != null) {
                ValidationErrors result = new ValidationErrors();
                sv.Validate(result);
                return result;
            }

            return Validator.Create(target.GetType()).Validate(target);
        }

        public static ValidationErrors Value(object target, params string[] rulesets) {
            if (target == null)
                throw new ArgumentNullException("target"); // $NON-NLS-1

            // Self validation should be tried first; then the validator should be created
            ISelfValidation sv = target.Adapt<ISelfValidation>();
            if (sv != null) {
                ValidationErrors results = new ValidationErrors();
                sv.Validate(results);
                return results;
            }

            Validator v = Validator.CreateSelfValidator(target.GetType());
            if (v != null)
                return v.Validate(target);

            v = Validator.Create(target.GetType(), rulesets);
            if (v != null)
                return v.Validate(target);

            throw ValidationFailure.ValidationNotDefined();
        }

    }
}
