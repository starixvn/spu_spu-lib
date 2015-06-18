using System;
using RemotingRef;

namespace SPU.Lib.FraudDetection.DTO
{
    public class MatchDetail
    {
        public string SportName { get; set; }

        public string LeagueName { get; set; }

        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public DateTime EventDate { get; set; }

        public int HomeId { get; set; }

        public string HomeName
        {
            get
            {
                return RefData.GetTeamName(HomeId.ToString(), "en", string.Empty);
            } 
        }

        public int AwayId { get; set; }

        public string AwayName
        {
            get
            {
                return RefData.GetTeamName(AwayId.ToString(), "en", string.Empty);
            } 
        }
    }
}