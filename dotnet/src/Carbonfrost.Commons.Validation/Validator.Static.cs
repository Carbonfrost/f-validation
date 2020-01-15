//
// - Validator.Static.cs -
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
using System.Reflection;
using Carbonfrost.Commons.Core;
using Carbonfrost.Commons.Core.Runtime;
using Carbonfrost.Commons.Validation.Resources;
using Carbonfrost.Commons.Validation.Validators;

namespace Carbonfrost.Commons.Validation {

    public partial class Validator {

        private static readonly IDictionary<Type, ValidatorSequence> baseValidatorMap
            = new Dictionary<Type, ValidatorSequence>();

        public static ValidatorSequence Compose(IEnumerable<Validator> validators) {
            if (validators == null)
                throw new ArgumentNullException("validators"); // $NON-NLS-1

            ValidatorSequence vs = new ValidatorSequence();
            vs.Validators.AddMany(validators);
            return vs;
        }

        public static ValidatorSequence Compose(params Validator[] validators) {
            if (validators == null)
                throw new ArgumentNullException("validators"); // $NON-NLS-1

            ValidatorSequence vs = new ValidatorSequence();
            vs.Validators.AddMany(validators);
            return vs;
        }

        public static Validator CreateSelfValidator(Type instanceType) {
            if (instanceType == null)
                throw new ArgumentNullException("instanceType"); // $NON-NLS-1

            if (typeof(ISelfValidation).IsAssignableFrom(instanceType))
                return new SelfValidationAdapter();

            // Look for the self-validation method
            foreach (MethodInfo method in instanceType.GetTypeInfo().GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly)) {
                if (method.IsDefined(typeof(SelfValidationMethodAttribute)))
                    return new SelfValidator(method);
            }

            // Look for a method named Validate
            try {
                MethodInfo mi = instanceType.GetTypeInfo().GetMethod(
                    "Validate", // $NON-NLS-1
                    new Type[] { instanceType, typeof(ValidationErrors) }, null);
                if (mi != null && mi.IsStatic && mi.DeclaringType == instanceType) {
                    return new SelfValidator(mi);
                }
            } catch (AmbiguousMatchException) {
            }

            try {
                MethodInfo mi = instanceType.GetTypeInfo().GetMethod(
                    "Validate", // $NON-NLS-1
                     new Type[] { typeof(ValidationErrors) }, null);
                if (mi != null && !mi.IsStatic) {
                    return new SelfValidator(mi);
                }
            } catch (AmbiguousMatchException) {
            }

            return null;
        }

        [ValidatorUsage(Name = ValidatorNames.Email)]
        public static RegexValidator Email() {
            return (RegexValidator) Create(KnownValidator.Email);
        }

        [ValidatorUsage(Name = ValidatorNames.MaxLength)]
        public static LengthValidator MaxLength(int max) {
            return new LengthValidator(0, max);
        }

        [ValidatorUsage(Name = ValidatorNames.MinLength)]
        public static LengthValidator MinLength(int min) {
            return new LengthValidator { Min = min };
        }

        // UNDONE Implement Validator Create methods

        public static Validator<T> Create<T>() {
            throw new NotImplementedException();
        }

        public static Validator<T> Create<T>(params string[] rulesets) {
            return (Validator<T>) Create(typeof(T), rulesets);
        }

        public static ValidatorSequence Create(Type instanceType) {
            if (instanceType == null)
                throw new ArgumentNullException("instanceType"); // $NON-NLS-1

            throw new NotImplementedException();
        }

        public static Validator Create(Type instanceType, params string[] rulesets) {
            if (instanceType == null)
                throw new ArgumentNullException("instanceType"); // $NON-NLS-1

            throw new NotImplementedException();
        }

        public static ValidatorSequence Filtered(ValidatorSequence validator, IEnumerable<string> rulesets) {
            if (validator == null)
                throw new ArgumentNullException("validator"); // $NON-NLS-1
            if (rulesets == null)
                throw new ArgumentNullException("rulesets"); // $NON-NLS-1
            var s = new HashSet<string>(rulesets, StringComparer.OrdinalIgnoreCase);

            if (s.Count == 0)
                return validator;
            else
                return new RulesetFilteredValidatorSequence(validator, s);
        }

        public static Validator Create(KnownValidator knownValidator) {
            switch (knownValidator) {
                case KnownValidator.Required:
                    return new RequiredValidator();

                case KnownValidator.Length:
                    return new LengthValidator();

                case KnownValidator.Range:
                    return new RangeValidator();

                case KnownValidator.PropertyComparison:
                    return new PropertyComparisonValidator();

                case KnownValidator.Email:
                    return new RegexValidator(RegularExpressions.EmailAddress, KnownValidator.Email);

                case KnownValidator.Regex:
                    return new RegexValidator();

                case KnownValidator.Self:
                    throw ValidationFailure.CannotCreateKnownValidatorThisWay("knownValidator");

                case KnownValidator.Unknown:
                    throw new ArgumentOutOfRangeException("knownValidator", knownValidator, SR.CannotBeUnknownValidator()); // $NON-NLS-1

                default:
                    throw Failure.NotDefinedEnum("knownValidator", knownValidator); // $NON-NLS-1
            }
        }

        public static Validator Create(KnownValidator knownValidator,
                                       IEnumerable<KeyValuePair<string, object>> values) {
            Validator v = Create(knownValidator);
            Activation.Initialize(v, values);
            return v;
        }

        public static Validator Redirect(Validator source, ValidatorTarget target) {
            if (source == null)
                throw new ArgumentNullException("source"); // $NON-NLS-1

            switch (target) {
                case ValidatorTarget.AllKeys:
                    return new AllKeysValidatorAdapter(source);

                case ValidatorTarget.AllValues:
                    return new AllValuesValidatorAdapter(source);

                case ValidatorTarget.EachKey:
                    return new EachKeyValidatorAdapter(source);

                case ValidatorTarget.EachValue:
                    return new EachValueValidatorAdapter(source);

                case ValidatorTarget.EachItem:
                    return new EachItemValidatorAdapter(source);

                case ValidatorTarget.Value:
                default:
                    return source;
            }
        }

        public static Validator FromName(string name) {
            return App.GetProvider<Validator>(name);
        }

        public static MemberValidator FromMember(MemberInfo member) {
            if (member == null)
                throw new ArgumentNullException("member");

            return _CreateValidator(member);
        }

        public static Validator GetValidator(PropertyInfo property, IServiceProvider serviceProvider = null) {
            throw new NotImplementedException();
        }

        private static MemberValidator _CreateValidator(MemberInfo member) {
            var validatorAttributes = member.GetCustomAttributes<AbstractValidatorAttribute>();

            // Create the interior validators
            ValidatorSequence validatorSequence = new ValidatorSequence();

            foreach (AbstractValidatorAttribute ava in validatorAttributes)
                validatorSequence.Validators.Add(ava.CreateValidator(member));

            switch (member.MemberType) {
                case MemberTypes.Method:
                    return new MethodReturnValueValidator((MethodInfo) member, validatorSequence);

                case MemberTypes.Property:
                    return new PropertyValidator((PropertyInfo) member, validatorSequence);

                case MemberTypes.TypeInfo:
                    throw new NotImplementedException();

                case MemberTypes.Field:
                default:
                    return new FieldValidator((FieldInfo) member, validatorSequence);
            }
        }
    }


}
