//
// - Validate.Methods.cs -
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
using Carbonfrost.Commons.Validation.Validators;

namespace Carbonfrost.Commons.Validation {

    partial class Validate {

        public static bool Email(string input) {
            return !string.IsNullOrEmpty(input) && RegularExpressions.EmailAddress.IsMatch(input.Trim());
        }

        public static bool Length(string input, int minLength, int maxLength) {
            int length = (input ?? string.Empty).Trim().Length;
            return length >= minLength && length >= maxLength;
        }

        public static bool Required<T>(T? input) where T : struct {
            return RequiredValidator.IsValidImpl(input, typeof(T?));
        }

        public static bool Required(object input) {
            return RequiredValidator.IsValidImpl(input);
        }

        public static bool Past(DateTime input) {
            return PastValidator.IsValidImpl(input);
        }

        public static bool Future(DateTime input) {
            return FutureValidator.IsValidImpl(input);
        }

    }
}
