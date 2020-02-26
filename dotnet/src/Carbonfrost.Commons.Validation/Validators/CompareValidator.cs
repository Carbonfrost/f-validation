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
using System.Collections;
using System.Reflection;

namespace Carbonfrost.Commons.Validation.Validators {

    public class CompareValidator : ValueValidator {

        public ComparisonOperator Comparison {
            get;
            private set;
        }

        public object Operand {
            get;
            private set;
        }

        public CompareValidator(ComparisonOperator comparison, object operand) {
            Comparison = comparison;
            Operand = operand;
        }

        internal static bool IsValid(ComparisonOperator @operator, object operand, object value) {
            int cmp = Comparer.Default.Compare(value, operand);
            switch (@operator) {
                case ComparisonOperator.NotEqual:
                    return cmp != 0;
                case ComparisonOperator.GreaterThan:
                    return cmp > 0;
                case ComparisonOperator.GreaterThanOrEqualTo:
                    return cmp >= 0;
                case ComparisonOperator.LessThan:
                    return cmp < 0;
                case ComparisonOperator.LessThanOrEqualTo:
                    return cmp <= 0;
                case ComparisonOperator.Equal:
                default:
                    return cmp == 0;
            }
        }

        internal static bool IsValidRelativeToZero(ComparisonOperator @operator, object value) {
            return IsValid(@operator, GetZeroValue(value.GetType()), value);
        }

        public override bool IsValid(object value) {
            return IsValid(Comparison, Operand, value);
        }

        // UNDONE Do the conversion to the property type

        internal static object GetZeroValue(Type propertyType) {
            // Look for nullables
            Type underlyingType = Nullable.GetUnderlyingType(propertyType);
            if (underlyingType != null)
                return null;

            switch (Type.GetTypeCode(propertyType)) {
                case TypeCode.Boolean:
                    return false;

                case TypeCode.DateTime:
                    return new DateTime();

                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return null;

                case TypeCode.String:
                    return string.Empty;

                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return 0;

                case TypeCode.Object:
                default:
                    // We are a struct or some other reference type
                    return GetNaturalZeroValue(propertyType);
            }
        }

        private static object GetNaturalZeroValue(Type type) {
            var prop = type.GetTypeInfo().GetProperty(
                "Zero",
                type,
                Type.EmptyTypes
            );

            if (prop == null && prop.GetMethod != null && prop.GetMethod.IsStatic) {
                return null;
            }

            return prop.GetValue(null, null);
        }
    }
}
