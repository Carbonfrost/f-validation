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

using Carbonfrost.Commons.Validation.Validators;
using Carbonfrost.Commons.Core;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(ValidatorAttribute.COMMON_TARGETS, AllowMultiple = false, Inherited = true)]
    public class LengthAttribute : ValidatorAttribute {

        private readonly int? _max;
        private readonly int? _min;

        public int? Min {
            get {
                return _min;
            }
        }

        public int? Max {
            get {
                return _max;
            }
        }

        public LengthAttribute(int exactly)
          :this(exactly, exactly) {
        }

        public LengthAttribute(int min, int max) {
            if (max < min) {
                throw Failure.MinMustBeLessThanMax(nameof(min), min);
            }

            _min = min;
            _max = max;
        }

        protected LengthAttribute(int? min, int? max) {
            if (min.HasValue && max.HasValue) {
                if (max.Value < min.Value) {
                    throw Failure.MinMustBeLessThanMax(nameof(min), min);
                }
            }

            _min = min;
            _max = max;
        }

        protected override Validator CreateValidatorCore() {
            return new LengthValidator {
                Max = Max,
                Min = Min,
            };
        }

        public sealed override object GetValueGeneratorMetadata(string property) {
            switch (property) {
                case "MaxLength":
                    return Max;

                case "MinLength":
                    return Min;

                default:
                    return null;
            }
        }
    }
}
