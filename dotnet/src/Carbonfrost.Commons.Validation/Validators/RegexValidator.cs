//
// - RegexValidator.cs -
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
using System.Text.RegularExpressions;

using Carbonfrost.Commons.Core;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation.Validators {

    [ValidatorUsage(Name = ValidatorNames.Regex)]
    public class RegexValidator : ValueValidator {

        private Regex regexCache;
        private RegexOptions options;
        private string pattern;
        private readonly KnownValidator knownValidator;

        public string Pattern {
            get { return pattern; }
            set {
                pattern = value;
                regexCache = null;
            }
        }

        public RegexOptions Options {
            get { return options; }
            set {
                options = value;
                regexCache = null;
            }
        }

        public RegexValidator() {
            this.knownValidator = KnownValidator.Regex;
        }

        internal RegexValidator(Regex regexCache, KnownValidator knownValidator) {
            this.regexCache = regexCache;
            this.knownValidator = knownValidator;
            this.pattern = regexCache.ToString();
        }

        // 'ValueValidator' overrides.

        public override string Name {
            get {
                switch (this.knownValidator) {
                    case KnownValidator.Email:
                        return "email";
                    default:
                        return "regex";
                }
            }
        }

        public override KnownValidator KnownValidator { get { return knownValidator; } }

        public override bool IsValid(object value) {
            if (string.IsNullOrEmpty(this.Pattern))
                return true;

            string s = Convert.ToString(value);

            // Use Required to check for zero-length strings
            if (s.Length == 0)
                return true;

            if (regexCache == null) {
                regexCache = new Regex(this.Pattern, this.Options);
            }
            return regexCache.IsMatch(s);
        }
    }
}
