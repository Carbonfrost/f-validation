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

    [AttributeUsage(AbstractValidatorAttribute.COMMON_TARGETS, AllowMultiple = true, Inherited = true)]
    public class RangeAttribute : AbstractValidatorAttribute {

        private readonly object minValue;
        private readonly object maxValue;

        public object MinValue { get { return minValue; } }
        public object MaxValue { get { return maxValue; } }
        public bool LowerExclusive { get; set; }
        public bool UpperExclusive { get; set; }

        public RangeAttribute(int minValue, int maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(object minValue, object maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(double minValue, double maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(decimal minValue, decimal maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(float minValue, float maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(long minValue, long maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(string minValue, string maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(byte minValue, byte maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(char minValue, char maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(short minValue, short maxValue) {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeAttribute(Type type, string minValue, string maxValue) {
            if (type == null)
                throw new ArgumentNullException("type");

            if (maxValue != null) {
                this.maxValue = Activation.FromText(type, maxValue);
            }

            if (minValue != null) {
                this.minValue = Activation.FromText(type, minValue);
            }
        }

        protected override Validator CreateValidatorCore() {
            return new RangeValidator(this.MinValue, this.MaxValue) {
                UpperExclusive = UpperExclusive,
                LowerExclusive = LowerExclusive,
            };
        }

        public sealed override object GetValueGeneratorMetadata(string property) {
            switch (property) {
                case "MinValue":
                    return this.MinValue;

                case "MaxValue":
                    return this.MaxValue;

                case "LowerExclusive":
                    return this.LowerExclusive;

                case "UpperExclusive":
                    return this.UpperExclusive;

                default:
                    return null;
            }
        }

    }
}
