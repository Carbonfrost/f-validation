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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    static class Utility {

        public static IEnumerable<object> Enumerable(this object any) {
            IEnumerable e = any as IEnumerable;
            if (e == null) {
                return new [] { any };

            } else {
                return e.Cast<object>();
            }
        }

        internal static string GetValidatorName(Validator val) {
            var qn = App.GetProviderName(typeof(Validator), val);
            if (qn == null) {
                return val.GetType().Name;
            }
            return qn.LocalName;
        }
    }
}
