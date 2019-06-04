using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	/// <summary>
	/// Kolekce interních chyb modulu.
	/// </summary>
	public class InternalHWModuleErrorCollection : List<InternalHWModuleError>
	{
		public string GetDescription()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var item in this)
			{
				sb.AppendLine(item.GetDesription());
			}

			return sb.ToString();
		}
	}
}
