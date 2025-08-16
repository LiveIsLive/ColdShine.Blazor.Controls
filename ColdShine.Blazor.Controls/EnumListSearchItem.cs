using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdShine.Blazor.Controls
{
	public class EnumListSearchItem<ValueType> : ValueTypeListSearchItem<ValueType?> where ValueType : struct
	{
		private IEnumerable<ValueType?> _Data = null!;
		public override required IEnumerable<ValueType?> Data
		{
			get
			{
				if (this._Data == null)
					this._Data = new ValueType?[] { null }.Concat(System.Enum.GetValues(typeof(ValueType)).Cast<ValueType>().Select(v=>new ValueType?(v))).ToArray();
				return this._Data;
			}
			set
			{
				this._Data = value;
			}
		}
	}
}