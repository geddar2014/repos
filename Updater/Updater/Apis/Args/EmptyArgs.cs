namespace Updater.Apis.Args
{
	public class EmptyArgs : IRunnerArgs
	{
		protected EmptyArgs()
		{
		}

		public IRunnerArgs Create(params object[] parameters)
		{
			return new EmptyArgs();
		}

		public static EmptyArgs Create()
		{
			return (EmptyArgs) new EmptyArgs().Create((object) null);
		}
	}
}