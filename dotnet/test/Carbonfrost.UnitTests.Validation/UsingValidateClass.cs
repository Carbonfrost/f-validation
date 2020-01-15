//
// - UsingValidateClass.cs -
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

using System.Reflection;
using Carbonfrost.Commons.Validation;
using Carbonfrost.Commons.Spec;

namespace Carbonfrost.UnitTests.Validation {

    public class UsingValidateClass {

        // TODO Addl scenarios

        [Fact]
        public void validating_email_values() {
            Validate.Email("me@example.com");
        }

        [Fact]
        public void validating_required_values() {
            Validate.Required(true);
            Validate.Required("Non-empty-text");
            Validate.Required(420);
        }

        [Fact]
        [ExpectedException(typeof(ValidationException))]
        public void validating_with_parameters() {
            TestMethod("", null);
        }

        public void TestMethod([Required] string firstName,
                               [Required] string lastName) {
            var thisMethod = GetType().GetTypeInfo().GetMethod("TestMethod");
            Validate.Arguments(thisMethod, firstName, lastName).Valid();
        }

    }
}
