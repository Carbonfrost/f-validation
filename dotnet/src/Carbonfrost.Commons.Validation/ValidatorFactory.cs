//
// - ValidatorFactory.cs -
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
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    public class ValidatorFactory : AdapterFactory<Validator> {

        public static readonly ValidatorFactory Default = new ValidatorFactory(AdapterFactory.Default);

        protected ValidatorFactory()
            : base(AdapterRole.Validator) {}

        protected ValidatorFactory(IAdapterFactory implementation)
            : base(AdapterRole.Validator, implementation) {}

        public Validator GetValidator(Type adapteeType, IServiceProvider serviceProvider = null) {
            return base.Create(adapteeType);
        }

    }
}
