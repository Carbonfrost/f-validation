//
// - ValueValidator{T}.cs -
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

namespace Carbonfrost.Commons.Validation.Validators {

    public abstract class ValueValidator<T> : Validator<T> {

        const int ERROR_CODE = 1;

        public abstract bool IsValid(T value);

        // `Validator' implementation.

        public sealed override bool Validate(T target, ValidationErrors targetErrors) {
            if (targetErrors == null)
                throw new ArgumentNullException("targetErrors"); // $NON-NLS-1

            bool result = IsValid(target);
            if (!result) {
                string s = FormatFailureMessage();

                ValidationError status = new ValidationError(
                    null, s, this.Name, ERROR_CODE);
                targetErrors.Add(status);
            }

            return result;
        }

    }
}
