//
// - ValidationFailure.cs -
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
using Carbonfrost.Commons.Core;
using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation {

    static class ValidationFailure {

        public static NotSupportedException DictionaryTypeRequired() {
            return Failure.Prepare(new NotSupportedException(SR.NotDictionaryType()));
        }

        public static InvalidOperationException ValidationNotDefined() {
            return Failure.Prepare(new InvalidOperationException(SR.ValidationNotDefined()));
        }

        public static Exception ValidationResultsCannotRemove() {
            return Failure.Prepare(new InvalidOperationException(SR.ValidationResultsCannotRemove()));
        }

        public static ArgumentException CannotCreateKnownValidatorThisWay(string argName) {
            return Failure.Prepare(new ArgumentException(SR.CannotCreateKnownValidatorThisWay(), argName));
        }

        public static InvalidOperationException CannotUseMissingOrErrorProperties(string propertyNames) {
            return Failure.Prepare(new InvalidOperationException(SR.CannotUseMissingOrErrorProperties(propertyNames)));
        }
    }
}
