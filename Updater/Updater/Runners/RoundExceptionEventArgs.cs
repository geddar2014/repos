using System;
using Updater.UpdateResults;

namespace Updater.Runners
{
	public class RoundExceptionEventArgs : EventArgs
	{
		public RoundExceptionEventArgs(Result result, Exception exception)
		{
			Result = result;

			Exception = exception;
		}

		public Result Result { get; }

		public Exception Exception { get; }
	}
}