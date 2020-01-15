//
// - LengthValidator.cs -
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
using Carbonfrost.Commons.Core;

namespace Carbonfrost.Commons.Validation.Validators {

    [ValidatorUsage(Name = ValidatorNames.Length)]
    public class LengthValidator : ValueValidator<string> {

        public int? Max { get; set; }
        public int? Min { get; set; }

        public override string Name {
            get { return ValidatorNames.Length; } }

        protected override string CoerceValue(object target) {
            return (target == null) ? string.Empty : target.ToString();
        }

        // N.B. These constructors are important for ValidationHelper (must have unique number of arguments)

        public LengthValidator() {}

        public LengthValidator(int min, int max) {
            if (min < 0)
                throw Failure.Negative("min", min);
            if (max < 0)
                throw Failure.Negative("max", max);
            if (max < min)
                throw Failure.MinMustBeLessThanMax("min", min);

            this.Min = min;
            this.Max = max;
        }

        public LengthValidator(int length) {
            if (length < 0)
                throw Failure.Negative("length", length);
            this.Min = length;
            this.Max = length;
        }

        public override bool IsValid(string value) {
            int length = (value == null) ? 0 : value.Length;
            return (this.Min.HasValue ? (int) this.Min.Value <= length : true)
                && (this.Max.HasValue ? (int) this.Max.Value >= length : true);
        }

    }
}
