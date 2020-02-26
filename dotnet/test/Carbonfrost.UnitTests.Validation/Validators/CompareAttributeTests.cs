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

    public class CompareAttributeTests {

        public IEnumerable<Type> AttributeTypes {
            get {
                return new [] {
                    typeof(GreaterThanOrEqualToAttribute),
                    typeof(GreaterThanAttribute),
                    typeof(LessThanOrEqualToAttribute),
                    typeof(LessThanAttribute),
                };
            }
        }

        public IEnumerable<object> Operands {
            get {
                return new object[] {
                    100,
                    100D,
                    100M,
                    100F,
                    100L,
                    "100",
                    (byte) 100,
                    (char) 100,
                    (short) 100,
                    (object) new PComparable(),
                };
            }
        }

        [Theory]
        [PropertyData(nameof(AttributeTypes), nameof(Operands))]
        public void Constructor_creates_comparison_of_corresponding_type(Type attrType, object operand) {
            var attr = (CompareAttribute) Activator.CreateInstance(attrType, operand);

            Assert.Equal(operand, attr.Operand);
            Assert.Equal(attrType.Name.Replace("Attribute", ""), attr.Comparison.ToString());
        }

        [Theory]
        [PropertyData(nameof(AttributeTypes))]
        public void Constructor_creates_comparison_of_parser_type(Type attrType) {
            var attr = (CompareAttribute) Activator.CreateInstance(attrType, typeof(PComparable), "200");

            Assert.Equal(new PComparable(200), attr.Operand);
            Assert.Equal(attrType.Name.Replace("Attribute", ""), attr.Comparison.ToString());
        }

        struct PComparable : IComparable<PComparable> {
            private readonly int _v;

            public PComparable(int v) {
                _v = v;
            }

            public int CompareTo(PComparable other) {
                return _v.CompareTo(other._v);
            }

            public static PComparable Parse(string text) {
                return new PComparable(Int32.Parse(text));
            }
        }
    }
}
