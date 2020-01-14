//
// - MinAttribute.cs -
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

using Carbonfrost.Commons.Core;

namespace Carbonfrost.Commons.Validation {

    [AttributeUsage(AbstractValidatorAttribute.COMMON_TARGETS, AllowMultiple = false, Inherited = true)]
    public sealed class MinAttribute : RangeAttribute {
        public MinAttribute(int value) : base(value, Int32.MaxValue) {}
        public MinAttribute(object value) : base(value, null) {}
        public MinAttribute(double value) : base(value, Double.MaxValue) {}
        public MinAttribute(decimal value) : base(value, Decimal.MaxValue) {}
        public MinAttribute(float value) : base(value, Single.MaxValue) {}
        public MinAttribute(long value) : base(value, long.MaxValue) {}
        public MinAttribute(string value) : base(value, null) {}
        public MinAttribute(byte value) : base(value, Byte.MaxValue) {}
        public MinAttribute(char value) : base(value, Char.MaxValue) {}
        public MinAttribute(short value) : base(value, short.MaxValue) {}
        public MinAttribute(Type type, string value) : base(type, value, null) {}
    }
}
