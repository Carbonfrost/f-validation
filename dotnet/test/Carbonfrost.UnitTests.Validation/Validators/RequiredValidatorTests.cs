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
using System.Reflection;
using Carbonfrost.Commons.Validation;
using Carbonfrost.Commons.Validation.Validators;
using Carbonfrost.Commons.Spec;

namespace Carbonfrost.UnitTests.Validation.Validators {

    public class RequiredValidatorTests {

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

    }
}
