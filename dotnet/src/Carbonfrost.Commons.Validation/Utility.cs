//
// - Utility.cs -
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Carbonfrost.Commons.Core;
using Carbonfrost.Commons.Core.Runtime;
using Carbonfrost.Commons.Validation;
using Carbonfrost.Commons.Validation.Validators;

namespace Carbonfrost.Commons.Validation {

    static class Utility {

        public static string GetDefaultFailureMessage(Validator v) {
            // UNDONE Messages for failure:
            // <tag>.required
            // <tag>.required.negated
            throw new NotImplementedException();
        }

        public static IEnumerable<object> Enumerable(this object any) {
            IEnumerable e = any as IEnumerable;
            if (e == null) {
                return new [] { any };

            } else {
                return e.Cast<object>();
            }
        }

        public static T TryClone<T>(T instance) where T : class {
            return (T) Template.Copy(instance);
        }
    }
}
