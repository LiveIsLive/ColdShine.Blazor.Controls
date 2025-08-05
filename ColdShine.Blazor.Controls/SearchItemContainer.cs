using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public class SearchItemContainer : Microsoft.AspNetCore.Components.ComponentBase
	{
		public System.Collections.Generic.List<SearchItem> Items { get; } = new();
	}
}