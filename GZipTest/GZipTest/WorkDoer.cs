using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GZipTest
{
	internal class WorkDoer : IWorkDoer
	{
		private readonly int _WorkThreadsCount;

		private Thread[] _Threads;

		private volatile Exception _Exception;

		public void DoWork(IWorkProvider workProvider)
		{
			_Threads = new Thread[_WorkThreadsCount];

			for (int i = 0; i < _WorkThreadsCount; i++)
			{
				Thread workThread = new Thread(() => DoWorkOnThread(workProvider));
				workThread.IsBackground = true;
				workThread.Name = $"WorkDoer#{i}";
				workThread.Start();

				_Threads[i] = workThread;
			}

			foreach (var thread in _Threads)
				thread.Join();

			if (_Exception != null)
				throw _Exception;
		}

		private void DoWorkOnThread(IWorkProvider workProvider)
		{
			try
			{
				Action work = workProvider.GetWork();
				work();
			}
			catch (Exception ex)
			{
				Interlocked.CompareExchange<Exception>(ref _Exception, ex, null);

				workProvider.StopWork();
			}
		}

		public WorkDoer(int workThreadsCount)
		{
			_WorkThreadsCount = workThreadsCount;
		}
	}
}
