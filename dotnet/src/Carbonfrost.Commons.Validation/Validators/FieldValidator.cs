//
// - FieldValidator.cs -
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
using System.Reflection;
using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation.Validators {

    public class FieldValidator : MemberValidator {

        public FieldInfo Field { get { return (FieldInfo) Member; } }

        public FieldValidator(FieldInfo field, Validator baseValidator)
            : base(field, baseValidator) {}

        protected override object GetValueForValidation(object target) {
            try {
                return Field.GetValue(target);

            } catch (Exception ex) {
                throw new ValidationException(
                    SR.FieldValueNotAccessible(Field.Name),
                    ex
                );
            }
        }
    }
}
