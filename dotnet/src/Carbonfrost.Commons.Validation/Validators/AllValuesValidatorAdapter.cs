//
// - AllValuesValidatorAdapter.cs -
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

namespace Carbonfrost.Commons.Validation.Validators {

    internal sealed class AllValuesValidatorAdapter : ValidatorAdapter {

        public AllValuesValidatorAdapter(Validator validator) : base(validator) {
        }

        public override bool Validate(object target, ValidationErrors targetErrors) {
            throw new NotImplementedException();
        }

        // TODO Maybe a better tag name here?

        protected override object GetValueForValidation(object target, out string accessFailureMessage) {
            throw new NotImplementedException();
        }
    }
}
