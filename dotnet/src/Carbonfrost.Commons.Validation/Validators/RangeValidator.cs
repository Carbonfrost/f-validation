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
using System.Collections;
using Carbonfrost.Commons.Core;

namespace Carbonfrost.Commons.Validation.Validators {

    [ValidatorUsage(Name = ValidatorNames.Range)]
    public class RangeValidator : ValueValidator {

        public object MinValue { get; set; }
        public object MaxValue { get; set; }
        public bool UpperExclusive { get; set; }
        public bool LowerExclusive { get; set; }

        public RangeValidator() {}

        public RangeValidator(object minValue, object maxValue) {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public override string Name {
            get { return ValidatorNames.Range; } }

        protected virtual IComparer GetComparer() {
            return Comparer.Default;
        }

        public override bool IsValid(object value) {
            var c = GetComparer();

            if (MinValue != null) {
                switch (Math.Sign(c.Compare(MinValue, value))) {
                    case 0:
                        if (LowerExclusive) {
                            return false;
                        }
                        break;

                    case 1:
                        return false;

                    case -1: // min < value
                    default:
                        break;
                }

            }

            if (MaxValue != null) {
                switch (Math.Sign(c.Compare(value, MaxValue))) {
                    case 0:
                        if (UpperExclusive) {
                            return false;
                        }
                        break;

                    case 1:
                        return false;

                    case -1: // value < max
                    default:
                        break;
                }
            }

            return true;
        }

    }
}
