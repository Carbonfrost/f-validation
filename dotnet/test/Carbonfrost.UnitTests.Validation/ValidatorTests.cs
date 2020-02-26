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
using Carbonfrost.Commons.Validation.Validators;

namespace Carbonfrost.UnitTests.Validation {

    public class ValidatorTests {

        public IEnumerable<ValidatorTarget> RedirectTargets {
            get {
                return (ValidatorTarget[]) Enum.GetValues(typeof(ValidatorTarget));
            }
        }

        [Theory]
        [PropertyData(nameof(RedirectTargets))]
        public void Redirect_should_generate_correct_validator(ValidatorTarget target) {
            if (target == ValidatorTarget.Value) {
                Assert.Pass();
            }

            var required = new RequiredValidator();
            var validator = Validator.Redirect(required, target);

            Assert.Equal(target.ToString(), validator.GetType().Name.ToString().Replace("ValidatorAdapter", ""));
        }
    }
}
