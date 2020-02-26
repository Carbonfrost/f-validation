//
// Copyright 2010, 2012, 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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

    public abstract class Validator<T> : Validator {

        protected virtual T CoerceValue(object target) {
            if (target is T) {
                return (T) target;
            }

            throw new NotImplementedException();
        }

        public sealed override ValidationErrors Validate(object target) {
            T t = CoerceValue(target);
            return Validate(t);
        }

        public abstract ValidationErrors Validate(T target);
    }
}
