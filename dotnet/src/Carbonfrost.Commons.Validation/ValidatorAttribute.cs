//
// Copyright 2010, 2020 Carbonfrost Systems, Inc. (https://carbonfrost.com)
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
using System.Reflection;

namespace Carbonfrost.Commons.Validation {

    public abstract class ValidatorAttribute : Attribute {

        // UNDONE Could provide IValueGeneratorMetadataProvider

        internal const AttributeTargets COMMON_TARGETS = (
            AttributeTargets.Parameter
            | AttributeTargets.Interface
            | AttributeTargets.Field
            | AttributeTargets.Property
            | AttributeTargets.Method
            | AttributeTargets.Struct
            | AttributeTargets.Class
        );

        public string FailureMessage {
            get;
            set;
        }

        public string Key {
            get;
            set;
        }

        public ValidatorTarget Target {
            get;
            set;
        }

        protected ValidatorAttribute() {}

        internal Validator CreateValidator(MemberInfo member) {
            return CreateValidator(member.Name);
        }

        internal Validator CreateValidator(string key) {
            Validator v = Validator.Redirect(
                CreateValidatorCore(), Target
            );
            v.Key = string.IsNullOrWhiteSpace(Key) ? key : Key;
            v.FailureMessage = FailureMessage;
            return v;
        }

        protected abstract Validator CreateValidatorCore();

        public virtual object GetValueGeneratorMetadata(string property) {
            return null;
        }
    }
}
