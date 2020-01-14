//
// - LessThanAttribute.cs -
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
using System.ComponentModel;
using System.Reflection;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(AbstractValidatorAttribute.COMMON_TARGETS, AllowMultiple = true, Inherited = true)]
    public sealed class LessThanAttribute : CompareAttribute {

        public LessThanAttribute(int value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(object value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(double value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(decimal value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(float value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(long value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(string value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(byte value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(char value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(short value) : base(ComparisonOperator.GreaterThan, value) {}
        public LessThanAttribute(Type type, string value) : base(ComparisonOperator.GreaterThan, type, value) {}

    }
}