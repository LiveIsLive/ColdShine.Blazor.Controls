using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public abstract class BaseSearchItem : Microsoft.AspNetCore.Components.ComponentBase,System.IDisposable
	{
		[Microsoft.AspNetCore.Components.CascadingParameter(Name = "SearchItems")]
		public required System.Collections.Generic.List<BaseSearchItem> SearcherItems { get; set; }


		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("显示名称")]
		public required string Title { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("搜索的字段")]
		public required string Property { get; set; }

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("是否在简单搜索中显示")]
		public bool ShowInSimpleSearcher { get; set; } = true;

		[Microsoft.AspNetCore.Components.Parameter]
		[System.ComponentModel.Description("是否在高级搜索中显示")]
		public bool ShowInAdvanceSearcher { get; set; } = true;

		/*private static int _NewControlId;
		protected int NewControlId { get => _NewControlId; set => _NewControlId = value; }*/
		private static int NewControlId;

		private string _TextBoxName = null!;
		protected string TextBoxName
		{
			get
			{
				if (this._TextBoxName == null)
					this._TextBoxName = "SimpleTextInputName" + NewControlId++;
				return this._TextBoxName;
			}
		}

		//[Microsoft.AspNetCore.Components.Parameter]
		//[System.ComponentModel.Description("简单搜索控件宽度")]
		//public virtual int? TextBoxWidth { get; set; }

		public abstract System.Collections.Generic.IEnumerable<ColdShine.Blazor.Models.BaseCondition> GetSimpleSearcherConditions();

		//protected string? AddParentItems()
		//{
		//	this.SearcherItems?.Add(this);
		//	return null;
		//}

		public abstract void ResetValue();

		protected override void OnInitialized()
		{
			this.SearcherItems.Add(this);
			base.OnInitialized();
		}

		public void Dispose()
		{
			this.SearcherItems.Remove(this);
		}
	}
}