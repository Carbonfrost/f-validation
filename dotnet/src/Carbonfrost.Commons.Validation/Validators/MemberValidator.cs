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
using System.Reflection;

namespace Carbonfrost.Commons.Validation.Validators {

    public abstract class MemberValidator : Validator {

        private readonly Validator _baseValidator;
        private readonly MemberInfo _memberInfo;

        public MemberInfo Member {
            get {
                return _memberInfo;
            }
        }

        public Validator BaseValidator {
            get {
                return _baseValidator;
            }
        }

        protected MemberValidator(MemberInfo memberInfo, Validator baseValidator) {
            if (memberInfo == null) {
                throw new ArgumentNullException("memberInfo"); // $NON-NLS-1
            }
            if (baseValidator == null) {
                throw new ArgumentNullException(nameof(baseValidator));
            }
            _baseValidator = baseValidator;
            _memberInfo = memberInfo;
        }

        public sealed override ValidationErrors Validate(object target) {
            object value = GetValueForValidation(target);
            BaseValidator.Key = Key;
            BaseValidator.FailureMessage = FailureMessage;
            return BaseValidator.Validate(value);
        }

        protected abstract object GetValueForValidation(
            object target
        );
    }
}
