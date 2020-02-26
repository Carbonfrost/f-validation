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

using Carbonfrost.Commons.Validation.Validators;
using Carbonfrost.Commons.Core;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(ValidatorAttribute.COMMON_TARGETS, AllowMultiple=false, Inherited=true)]
    public sealed class CompareToAttribute : ValidatorAttribute {

        private readonly string _otherProperty;

        public ComparisonOperator ComparisonOperator {
            get;
            set;
        }

        public string PropertyName {
            get {
                return _otherProperty;
            }
        }

        public CompareToAttribute(string propertyName) {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName"); // $NON-NLS-1

            if (propertyName.Trim().Length == 0)
                throw Failure.EmptyString("propertyName"); // $NON-NLS-1

            _otherProperty = propertyName;
        }

        protected override Validator CreateValidatorCore() {
            return new PropertyComparisonValidator(_otherProperty,
                                                   ComparisonOperator);
        }

    }
}
