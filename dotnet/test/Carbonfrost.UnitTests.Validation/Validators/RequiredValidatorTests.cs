//
// - RequiredValidatorTests.cs -
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
using Carbonfrost.Commons.Validation;
using Carbonfrost.Commons.Validation.Validators;
using Carbonfrost.Commons.Spec;
using System.Collections.Generic;

namespace Carbonfrost.UnitTests.Validation.Validators {

    public class RequiredValidatorTests {

        public IEnumerable<object[]> EmptyValues {
            get {
                return new[] {
                    new object[] { typeof(bool), false },
                    new object[] { typeof(byte), (byte) 0 },
                    new object[] { typeof(char), (char) 0 },
                    new object[] { typeof(decimal), (decimal) 0m },
                    new object[] { typeof(double), (double) 0 },
                    new object[] { typeof(short), (short) 0 },
                    new object[] { typeof(int), (int) 0 },
                    new object[] { typeof(long), (long) 0 },
                    new object[] { typeof(sbyte), (sbyte) 0 },
                    new object[] { typeof(float), (float) 0 },
                    new object[] { typeof(string), (string) "" },
                    new object[] { typeof(ushort), (ushort) 0 },
                    new object[] { typeof(uint), (uint) 0 },
                    new object[] { typeof(ulong), (ulong) 0 },
                };
            }
        }

        [Fact]
        public void boolean_should_be_true_for_required() {
            Assert.True(RequiredValidator.IsValidImpl(true));
            Assert.False(RequiredValidator.IsValidImpl(false));
        }

        [Fact]
        public void int32_should_be_nonzero_for_required() {
            Assert.True(RequiredValidator.IsValidImpl(420));
            Assert.False(RequiredValidator.IsValidImpl(0));
        }

        [Fact]
        public void array_should_be_valid_on_having_value() {
            int[] noValue = null; // false because it has no value
            int[] aValue = new int[0];
            int[] bValue = { 0, 0, 0 };

            Assert.False(RequiredValidator.IsValidImpl(noValue));
            Assert.False(RequiredValidator.IsValidImpl(aValue));
            Assert.True(RequiredValidator.IsValidImpl(bValue));
        }

        [Fact]
        public void nullables_should_be_valid_on_hasvalue() {
            int? noValue = null; // false because it has no value
            int? aValue = 3;
            int? bValue = 0; // _true_ even though it is zero

            Assert.False(RequiredValidator.IsValidImpl(noValue));
            Assert.True(RequiredValidator.IsValidImpl(aValue));
            Assert.True(RequiredValidator.IsValidImpl(bValue, typeof(int?)));
        }

        [Fact]
        public void nullable_should_be_true_for_required() {
            int? value = new int?(0);

            // True because nullable is carried
            Assert.True(Validate.Required(value));

            // False because implicitly unboxed as an int, not as int?
            Assert.False(Validate.Required((object) value));
        }

        [Theory]
        [PropertyData(nameof(EmptyValues))]
        public void IsValidImpl_applies_to_common_values(Type type, object value) {
            Assert.False(
                RequiredValidator.IsValidImpl(value, type)
            );
        }

        [Fact]
        public void IsValidImpl_applies_to_struct_with_natural_empty_value() {
            var empty = PNaturalEmptyValue.Empty;
            var notEmpty = new PNaturalEmptyValue();
            Assert.True(RequiredValidator.IsValidImpl(notEmpty));
            Assert.False(RequiredValidator.IsValidImpl(empty));
        }

        [Fact]
        public void IsValidImpl_applies_to_struct_with_empty_value_test() {
            var empty = new PHasEmptyValueTest { IsEmpty = true };
            var notEmpty = new PHasEmptyValueTest();

            Assert.True(RequiredValidator.IsValidImpl(notEmpty));
            Assert.False(RequiredValidator.IsValidImpl(empty));
        }

        class PNaturalEmptyValue {
            public static readonly PNaturalEmptyValue Empty = new PNaturalEmptyValue();
            public int Value { get; set; }
        }

        struct PHasEmptyValueTest {
            public bool IsEmpty {
                get;
                set;
            }
        }

        [XFact(Reason = "Pending localization rules")]
        public void DefaultFailureMessage_is_equal_loaded_from_resources() {
            var req = new RequiredValidator();
            Assert.Equal(
                "${Key} is required",
                req.DefaultFailureMessageTemplate.ToString()
            );
        }

        [XFact(Reason = "Pending localization rules")]
        public void FailureMessage_applies_default_message_format() {
            var req = new RequiredValidator { Key = "First name" };
            Assert.Equal(
                "First name is required",
                req.FailureMessage
            );
        }

        [Fact]
        public void Validate_generates_correct_key_and_validator() {
            var req = new RequiredValidator { Key = "First name" };
            var errors = req.Validate("");
            Assert.Equal("First name", errors[0].Key);
            Assert.Equal("required", errors[0].Validator);
        }
    }
}
