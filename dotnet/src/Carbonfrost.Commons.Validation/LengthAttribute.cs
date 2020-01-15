//
// - LengthAttribute.cs -
//
// Copyright 2010, 2012 Carbonfrost Systems, Inc. (http://carbonfrost.com)
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
using System.ComponentModel;
using System.Reflection;

using Carbonfrost.Commons.Validation.Validators;
using Carbonfrost.Commons.Core;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(AbstractValidatorAttribute.COMMON_TARGETS, AllowMultiple = false, Inherited = true)]
    public class LengthAttribute : AbstractValidatorAttribute {

        private readonly int? max;
        private readonly int? min;

        public int? Min { get { return min; } }
        public int? Max { get { return max; } }

        public LengthAttribute(int exactly)
          :this(exactly, exactly) {
        }

        public LengthAttribute(int min, int max) {
            if (max < min)
                throw Failure.MinMustBeLessThanMax("min", min); // $NON-NLS-1

            this.min = min;
            this.max = max;
        }

        protected LengthAttribute(int? min, int? max) {
            if (min.HasValue && max.HasValue) {
                if (max.Value < min.Value)
                    throw Failure.MinMustBeLessThanMax("min", min); // $NON-NLS-1
            }

            this.min = min;
            this.max = max;
        }

        protected override Validator CreateValidatorCore() {
            return new LengthValidator {
                Max = this.Max,
                Min = this.Min,
            };
	    }

        public sealed override object GetValueGeneratorMetadata(string property) {
            switch (property) {
                case "MaxLength":
                    return this.Max;

                case "MinLength":
                    return this.Min;

                default:
                    return null;
            }
        }
    }
}
