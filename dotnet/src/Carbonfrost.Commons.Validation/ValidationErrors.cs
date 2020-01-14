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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Carbonfrost.Commons.Core;
using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation {

    public class ValidationErrors : IDictionary<string, ValidationError>, IList<ValidationError>, ICollection {

        private readonly IList<ValidationError> list = new List<ValidationError>();
        private IDictionary<string, ValidationError> dict;

        // Properties.
        private IDictionary<string, ValidationError> Dictionary {
            get {
                if (dict == null) {
                    dict = new Dictionary<string, ValidationError>();
                    foreach (ValidationError vr in list)
                        dict.Add(vr.Key, vr);
                }
                return dict;
            }
        }

        public bool IsValid {
            get {
                return 0 == this.Count;
            }
        }

        // Constructors
        public ValidationErrors() {
        }

        public void Valid() {
            if (!IsValid) {
                throw Exception;
            }
        }

        public override string ToString() {
            return string.Join(Environment.NewLine, this.list);
        }

        // `IList<ValidationResult>' implementation
        public ValidationError this[int index] {
            get { return list[index]; }
            set { throw ValidationFailure.ValidationResultsCannotRemove(); }
        }

        public int IndexOf(ValidationError item) {
            return list.IndexOf(item);
        }

        void IList<ValidationError>.Insert(int index, ValidationError item) {
            throw Failure.ReadOnlyCollection();
        }

        void IList<ValidationError>.RemoveAt(int index) {
            throw Failure.ReadOnlyCollection();
        }

        // `ICollection<ValidationResult>' overrides.

        public void Add(ValidationError item) {
            this.list.Add(item);
            if (dict != null)
                dict.Add(item.Key, item);
        }

        void ICollection<ValidationError>.Clear() {
            throw ValidationFailure.ValidationResultsCannotRemove();
        }

        public bool Contains(ValidationError item) {
            if (dict != null)
                return dict.ContainsKey(item.Key);
            return this.list.Contains(item);
        }

        public void CopyTo(ValidationError[] array, int arrayIndex) {
            list.CopyTo(array, arrayIndex);
        }

        bool ICollection<ValidationError>.Remove(ValidationError item) {
            throw ValidationFailure.ValidationResultsCannotRemove();
        }

        public IEnumerator<ValidationError> GetEnumerator() {
            return this.list.GetEnumerator();
        }

        // `ICollection' overrides.
        object ICollection.SyncRoot { get { return null; } }
        bool ICollection.IsSynchronized { get { return false; } }
        void ICollection.CopyTo(Array array, int index) { ((ICollection) list).CopyTo(array, index); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        // 'IDictionary' implementation.
        public ValidationError this[string key] {
            get {
                if (this.dict != null || this.list.Count > 8)
                    return Dictionary[key];
                foreach (ValidationError vr in list) {
                    if (_CompareKeys(vr.Key, key)) return vr;
                }
                throw new KeyNotFoundException();
            }
            set {
                throw ValidationFailure.ValidationResultsCannotRemove();
            }
        }

        ICollection<string> IDictionary<string, ValidationError>.Keys { get { return this.Dictionary.Keys; } }
        ICollection<ValidationError> IDictionary<string, ValidationError>.Values { get { return this.list; } }

        public int Count { get { return list.Count; } }
        bool ICollection<ValidationError>.IsReadOnly { get { return false; } }
        bool ICollection<KeyValuePair<string, ValidationError>>.IsReadOnly { get { return false; } }

        bool IDictionary<string, ValidationError>.ContainsKey(string key) {
            return Dictionary.ContainsKey(key);
        }

        void IDictionary<string, ValidationError>.Add(string key, ValidationError value) {
            throw new NotSupportedException();
        }

        bool IDictionary<string, ValidationError>.Remove(string key) {
            throw ValidationFailure.ValidationResultsCannotRemove();
        }

        bool IDictionary<string, ValidationError>.TryGetValue(string key, out ValidationError value) {
            return this.Dictionary.TryGetValue(key, out value);
        }
        void ICollection<KeyValuePair<string, ValidationError>>.Add(KeyValuePair<string, ValidationError> item) {
            if (_CompareKeys(item.Key, item.Value.Key))
                Add(item.Value);
        }

        void ICollection<KeyValuePair<string, ValidationError>>.Clear() {
            throw ValidationFailure.ValidationResultsCannotRemove();
        }

        bool ICollection<KeyValuePair<string, ValidationError>>.Contains(KeyValuePair<string, ValidationError> item) {
            return Dictionary.Contains(item);
        }

        void ICollection<KeyValuePair<string, ValidationError>>.CopyTo(KeyValuePair<string, ValidationError>[] array, int arrayIndex) {
            this.Dictionary.CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, ValidationError>>.Remove(KeyValuePair<string, ValidationError> item) {
            throw ValidationFailure.ValidationResultsCannotRemove();
        }

        IEnumerator<KeyValuePair<string, ValidationError>> IEnumerable<KeyValuePair<string, ValidationError>>.GetEnumerator() {
            return Dictionary.GetEnumerator();
        }

        private static bool _CompareKeys(string a, string b) {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }

        // IStatus implementation
        public Exception Exception {
            get {
                if (this.list.Count == 0)
                    return null;

                StringBuilder message = new StringBuilder(SR.ValidationErrorsOccurred());

                // TODO NLS implementation
                foreach (var t in this.list.GroupBy(u => u.Key)) {
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
        }

        // public FileLocation FileLocation {
        //     get {
        //         var leader = this.list.FirstOrDefault();
        //         if (leader == null)
        //             return FileLocation.Empty;
        //         else
        //             return leader.FileLocation;
        //     }
        // }

        // Severity IStatus.Level {
        //     get { return Severity.Error; } }

        public string Message {
            get {
                var leader = this.list.FirstOrDefault();
                if (leader == null)
                    return string.Empty;
                else
                    return leader.Message;
            }
        }

        // Component IStatus.Component {
        //     get { return typeof(ValidationError).GetTypeInfo().Assembly.AsComponent(); }
        // }

        public int ErrorCode {
            get {
                var leader = this.list.FirstOrDefault();
                if (leader == null)
                    return 0;
                else
                    return leader.ErrorCode;
            }
        }

        // ReadOnlyCollection<IStatus> IStatus.Children {
        //     get {
        //         return new ReadOnlyCollection<IStatus>(this.Dictionary.Values.ToArray());
        //     }
        // }

        // public bool Equals(IStatus other) {
        //     if (other == null)
        //         return false;
        //     ValidationErrors e = other as ValidationErrors;
        //     if (e == null)
        //         return false;

        //     if (e.Count == this.Count)
        //         return true;
        //     else
        //         return false;
        // }

    }
}
