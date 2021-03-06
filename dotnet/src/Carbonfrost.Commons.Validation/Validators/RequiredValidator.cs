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
using Carbonfrost.Commons.Core.Runtime;
using Carbonfrost.Commons.Validation.Resources;

namespace Carbonfrost.Commons.Validation.Validators {

    [ValidatorUsage(Name = ValidatorNames.Required)]
    public class RequiredValidator : ValueValidator {

        public override PropertyProviderFormat DefaultFailureMessageTemplate {
            get {
                return PropertyProviderFormat.Parse(string.IsNullOrEmpty(Key)
                    ? SR.ValidatorRequiredMessage()
                    : SR.ValidatorRequiredMessageWithKey());
            }
        }

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

                case TypeCode.DBNull:
                    return false;

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
            var propertyInfo = type.GetTypeInfo().GetProperty(
                "IsEmpty",
                typeof(bool), Type.EmptyTypes
            );
            if (propertyInfo != null && propertyInfo.GetMethod != null && !propertyInfo.GetMethod.IsStatic) {
                return !((bool) propertyInfo.GetValue(value, null));
            }

            var propertyInfo0 = type.GetTypeInfo().GetProperty(
                "Empty", type, Type.EmptyTypes
            );
            if (propertyInfo0 != null && propertyInfo0.GetMethod != null && propertyInfo0.GetMethod.IsStatic) {
                return !object.Equals(propertyInfo0.GetValue(null, null), value);
            }

            var emptyField = type.GetTypeInfo().GetField("Empty", BindingFlags.Static | BindingFlags.Public);
            if (emptyField != null) {
                return !object.Equals(emptyField.GetValue(null), value);
            }

            return true;
        }

        private static bool IsValidNullable(object value, Type type) {
            PropertyInfo propertyInfo = type.GetTypeInfo().GetProperty("HasValue", typeof(bool), Type.EmptyTypes);
            return (bool) propertyInfo.GetValue(value, null);
        }
    }
}
