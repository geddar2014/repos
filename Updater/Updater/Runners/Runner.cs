using System;
using System.Threading.Tasks;
using Pathoschild.Http.Client;
using Serilog;
using Updater.Apis.Args;
using Updater.Repositories;
using Updater.UpdateResults;

namespace Updater.Runners
{
	public abstract class Runner<TArgs, TFetchOutput> where TArgs : class, IRunnerArgs where TFetchOutput : class
	{
		protected const string baseUri = "https://1xstavka.ru/StatisticFeed/";

		protected const        int    THREADS    = 16;
		public static readonly object lockObject = new object();

		protected int    _currentStep;
		protected Result _subTotal;
		protected Result _total;
		protected int    _totalSteps;

		protected Runner(Result total = null)
		{
			_subTotal      =  new Result(default(TArgs));
			_total         =  total ?? new Result(default(TArgs));
			RoundCompleted += Runner_RoundCompleted;
			RoundException += Runner_RoundException;
		}

		protected DbInsight _db => new DbInsight();

		public event EventHandler<RoundCompletedEventArgs> RoundCompleted;

		public event EventHandler<RoundExceptionEventArgs> RoundException;

		private void Runner_RoundCompleted(object sender, RoundCompletedEventArgs e)
		{
			var log = UpdateInfo.Compute(_currentStep, _totalSteps, _total.Append(e.Result));
			Log.Information(log);

			Console.WriteLine(log);
		}

		private void Runner_RoundException(object sender, RoundExceptionEventArgs e)
		{
			_total.Append(e.Result);
			var log = e.Exception.Message + "\n\n" + e.Exception.InnerException?.Message;
			Log.Error(log);

			Console.WriteLine(log);
		}

		protected async Task<Result> Elapse(TArgs args = null)
		{
			var result = new Result(args);

			await ProcessAsync(args, result);

			result.Complete();

			_db.ResultRepository.Insert_Results(new[] {result});

			return result;
		}

		protected async Task<TFetchOutput> GetAsync(string url)
		{
			using (var client = new FluentClient(baseUri))
			{
				return await client.GetAsync(url).As<TFetchOutput>();
			}
		}

		protected async Task<T> GetAsync<T>(string url)
		{
			using (var client = new FluentClient(baseUri))
			{
				return await client.GetAsync(url).As<T>();
			}
		}

		protected virtual void NotifyRoundCompleted(Result result)
		{
			var handler = RoundCompleted;

			lock (lockObject)
			{
				if (handler == null) return;

				_currentStep++;

				handler(this, new RoundCompletedEventArgs(result));
			}
		}

		protected virtual void NotifyRoundException(Result result, Exception exception)
		{
			var handler = RoundException;

			lock (lockObject)
			{
				if (handler == null) return;

				_currentStep++;

				handler(this, new RoundExceptionEventArgs(result, exception));
			}
		}

		protected abstract Task ProcessAsync(TArgs args, Result result);

		protected async Task Round(TArgs arg)
		{
			try
			{
				var roundTrip = await Elapse(arg);
				NotifyRoundCompleted(roundTrip);
			}
			catch (Exception ex)
			{
				NotifyRoundException(new Result(arg), ex);
			}
		}

		public abstract Task RunAsync();
	}
}