namespace FD.Lib.DTO
{
    using System;
    using System.Collections.Generic;

    public class LiveMatchMonitoring
    {
        public LiveMatchMonitoring()
        {
            SuspiciousCases = new Dictionary<string, int>();

            ScannedStatus = 0;
        }

        public int MatchId { get; set; }

        public string LeagueName { get; set; }

        public string MatchCode { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public DateTime KickOffTime { get; set; }

        public int LiveHomeScore { get; set; }

        public int LiveAwayScore { get; set; }

        public string Event { get; set; }

        public string EventStatus { get; set; }

        public bool? IsVerified { get; set; }

        public string LastVerifiedBy { get; set; }

        public DateTime? LastVerifiedDate { get; set; }

        public int ScannedStatus { get; set; }

        public bool IsPlayingMatch
        {
            get
            {
                return KickOffTime < DateTime.Now;
            }
        }

        public Dictionary<string, int> SuspiciousCases;
    }
}
