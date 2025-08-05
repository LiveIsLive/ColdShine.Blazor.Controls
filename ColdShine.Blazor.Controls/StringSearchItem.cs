using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public class StringSearchItem : SearchItem
	{
		[Microsoft.AspNetCore.Components.Parameter]
		public string? Value { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		public Microsoft.AspNetCore.Components.EventCallback<string> ValueChanged { get; set; }

		public override IEnumerable<ColdShine.Blazor.Models.Condition> SimpleSearcherConditions
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.Value))
					yield break;
				yield return new(){ Property = this.Property, Operator = ColdShine.Blazor.Models.Operators.ContainsOperator, Value = this.Value.Trim() };
			}
		}
	}
}