using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTest
{
	interface IWorkProvider
	{
		Action GetWork();
		void StopWork();
	}
}
