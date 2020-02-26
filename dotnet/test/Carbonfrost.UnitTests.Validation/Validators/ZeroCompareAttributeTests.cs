//
// Copyright 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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
using System.Collections.Generic;
using Carbonfrost.Commons.Spec;
using Carbonfrost.Commons.Validation;

namespace Carbonfrost.UnitTests.Validation.Validators {

    public class ZeroCompareAttributeTests {

        public IEnumerable<Type> ZeroComparisonAttributeTypes {
            get {
                return new [] {
                    typeof(NegativeAttribute),
                    typeof(NonNegativeAttribute),
                    typeof(PositiveAttribute),
                    typeof(NonPositiveAttribute),
                    typeof(NonZeroAttribute),
                };
            }
        }

        public IEnumerable<object[]> ValidCasesForZeroComparisons {
            get {
                return new [] {
                    new object[] { new NonZeroAttribute(), 2 },
                    new object[] { new NonNegativeAttribute(), 2 },
                    new object[] { new NonNegativeAttribute(), 0 },
                    new object[] { new NonPositiveAttribute(), -2 },
                    new object[] { new NonPositiveAttribute(), 0 },
                    new object[] { new PositiveAttribute(), 2 },
                    new object[] { new NegativeAttribute(), -2 },
                };
            }
        }

        [Theory]
        [PropertyData(nameof(ValidCasesForZeroComparisons))]
        public void IsValid_applies_to_numeric_comparisons_to_zero(ValidatorAttribute attr, int y) {
            var validator = attr.CreateValidator("");
            Assert.True(
                validator.Validate(y).IsEmpty
            );
        }

        [Theory]
        [PropertyData(nameof(ZeroComparisonAttributeTypes))]
        public void Constructor_creates_validator_of_correct_type(Type attrType) {
            var attr = (ValidatorAttribute) Activator.CreateInstance(attrType);
            var validator = attr.CreateValidator("");
            Assert.Equal(
                validator.GetType().Name.Replace("Validator", ""),
                attr.GetType().Name.Replace("Attribute", "")
            );
        }
    }
}
