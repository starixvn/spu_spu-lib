namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    using RemotingRef;

    public class FraudCaseDetailSummary
    {
        public int CustomerCount { get; set; }

        public int BetCount { get; set; }

        public int HomeId { get; set; }

        public string TransList { get; set; }

        public string HomeName
        {
            get
            {
                if (HomeId <= 0)
                {
                    return string.Empty;
                }

                return RefData.GetTeamName(HomeId.ToString(), "en", string.Empty);
            }
        }

        public int AwayId { get; set; }

        public string AwayName
        {
            get
            {
                if (AwayId <= 0)
                {
                    return string.Empty;
                }

                return RefData.GetTeamName(AwayId.ToString(), "en", string.Empty);
            }
        }
    }
}