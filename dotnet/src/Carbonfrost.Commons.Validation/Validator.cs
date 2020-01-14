//
// - Validator.cs -
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
using System.Collections.Generic;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    [Providers]
    public abstract partial class Validator {

        private string failureMessageTemplate;
        private HashSet<string> rulesets;
        private bool failureMessageExplicit;

        public string FailureMessage {
            get {
                if (!failureMessageExplicit && string.IsNullOrEmpty(failureMessageTemplate))
                    return Utility.GetDefaultFailureMessage(this);

                return failureMessageTemplate;
            }
            set {
                failureMessageTemplate = value;
                failureMessageExplicit = true;
            }
        }

        public string Key { get; set; }

        public virtual KnownValidator KnownValidator {
            get { return KnownValidator.Unknown; } }

        public bool Negate { get; set; }

        public ICollection<string> Rulesets {
            get {
                if (this.rulesets == null)
                    this.rulesets = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                return rulesets;
            }
        }

        public abstract string Name { get; }

        protected internal virtual ValidationError CreateValidationError(string message, object target) {
            return new ValidationError(
                Key,
                message ?? this.FormatFailureMessage(),
                this.Name,
                1);
        }

        public virtual string FormatFailureMessage() {
            return PropertyProvider.Format(this.FailureMessage, this);
        }

        public ValidationErrors Validate(object target) {
            ValidationErrors vr = new ValidationErrors();
            Validate(target, vr);
            return vr;
        }

        public abstract bool Validate(object target, ValidationErrors targetErrors);
    }
}
