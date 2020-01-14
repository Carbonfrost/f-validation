//
// - CompareAttribute.cs -
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
using System.Reflection;
using Carbonfrost.Commons.Core.Runtime;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(AbstractValidatorAttribute.COMMON_TARGETS, AllowMultiple = true, Inherited = true)]
    public class CompareAttribute : AbstractValidatorAttribute {

        private readonly ComparisonOperator comparison;
        private readonly object value;

        internal static readonly object ZeroValue = new object();

        public ComparisonOperator Comparison { get { return comparison; } }
        public object Value { get { return value; } }

        public CompareAttribute(ComparisonOperator comparison, int value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, object value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, double value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, decimal value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, float value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, long value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, string value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, byte value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, char value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, short value) {
            this.comparison = comparison;
            this.value = value;
        }

        public CompareAttribute(ComparisonOperator comparison, Type type, string value) {
            if (type == null)
                throw new ArgumentNullException("type");

            this.comparison = comparison;
            this.value = Activation.FromText(type, value);
        }

        protected override Validator CreateValidatorCore() {
            throw new NotImplementedException();
            // return new RangeValidator();
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
            PropertyInfo propertyInfo0
                = type.GetTypeInfo().GetProperty(
                    "Zero", // $NON-NLS-1
                    type, Type.EmptyTypes);

            if (propertyInfo0 == null && propertyInfo0.GetMethod != null && propertyInfo0.GetMethod.IsStatic)
                return null;

            else
                return propertyInfo0.GetValue(null, null);
        }
    }
}
