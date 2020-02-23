//
// Copyright 2010, 2016, 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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

namespace Carbonfrost.Commons.Validation {

    public class ValidationError : IEquatable<ValidationError> {

        private readonly string _key;
        private readonly string _message;
        private readonly string _validator;

        // Key represents the unique name for the object (i.e. "Customer.FirstName")
        // Validator represents the validation error (i.e. "Required")

        public string Key {
            get {
                return _key;
            }
        }

        public string Message {
            get {
                return _message;
            }
        }

        public string Validator {
            get {
                return _validator;
            }
        }

        public ValidationError(string key, string message, string validator) {
            _key = key ?? string.Empty;
            _message = message ?? string.Empty;
            _validator = validator;
        }

        public Exception ToException() {
            return new ValidationException(Key, Validator, Message);
        }

        public override string ToString() {
            return string.Format("{1} ({0})", Key, Message);
        }

        public override bool Equals(object obj) {
            ValidationError other = obj as ValidationError;
            return StaticEquals(this, other);
        }

        public override int GetHashCode() {
            int hashCode = 0;
            unchecked {
                hashCode += 7 * _key.GetHashCode();
                hashCode += 9 * _message.GetHashCode();
                hashCode += 33 * _validator.GetHashCode();
            }
            return hashCode;
        }

        static bool StaticEquals(ValidationError lhs, ValidationError rhs) {
            if (ReferenceEquals(lhs, rhs)) {
                return true;
            }
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) {
                return false;
            }

            return lhs.Equals(rhs);
        }

        public bool Equals(ValidationError other) {
            if (other == null)
                return false;

            return _key == other._key
                && _message == other._message
                && _validator == other._validator;
        }
    }

}
