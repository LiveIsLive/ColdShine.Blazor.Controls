using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public abstract class SearchItem: Microsoft.AspNetCore.Components.ComponentBase
	{
		[Microsoft.AspNetCore.Components.CascadingParameter]
		public Searcher Searcher { get; set; } = null!;

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("显示名称")]
		public string Title { get; set; } = null!;

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("搜索的字段")]
		public string Property { get; set; } = null!;

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("是否在简单搜索中显示")]
		public bool ShowInSimpleSearcher { get; set; } = true;

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("是否在高级搜索中显示")]
		public bool ShowInAdvanceSearcher { get; set; } = true;

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("简单搜索控件宽度")]
		public virtual int SimpleSearcherWidth { get; set; }

		public abstract System.Collections.Generic.IEnumerable<ColdShine.Blazor.Models.Condition> SimpleSearcherConditions { get; }

		protected override void OnInitialized()
		{
			base.OnInitialized();
			this.Searcher.SearchItems.Add(this);
		}

		public void Dispose()
		{
			this.Searcher.SearchItems.Remove(this);
		}
	}
}