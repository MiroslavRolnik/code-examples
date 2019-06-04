using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P4U.Peri.BoxBoardKerong.Implementation.None
{
	public class BoxNone: BoxBoardKerongController
	{
		protected override string Type
		{
			get => "None";
		}

		protected override void OpenBoxInternal(byte boxAddress, string ipAddress, int port)
		{
		}

		protected override bool IsBoxOpenInternal(byte boxAddress, string ipAddress, int port)
		{
			return false;
		}
	}
}
