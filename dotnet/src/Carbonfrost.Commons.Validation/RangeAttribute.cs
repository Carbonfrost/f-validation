//
// - RangeAttribute.cs -
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
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(ValidatorAttribute.COMMON_TARGETS, AllowMultiple = true, Inherited = true)]
    public class RangeAttribute : ValidatorAttribute {

        private readonly object _minValue;
        private readonly object _maxValue;

        public object MinValue {
            get {
                return _minValue;
            }
        }

        public object MaxValue {
            get {
                return _maxValue;
            }
        }

        public bool MinExclusive { get; set; }
        public bool MaxExclusive { get; set; }

        public RangeAttribute(int minValue, int maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(object minValue, object maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(double minValue, double maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(decimal minValue, decimal maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(float minValue, float maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(long minValue, long maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(string minValue, string maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(byte minValue, byte maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(char minValue, char maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(short minValue, short maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public RangeAttribute(Type type, string minValue, string maxValue) {
            if (type == null)
                throw new ArgumentNullException("type");

            if (maxValue != null) {
                _maxValue = Activation.FromText(type, maxValue);
            }

            if (minValue != null) {
                _minValue = Activation.FromText(type, minValue);
            }
        }

        protected override Validator CreateValidatorCore() {
            return new RangeValidator(MinValue, MaxValue) {
                MaxExclusive = MaxExclusive,
                MinExclusive = MinExclusive,
            };
        }

        public sealed override object GetValueGeneratorMetadata(string property) {
            switch (property) {
                case "MinValue":
                    return MinValue;

                case "MaxValue":
                    return MaxValue;

                case "MinExclusive":
                    return MinExclusive;

                case "MaxExclusive":
                    return this.MaxExclusive;

                default:
                    return null;
            }
        }

    }
}
