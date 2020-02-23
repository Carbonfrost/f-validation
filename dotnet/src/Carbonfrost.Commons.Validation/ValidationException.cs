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

using System;
using System.Runtime.Serialization;

namespace System.Runtime.Serialization {}

namespace Carbonfrost.Commons.Validation {

    public class ValidationException : Exception {

        public string Key {
            get;
            private set;
        }

        public string Validator {
            get;
            private set;
        }

        public ValidationException() {}
        public ValidationException(string message) : base(message) {}

        public ValidationException(string key, string validator, string message) : base(message) {
            Validator = validator;
            Key = key;
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException) {}

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) {
            if (info != null) {
                Validator = info.GetString("validator");
                Key = info.GetString("key");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            if (info != null) {
                info.AddValue("validator", Validator);
                info.AddValue("key", Key);
            }

            base.GetObjectData(info, context);
        }
    }
}
