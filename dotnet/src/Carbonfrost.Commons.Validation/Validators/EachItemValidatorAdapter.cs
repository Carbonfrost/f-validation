//
// - EachItemValidatorAdapter.cs -
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

namespace Carbonfrost.Commons.Validation.Validators {

    internal sealed class EachItemValidatorAdapter : Validator {
        // TODO This should be a validator adapter derived class
        private readonly Validator validator;

        public EachItemValidatorAdapter(Validator validator) {
            this.validator = validator;
        }

        public override bool Validate(object target, ValidationErrors targetErrors) {
            if (target == null)
                return validator.Validate(target, targetErrors);
            else {
                IEnumerable e = (IEnumerable) target;
                foreach (object o in e)
                    validator.Validate(target, targetErrors);

                return true;
            }
        }

        // TODO Maybe a better tag name here?
	    public override string Name {
	        get { return validator.Name; } }
    }
}
