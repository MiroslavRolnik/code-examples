using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	internal interface IDriver
	{
		#region Box

		void UnLock(BoxHw box);

		#endregion

		#region Module

		StateResponse GetState(Module module);

		#endregion

		#region Driver

		void Init(Driver driver);

		void Deinit();

		#endregion
	}
}
