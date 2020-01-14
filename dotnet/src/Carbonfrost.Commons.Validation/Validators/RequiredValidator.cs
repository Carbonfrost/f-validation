//
// - RequiredValidator.cs -
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
using System.Reflection;

using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation.Validators {

    [ValidatorUsage(Name = ValidatorNames.Required)]
    public class RequiredValidator : ValueValidator {

        public RequiredValidator() {
            FailureMessage = SR.ValidatorRequiredMessage();
        }

        // `ValueValidator' overrides.
        public override string Name {
            get { return ValidatorNames.Required; } }

        public override bool IsValid(object value) {
            return IsValidImpl(value);
        }

        internal static bool IsValidImpl(object value, Type bindType = null) {
            if (object.ReferenceEquals(value, null))
                return false;

            Type type = bindType ?? value.GetType();
            if (type.IsArray)
                return ((Array) value).Length > 0;

            // Look for nullables
            Type underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
                return IsValidNullable(value, type);

            switch (Type.GetTypeCode(type)) {
                case TypeCode.Boolean:
                    return (bool) value;

                case TypeCode.Byte:
                    return ((byte) value) != 0;

                case TypeCode.Char:
                    return ((char) value) != 0;

                case TypeCode.DateTime:
                    return true;

#if NET
                case TypeCode.DBNull:
                    return false;
#endif
                case TypeCode.Decimal:
                    return ((decimal) value) != 0;

                case TypeCode.Double:
                    return Math.Abs(((double) value)) > (0.000001);

                case TypeCode.Empty:
                    return false;

                case TypeCode.Int16:
                    return ((short) value) != 0;

                case TypeCode.Int32:
                    return ((int) value) != 0;

                case TypeCode.Int64:
                    return ((long) value) != 0;

                case TypeCode.SByte:
                    return ((sbyte) value) != 0;

                case TypeCode.Single:
					return Math.Abs(((float) value)) > 0.000001;

                case TypeCode.String:
                    return ((string) value).Trim().Length > 0;

                case TypeCode.UInt16:
                    return ((ushort) value) != 0;

                case TypeCode.UInt32:
                    return ((uint) value) != 0;

                case TypeCode.UInt64:
                    return ((ulong) value) != 0;

                case TypeCode.Object:
                default:
                    // We are a struct or some other reference type
                    return IsValidWithNaturalDefault(value, type);
            }

        }

        private static bool IsValidWithNaturalDefault(object value, Type type) {
            ICollection c = value as ICollection;
            PropertyInfo propertyInfo = type.GetTypeInfo().GetProperty(
                "IsEmpty", // $NON-NLS-1
                typeof(bool), Type.EmptyTypes);
            if (propertyInfo != null && propertyInfo.GetMethod != null && !propertyInfo.GetMethod.IsStatic) {
                return !((bool) propertyInfo.GetValue(value, null));
            }

            PropertyInfo propertyInfo0
                = type.GetTypeInfo().GetProperty(
                    "Empty", // $NON-NLS-1
                    type, Type.EmptyTypes);

            if (propertyInfo0 != null && propertyInfo0.GetMethod != null && propertyInfo0.GetMethod.IsStatic)
                return object.Equals(propertyInfo0.GetValue(null, null), value);

            else
                return true;
        }

        private static bool IsValidNullable(object value, Type type) {
            PropertyInfo propertyInfo = type.GetTypeInfo().GetProperty("HasValue", typeof(bool), Type.EmptyTypes); // $NON-NLS-1
            return (bool) propertyInfo.GetValue(value, null);
        }
    }
}
