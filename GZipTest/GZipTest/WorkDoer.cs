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
		public int ThreadCount { get; }

		private Thread[] _Threads;

		private IWorkProvider _WorkProvider;

		private volatile Exception _Exception;

		public void DoWork(IWorkProvider workProvider)
		{
			if (_WorkProvider != null)
				throw new InvalidOperationException($"This {nameof(WorkDoer)} has already been initialized, create new instance instead.");

			_WorkProvider = workProvider ?? throw new ArgumentNullException(nameof(workProvider));

			_Threads = new Thread[ThreadCount];

			for (int i = 0; i < ThreadCount; i++)
			{
				Thread workThread = new Thread(() => DoWorkOnThread(_WorkProvider));
				workThread.IsBackground = true;
				workThread.Name = $"{workProvider.GetType()}#{i}";
				workThread.Start();

				_Threads[i] = workThread;
			}
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
				Interlocked.CompareExchange(ref _Exception, ex, null);

				Stop();
			}
		}

		public void Stop()
		{
			if (_WorkProvider == null)
				throw new InvalidOperationException($"{nameof(DoWork)} have to be called before work can be stopped");

			_WorkProvider.StopWork();
		}

		public void WaitToEnd()
		{
			if (_WorkProvider == null)
				throw new InvalidOperationException($"{nameof(DoWork)} have to be called before work can be stopped");

			if (_Threads != null)
				foreach (var thread in _Threads)
					thread.Join();

			if (_Exception != null)
				throw _Exception;
		}

		public WorkDoer(int workThreadsCount)
		{
			ThreadCount = workThreadsCount;
		}
	}
}
