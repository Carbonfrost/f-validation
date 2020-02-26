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

using System.Collections;

namespace Carbonfrost.Commons.Validation {

    static class ReflectionHelper {

        public static IEnumerable GetDictionaryValues(object target) {
            var type = target.GetType();

            var iface = type.GetInterface("System.Collections.Generic.IDictionary`2");
            if (iface == null) {
                throw ValidationFailure.DictionaryTypeRequired();
            }

            var map = type.GetInterfaceMap(iface);
            for (int i = 0; i < map.InterfaceMethods.Length; i++) {
                if (map.InterfaceMethods[i].Name == "get_Values") {
                    return (IEnumerable) map.TargetMethods[i].Invoke(target, null);
                }
            }

            return null;
        }

        public static IEnumerable GetDictionaryKeys(object target) {
            var type = target.GetType();

            var iface = type.GetInterface("System.Collections.Generic.IDictionary`2");
            if (iface == null) {
                throw ValidationFailure.DictionaryTypeRequired();
            }

            var map = type.GetInterfaceMap(iface);
            for (int i = 0; i < map.InterfaceMethods.Length; i++) {
                if (map.InterfaceMethods[i].Name == "get_Keys") {
                    return (IEnumerable) map.TargetMethods[i].Invoke(target, null);
                }
            }

            return null;
        }
    }
}
