using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	internal interface IWorkDoer
	{
		void DoWork(IWorkProvider workProvider);
	}
}
