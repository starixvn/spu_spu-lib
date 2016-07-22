namespace FD.Lib.DTO
{
    using System;
    using RemotingRef;
    using Fanex.BetList.Core.TicketHelper;

    public class Message
    {
        public int MessageId { get; set; }

        public string MessageContent { get; set; }

        public bool IsViewed { get; set; }

        public int TaskId { get; set; }

        public int CaseId { get; set; }

        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public string CaseName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UnreadMsgCount { get; set; }

        public DateTime EventDate { get; set; }

        public string EventDateFormat
        {
            get
            {
                return EventDate.ToString("MM/dd/yyyy");
            }
        }

        public string PostedDate
        {
            get
            {
                return CreatedDate.ToString("MM/dd/yyyy HH:mm:ss");
            }
        }

        public string Event { 
            get
            {
                return CacheRef.GetTeamName(HomeId) + " - vs - " + CacheRef.GetTeamName(AwayId);
            }
        }
    }
}
