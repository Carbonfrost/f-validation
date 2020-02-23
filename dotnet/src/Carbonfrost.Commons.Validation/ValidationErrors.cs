//
// Copyright 2020 Carbonfrost Systems, Inc. (http://carbonfrost.com)
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
using System.Linq;
using System.Text;
using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation {

    public class ValidationErrors : IReadOnlyDictionary<string, ValidationError>, IReadOnlyList<ValidationError>, ICollection {

        private readonly IList<ValidationError> _items;
        private IDictionary<string, ValidationError> _dict;

        public static readonly ValidationErrors Empty
            = new ValidationErrors(Enumerable.Empty<ValidationError>());

        public static readonly ValidationErrors None = Empty;

        public bool IsEmpty {
            get {
                return 0 == Count;
            }
        }

        private IList<ValidationError> Items {
            get {
                return _items;
            }
        }

        public ValidationErrors(ValidationError item) {
            if (item == null) {
                throw new ArgumentNullException(nameof(item));
            }
            _items = new List<ValidationError> { item };
        }

        public ValidationErrors(params ValidationError[] items)
            : this((IEnumerable<ValidationError>) items) {
        }

        public ValidationErrors(IEnumerable<ValidationError> items) {
            if (items == null) {
                throw new ArgumentNullException(nameof(items));
            }
            _items = new List<ValidationError>(items);
        }

        internal static ValidationErrors Flatten(IEnumerable<ValidationErrors> result) {
            return new ValidationErrors(
                result.SelectMany(vr => (IEnumerable<ValidationError>) vr)
            );
        }

        public void Valid() {
            if (IsEmpty) {
                return;
            }

            throw ToException();
        }

        private IDictionary<string, ValidationError> Dictionary {
            get {
                if (_dict == null) {
                    _dict = _items.ToDictionary(vr => vr.Key, vr => vr);
                }
                return _dict;
            }
        }

        public ValidationException ToException() {
            if (Items.Count == 0) {
                return null;
            }
            StringBuilder message = new StringBuilder(SR.ValidationErrorsOccurred());
            // TODO NLS implementation
            foreach (var t in Items.GroupBy(u => u.Key)) {
                message.AppendLine();
                message.Append(t.Key);
                message.Append(": ");
                foreach (var v in t) {
                    message.Append(v.Message);
                    message.Append(" ");
                }
            }
            return new ValidationException(message.ToString());
        }

        public override string ToString() {
            return string.Join(Environment.NewLine, _items);
        }

        public ValidationError this[string key] {
            get {
                return Dictionary[key];
            }
        }

        public ValidationError this[int index] {
            get {
                return _items[index];
            }
        }

        public IEnumerable<string> Keys {
            get {
                return Dictionary.Keys;
            }
        }

        public IEnumerable<ValidationError> Values {
            get {
                return _items;
            }
        }

        public int Count {
            get {
                return _items.Count;
            }
        }

        bool ICollection.IsSynchronized {
            get {
                return false;
            }
        }

        object ICollection.SyncRoot {
            get {
                return null;
            }
        }

        public bool ContainsKey(string key) {
            return Dictionary.ContainsKey(key);
        }

        void ICollection.CopyTo(Array array, int index) {
            ((ICollection) _items).CopyTo(array, index);
        }

        public void CopyTo(ValidationError[] array, int arrayIndex) {
            _items.CopyTo(array, arrayIndex);
        }

        IEnumerator<KeyValuePair<string, ValidationError>> IEnumerable<KeyValuePair<string, ValidationError>>.GetEnumerator() {
            return Dictionary.GetEnumerator();
        }

        public bool TryGetValue(string key, out ValidationError value) {
            return Dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<ValidationError> GetEnumerator() {
            return _items.GetEnumerator();
        }
    }
}
