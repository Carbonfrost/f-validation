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
using Carbonfrost.Commons.Core.Runtime;
using Carbonfrost.Commons.Validation.Validators;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(ValidatorAttribute.COMMON_TARGETS, AllowMultiple = true, Inherited = true)]
    public class CompareAttribute : ValidatorAttribute {

        private readonly ComparisonOperator _comparison;
        private readonly object _operand;

        public ComparisonOperator Comparison {
            get {
                return _comparison;
            }
        }

        public object Operand {
            get {
                return _operand;
            }
        }

        public CompareAttribute(ComparisonOperator comparison, int value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, object value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, double value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, decimal value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, float value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, long value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, string value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, byte value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, char value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, short value) {
            _comparison = comparison;
            _operand = value;
        }

        public CompareAttribute(ComparisonOperator comparison, Type type, string value) {
            if (type == null) {
                throw new ArgumentNullException("type");
            }

            _comparison = comparison;
            _operand = Activation.FromText(type, value);
        }

        protected override Validator CreateValidatorCore() {
            return new CompareValidator(Comparison, Operand);
        }
    }
}
