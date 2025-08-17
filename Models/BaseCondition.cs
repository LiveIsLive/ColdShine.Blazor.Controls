using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Models
{
	[System.Text.Json.Serialization.JsonDerivedType(typeof(Condition<string>),"String")]
	[System.Text.Json.Serialization.JsonDerivedType(typeof(Condition<System.DateTime>), "DateTime")]
	[System.Text.Json.Serialization.JsonDerivedType(typeof(Condition<int>),"Integer")]
	public abstract class BaseCondition
	{
		public abstract string VariableName{ get; set; }

		public abstract object GetValue();

		public abstract string GetExpression(bool firstCondition);

		public abstract string GetExpression(int index);
	}
}
