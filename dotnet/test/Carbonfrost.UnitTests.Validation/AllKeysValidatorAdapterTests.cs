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

using System.Linq;

using Carbonfrost.Commons.Spec;
using Carbonfrost.Commons.Validation;
using Carbonfrost.Commons.Validation.Validators;

namespace Carbonfrost.UnitTests.Validation {

    public class AllKeysValidatorAdapterTests {

        [XFact(Reason = "Pending localization rules")]
        public void Validate_should_apply_to_enumerable_as_an_object() {
            var required = new RequiredValidator();
            var validator = Validator.Redirect(required, ValidatorTarget.AllKeys);

            var obj = new PDictionaryWithNull();
            var actual = validator.Validate(obj);
            Assert.Single(actual);
            Assert.Equal("Keys are required", actual.Values.First().Message);
        }
    }
}
