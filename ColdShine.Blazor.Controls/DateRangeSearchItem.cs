using ColdShine.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public class DateRangeSearchItem : SearchItem
	{
		[Microsoft.AspNetCore.Components.Parameter]
		public System.DateTime? StartDate { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		public Microsoft.AspNetCore.Components.EventCallback<System.DateTime> StartDateChanged { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		public System.DateTime? EndDate { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		public Microsoft.AspNetCore.Components.EventCallback<System.DateTime> EndDateChanged { get; set; }

		public override IEnumerable<Condition> SimpleSearcherConditions => throw new NotImplementedException();
	}
}