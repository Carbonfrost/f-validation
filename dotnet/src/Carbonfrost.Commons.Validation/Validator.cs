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
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    [Composable, Providers]
    public abstract partial class Validator {

        private string _failureMessage;
        private bool _failureMessageExplicit;

        public string FailureMessage {
            get {
                if (!_failureMessageExplicit && string.IsNullOrEmpty(_failureMessage)) {
                    return DefaultFailureMessageTemplate.Format(
                        PropertyProvider.FromValue(this)
                    );
                }

                return _failureMessage;
            }
            set {
                _failureMessage = value;
                _failureMessageExplicit = true;
            }
        }

        public virtual PropertyProviderFormat DefaultFailureMessageTemplate {
            get {
                throw new NotImplementedException();
            }
        }

        public string Key {
            get;
            set;
        }

        public abstract ValidationErrors Validate(object target);
    }
}
