using ColdShine.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public class DateRangeSearchItem : SearchItem<System.DateTime>
	{
		[Microsoft.AspNetCore.Components.Parameter]
		public System.DateTime? StartDate { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		public Microsoft.AspNetCore.Components.EventCallback<System.DateTime> StartDateChanged { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		public System.DateTime? EndDate { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		public Microsoft.AspNetCore.Components.EventCallback<System.DateTime> EndDateChanged { get; set; }

		public override IEnumerable<Condition<System.DateTime>> SimpleSearcherConditions
		{
			get
			{
				if(this.StartDate!=null)
					yield return new() { Property = this.Property, Operator = ColdShine.Blazor.Models.Operators.GreaterOrEqualOperator, Value = this.StartDate.Value.Date };
				if(this.EndDate!=null)
					yield return new() { Property = this.Property, Operator = ColdShine.Blazor.Models.Operators.LessOperator, Value = this.EndDate.Value.Date.AddDays(1) };
			}
		}
	}
}