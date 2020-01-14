// //
// // - PatternValidator.cs -
// //
// // Copyright 2012 Carbonfrost Systems, Inc. (http://carbonfrost.com)
// //
// // Licensed under the Apache License, Version 2.0 (the "License");
// // you may not use this file except in compliance with the License.
// // You may obtain a copy of the License at
// //
// //     http://www.apache.org/licenses/LICENSE-2.0
// //
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.
// //

// using System;
// using System.Linq;
// using Carbonfrost.Commons.ComponentModel.Patterns;
// using Carbonfrost.Commons.Validation.Validators;

// namespace Carbonfrost.Commons.Validation {

//     partial class Validator {
//         public static Validator<T> FromPattern<T>(IPattern<T> pattern) {
//             if (pattern == null)
//                 throw new ArgumentNullException("pattern");

//             return new PatternValidator<T>(pattern);
//         }
//     }

//     class PatternValidator<T> : ValueValidator<T> {

//         private readonly IPattern<T> pattern;

//         public PatternValidator(IPattern<T> pattern) {
//             this.pattern = pattern;
//         }

//         public override bool IsValid(T value) {
//             return pattern.IsMatch(value, null);
//         }

//         public override string Name {
//             get {
//                 throw new NotImplementedException();
//             }
//         }
//     }
// }
