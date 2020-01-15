//
// - MaxAttribute.cs -
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
    public sealed class MaxAttribute : RangeAttribute {

        public MaxAttribute(int value) : base(Int32.MinValue, value) {}
        public MaxAttribute(object value) : base(null, value) {}
        public MaxAttribute(double value) : base(Double.MinValue, value) {}
        public MaxAttribute(decimal value) : base(Decimal.MinValue, value) {}
        public MaxAttribute(float value) : base(Single.MinValue, value) {}
        public MaxAttribute(long value) : base(long.MinValue, value) {}
        public MaxAttribute(string value) : base(null, value) {}
        public MaxAttribute(byte value) : base(Byte.MinValue, value) {}
        public MaxAttribute(char value) : base(Char.MinValue, value) {}
        public MaxAttribute(short value) : base(short.MinValue, value) {}
        public MaxAttribute(Type type, string value) : base(type, null, value) {}
    }
}
