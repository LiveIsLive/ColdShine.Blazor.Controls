using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdShine.Blazor.Models
{
	[System.ComponentModel.Description("高级查询框中的操作符选项")]
	public class Operator
	{
		public int OperatorId { get; set; }

		[System.ComponentModel.Description("操作符名称")]
		public string Name { get; set; }

		[System.ComponentModel.Description("搜索代码，包含{0}表示被搜索属性名、{1}表示搜索值")]
		public string Expression { get; set; }

		public Operator(int operatorId, string name, string expression)
		{
			this.OperatorId = operatorId;
			this.Name = name;
			this.Expression = expression;
		}
	}
}
