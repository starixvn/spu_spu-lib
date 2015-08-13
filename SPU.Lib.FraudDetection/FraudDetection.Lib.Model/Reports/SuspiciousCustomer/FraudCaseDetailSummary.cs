namespace FD.Lib.Model.Reports.SuspiciousCustomer
{
    using RemotingRef;

    public class FraudCaseDetailSummary
    {
        public int CustomerCount { get; set; }

        public int BetCount { get; set; }

        public int HomeId { get; set; }

        public string HomeName
        {
            get { return RefData.GetTeamName(HomeId.ToString(), "en", string.Empty); }
        }

        public int AwayId { get; set; }

        public string AwayName
        {
            get { return RefData.GetTeamName(AwayId.ToString(), "en", string.Empty); }
        }
    }
}