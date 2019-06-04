//#define EXTRA_LOG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation.Implementation.None
{
	internal class Driver : IDriver
	{
		#region IDriver Members

		public void Init(BoxArrayImplementation.Driver driver)
		{
		}

		public void Deinit()
		{
		}

		public void UnLock(BoxHw box)
		{
		}		

		public StateResponse GetState(Module module)
		{			
			return new StateResponse();
		}

		#endregion
	}
}
