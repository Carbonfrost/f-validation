//
// - GreaterThanAttribute.cs -
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
	public sealed class GreaterThanAttribute : CompareAttribute {

	    public GreaterThanAttribute(int value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(object value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(double value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(decimal value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(float value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(long value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(string value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(byte value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(char value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(short value) : base(ComparisonOperator.GreaterThan, value) {}
	    public GreaterThanAttribute(Type type, string value) : base(ComparisonOperator.GreaterThan, type, value) {}
	}
}
