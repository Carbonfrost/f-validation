//
// Copyright 2010, 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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

using Carbonfrost.Commons.Core;
using Carbonfrost.Commons.Core.Runtime;
using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation.Validators {

    [ValidatorUsage(Name = ValidatorNames.Length)]
    public class LengthValidator : ValueValidator<string> {

        public int? Max { get; set; }
        public int? Min { get; set; }

        protected override string CoerceValue(object target) {
            return (target == null) ? string.Empty : target.ToString();
        }

        internal static bool IsValidImpl(string input, int? minLength, int? maxLength) {
            int length = (input == null) ? 0 : input.Length;
            return (minLength.HasValue ? (int) minLength.Value <= length : true)
                && (maxLength.HasValue ? (int) maxLength.Value >= length : true);
        }

        public LengthValidator() {}

        public LengthValidator(int min, int max) {
            if (min < 0) {
                throw Failure.Negative("min", min);
            }
            if (max < 0) {
                throw Failure.Negative("max", max);
            }
            if (max < min) {
                throw Failure.MinMustBeLessThanMax("min", min);
            }

            Min = min;
            Max = max;
        }

        public LengthValidator(int length) {
            if (length < 0) {
                throw Failure.Negative("length", length);
            }
            Min = length;
            Max = length;
        }

        public override bool IsValid(string value) {
            return IsValidImpl(value, Min, Max);
        }

        public override PropertyProviderFormat DefaultFailureMessageTemplate {
            get {
                string message;
                if (Min.HasValue && Max.HasValue) {
                    message = SR.ValidatorLengthMessageBetween(Min, Max);
                } else if (Min.HasValue) {
                    message = SR.ValidatorLengthMessageTooShort(Min);
                } else {
                    message = SR.ValidatorLengthMessageTooLong(Max);
                }
                return PropertyProviderFormat.Parse(message);
            }
        }
    }
}
