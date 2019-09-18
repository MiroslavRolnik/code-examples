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

		private object _ExceptionLock = new object();

		public void DoWork(Action action)
		{
			_Threads = new Thread[_WorkThreadsCount];

			for (int i = 0; i < _WorkThreadsCount; i++)
			{
				Thread workThread = new Thread(() => DoWorkOnThread(action));
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

		private void DoWorkOnThread(Action action)
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
				bool hasBeenAlreadyThrown = false;

				lock (_ExceptionLock)
				{
					hasBeenAlreadyThrown = _Exception != null;
					_Exception = hasBeenAlreadyThrown ? _Exception : ex;
				}

				if (!hasBeenAlreadyThrown)
					foreach (Thread thread in _Threads)
						if (thread != Thread.CurrentThread && thread.IsAlive)
							thread.Abort();
			}
		}

		public WorkDoer(int workThreadsCount)
		{
			_WorkThreadsCount = workThreadsCount;
		}
	}
}
