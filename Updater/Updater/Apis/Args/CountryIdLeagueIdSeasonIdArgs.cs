namespace Updater.Apis.Args
{
    public class CountryIdLeagueIdSeasonIdArgs : IRunnerArgs
    {
        protected CountryIdLeagueIdSeasonIdArgs()
        {
        }

        private CountryIdLeagueIdSeasonIdArgs(string xCountryId, string xLeagueId, string xSeasonId)
        {
            XCountryId = xCountryId;
            XLeagueId  = xLeagueId;
            XSeasonId  = xSeasonId;
        }

        public string XCountryId { get; protected set; }

        public string XLeagueId { get; protected set; }

        public string XSeasonId { get; protected set; }

        public static IRunnerArgs Create(params object[] parameters)
        {
            return new CountryIdLeagueIdSeasonIdArgs((string) parameters[0], (string) parameters[1],
                                                     (string) parameters[2]);
        }

        //public static CountryIdLeagueIdSeasonIdArgs Create(string xCountryId, string xLeagueId, string xSeasonId)
        //{
        //    return (CountryIdLeagueIdSeasonIdArgs) Create(xCountryId, xLeagueId, xSeasonId);
       // }
    }
}