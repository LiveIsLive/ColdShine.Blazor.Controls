using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Models
{
	public class Condition<ValueType>: BaseCondition
	{
		[System.ComponentModel.Description("搜索的字段")]
		public string Property { get; set; } = null!;

		private int _OperatorId;
		public int OperatorId
		{
			get
			{
				return this._OperatorId;
			}
			set
			{
				this._OperatorId = value;
				this._Operator = null!;
				this._Expression = null!;
				//this._Parameters = null;
			}
		}

		public bool LeftBracket { get; set; }

		public bool RightBracket { get; set; }

		public LogicalConnective Connective { get; set; }

		//public ValueType ValueType { get; set; }

		public required ValueType Value { get; set; }

		private Operator _Operator = null!;
		[System.Text.Json.Serialization.JsonIgnore]
		public Operator Operator
		{
			get
			{
				if (this._Operator == null)
					this._Operator = Operators.AllOperators.First(p => p.OperatorId == this.OperatorId);
				return this._Operator;
			}
			set
			{
				this._OperatorId = value.OperatorId;
				this._Operator = value;
				this._Expression = null!;
			}
		}

		protected static int VariableIndex;

		//protected readonly string PropertyVariableName = "P" + VariableIndex++;

		private string _VariableName = null!;
		public override string VariableName
		{
			get
			{
				if(this._VariableName==null)
					this._VariableName = "V" + VariableIndex++;
				return this._VariableName;
			}
			set
			{
				this._VariableName = value;
			}
		}

		public static readonly System.Collections.ObjectModel.ReadOnlyDictionary<LogicalConnective, string> Connectives = new System.Collections.ObjectModel.ReadOnlyDictionary<LogicalConnective, string>(new Dictionary<LogicalConnective, string>() { { LogicalConnective.And, "&&" }, { LogicalConnective.Or, "||" } });

		private string _Expression = null!;
		[System.Text.Json.Serialization.JsonIgnore]
		public string Expression
		{
			get
			{
				if (this._Expression == null)
				{
					//this._Expression = Connectives[this.Connective];
					if (this.LeftBracket)
						this._Expression += "(";
					this._Expression += string.Format(this.Operator.Expression, ConditionCollection.ItemVariableName + "." + this.Property, this.VariableName);
					//this._Expression += string.Format(this.Operator.Expression, this.PropertyVariableName, this.ValueVariableName);
					if (this.RightBracket)
						this._Expression += ")";
				}
				return this._Expression;
			}
		}


		public override string GetExpression(bool firstCondition)
		{
			if (firstCondition)
				return this.Expression;
			return " " + Connectives[this.Connective] + " " + this.Expression;
		}

		public override string GetExpression(int index)
		{
			return this.GetExpression(index == 0);
		}

		public override object GetValue()
		{
			return this.Value!;
		}
	}
}