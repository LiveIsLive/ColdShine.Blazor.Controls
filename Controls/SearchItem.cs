using ColdShine.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public abstract class SearchItem<T>: BaseSearchItem
	{
		public abstract System.Collections.Generic.IEnumerable<ColdShine.Blazor.Models.Condition<T>> SimpleSearcherConditions { get; }

		public override IEnumerable<BaseCondition> GetSimpleSearcherConditions()=>this.SimpleSearcherConditions.Cast<BaseCondition>();
	}
}