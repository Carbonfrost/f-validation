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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Carbonfrost.UnitTests.Validation {

    class PDictionaryWithNull : IDictionary<object, object> {

        public object this[object key] {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ICollection<object> Keys {
            get {
                return null;
            }
        }

        public ICollection<object> Values {
            get {
                return null;
            }
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(object key, object value) {}
        public void Add(KeyValuePair<object, object> item) {}
        public void Clear() {}
        public bool Contains(KeyValuePair<object, object> item) { return false; }
        public bool ContainsKey(object key) { return false; }
        public void CopyTo(KeyValuePair<object, object>[] array, int arrayIndex) {}

        public IEnumerator<KeyValuePair<object, object>> GetEnumerator() {
            throw new NotImplementedException();
        }

        public bool Remove(object key) {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<object, object> item) {
            throw new NotImplementedException();
        }

        public bool TryGetValue(object key, [MaybeNullWhen(false)] out object value) {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

}
