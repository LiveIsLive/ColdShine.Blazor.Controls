using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Models
{
	public class ConditionCollection : System.Collections.Generic.List<Condition>
	{
		//public record Customer(string Name,int Age);

		public const string ItemsVariableName = "item";

		public System.Collections.Generic.IEnumerable<T> Where<T>(System.Collections.Generic.IEnumerable<T> items)
		{
			//var interpreter = new DynamicExpresso.Interpreter(DynamicExpresso.InterpreterOptions.Default | DynamicExpresso.InterpreterOptions.LambdaExpressions);
			System.Collections.Generic.List<DynamicExpresso.Parameter> parameters = new();
			parameters.Add(new(nameof(items), items));
			parameters.AddRange(this.Select(i => new DynamicExpresso.Parameter(i.VariableName, i.Value)));
			return new DynamicExpresso.Interpreter(DynamicExpresso.InterpreterOptions.Default | DynamicExpresso.InterpreterOptions.LambdaExpressions).Eval<System.Collections.Generic.IEnumerable<T>>($"{nameof(items)}.Where({ItemsVariableName}=>{string.Join("",string.Join("",this.Select((item,index)=>item.GetExpression(index))))})", parameters.ToArray());
		}
	}
}