namespace FD.Lib.Model.Reports.BettingGroup
{
    using System;
    using RemotingRef;

    public class AssociationCustomer
    {
        public DateTime EventDate { get; set; }

        public string EventDateStr
        {
            get { return EventDate.ToString("MM/dd/yyyy"); }
        }

        public long HomeId { get; set; }

        public string HomeName
        {
            get { return RefData.GetTeamName(HomeId.ToString(), "en", string.Empty); }
        }

        public int AwayId { get; set; }

        public string AwayName
        {
            get { return RefData.GetTeamName(AwayId.ToString(), "en", string.Empty); }
        }

        public string AssociationMembers { get; set; }

        public decimal WinLoss { get; set; }

        public string Ip { get; set; }
    }
}