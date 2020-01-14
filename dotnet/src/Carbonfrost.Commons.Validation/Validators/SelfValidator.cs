//
// - SelfValidator.cs -
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
using System.ComponentModel;
using System.Reflection;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation.Validators {

	internal sealed class SelfValidator : Validator {

	    private readonly MethodInfo method;
	    private readonly string defaultFailureMessageTemplate; // UNDONE Use this value

	    public SelfValidator(MethodInfo method) {
	        this.method = method;
	    }

	    // `Validator' overrides.
	    public override string Name {
            get { return ValidatorNames.Self; } }

	    public override KnownValidator KnownValidator { get { return KnownValidator.Self; } }

	    public override bool Validate(object target, ValidationErrors targetErrors) {
	        // use either
	        // instance method bool Validate(ValidationErrors errors)
	        // static method bool Validate(object instance, ValidationErrors errors)
	        if (this.method.IsStatic)
	            return (bool) this.method.Invoke(null, new object[] { target, targetErrors });
	        else
	            return (bool) this.method.Invoke(target, new object[] { targetErrors });
	    }

	}
}
