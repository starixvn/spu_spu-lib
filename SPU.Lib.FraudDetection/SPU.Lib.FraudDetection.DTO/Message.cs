namespace FD.Lib.DTO
{
    public class Message
    {
        public int MessageId { get; set; }

        public string MessageContent { get; set; }

        public bool IsViewed { get; set; }

        public int TaskId { get; set; }

        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public string CaseName { get; set; }
    }
}
