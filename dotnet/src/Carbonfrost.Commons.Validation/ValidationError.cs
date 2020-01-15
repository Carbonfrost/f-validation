//
// Copyright 2010, 2016 Carbonfrost Systems, Inc. (http://carbonfrost.com)
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
using System.Reflection;

using Carbonfrost.Commons.Core;

namespace Carbonfrost.Commons.Validation {

    public class ValidationError : IEquatable<ValidationError> {

        private readonly string key;
        private readonly string message;
        private readonly string validator;
        private readonly int errorCode;

        // Key represents the unique name for the object (i.e. "Customer.FirstName")
        // Validator represents the validation error (i.e. "Required")

        public string Key { get { return key; } }
        public string Message { get { return message; } }
        public string Validator { get { return validator; } }

        public ValidationError(
            string key, string message, string validator)
            : this(key, message, validator, 1)
        {
        }

        public ValidationError(
            string key,
            string message,
            string validator,
            int errorCode)
        {
            if (key == null) {
                throw Failure.Null("key");
            }
            if (string.IsNullOrEmpty(key)) {
                throw Failure.EmptyString("key");
            }

            this.key = key ?? string.Empty;
            this.message = message ?? string.Empty;
            this.validator = validator;
            this.errorCode = errorCode;
        }

        public string GetLocalizedMessage() {
            // validation.validationError.email.negated
            throw new NotImplementedException();
            // TODO Support the localized message
        }

        // IStatus implementation
        // ReadOnlyCollection<IStatus> IStatus.Children {
        //     get {
        //         return Empty<IStatus>.ReadOnly;
        //     }
        // }

        public Exception Exception {
            get { return new ValidationException(this.Key, this.Validator, this.ErrorCode, this.Message); } }

        // public FileLocation FileLocation {
        //     get {
        //         throw new NotImplementedException();
        //     }
        // }

        public override string ToString() {
            return string.Format("{1} ({0})", key, message);
        }

        // // N.B. Always considered errors; always related to this component
        // Severity IStatus.Level {
        //     get { return Severity.Error; } }

        // Component IStatus.Component {
        //     get { return typeof(ValidationError).GetTypeInfo().Assembly.AsComponent(); }
        // }

        public int ErrorCode {
            get {
                return this.errorCode;
            }
        }

        // public bool Equals(IStatus other) {
        //     return StaticEquals(this, other as ValidationError);
        // }

        public override bool Equals(object obj) {
            ValidationError other = obj as ValidationError;
            return StaticEquals(this, other);
        }

        public override int GetHashCode() {
            int hashCode = 0;
            unchecked {
                hashCode += 7 * key.GetHashCode();
                hashCode += 9 * message.GetHashCode();
                hashCode += 33 * validator.GetHashCode();
                hashCode += 87 * errorCode.GetHashCode();
            }
            return hashCode;
        }

        static bool StaticEquals(ValidationError lhs, ValidationError rhs) {
            if (ReferenceEquals(lhs, rhs))
                return true;
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                return false;

            return lhs.Equals(rhs);
        }

        public bool Equals(ValidationError other) {
            if (other == null)
                return false;

            return this.key == other.key
                && this.message == other.message
                && this.validator == other.validator
                && this.errorCode == other.errorCode;
        }
    }

}
