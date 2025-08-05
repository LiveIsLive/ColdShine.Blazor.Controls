using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Models
{
	public static class Operators
	{
		private static Operator[] _StringOperators = null!;
		public static Operator[] StringOperators
		{
			get
			{
				if (_StringOperators == null)
					_StringOperators = new Operator[]
					{
						new Operator(101,"包含","{0}.Contains({1})"),
						new Operator(102,"不包含","!{0}.Contains({1})"),
						new Operator(103,"等于","{0}=={1}"),
						new Operator(104,"始于","{0}.StartsWith({1})"),
						new Operator(105,"非始于","!{0}.StartsWith({1})"),
						new Operator(106,"终于","{0}.EndsWith({1})"),
						new Operator(107,"非终于","!{0}.EndsWith({1})")
					};
				return _StringOperators;
			}
		}

		private static Operator[] _DecimalOperators = null!;
		public static Operator[] DecimalOperators
		{
			get
			{
				if (_DecimalOperators == null)
					_DecimalOperators = new Operator[]
					{
						new Operator(201,">","{0}>{1}"),
						new Operator(201,"≥","{0}>={1}"),
						new Operator(201,"<","{0}<{1}"),
						new Operator(201,"≤","{0}<={1}"),
						new Operator(201,"=","{0}={1}"),
						new Operator(201,"≠","{0}!={1}")
					};
				return _DecimalOperators;
			}
		}


		public static readonly Operator[] AllOperators = StringOperators.Concat(DecimalOperators).ToArray();

		public static readonly Operator ContainsOperator = StringOperators.First(o => o.Name == "包含");

		public static readonly Operator GreaterOrEqualOperator = DecimalOperators.First(o => o.Name == "≥");

		public static readonly Operator LessOperator = DecimalOperators.First(o => o.Name == "<");
	}
}