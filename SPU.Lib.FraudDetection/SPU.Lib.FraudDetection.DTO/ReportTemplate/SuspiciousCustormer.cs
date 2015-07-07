namespace SPU.Lib.FraudDetection.DTO.ReportTemplate
{
    using System;

    public class SuspiciousCustormer
    {
        public string Member { get; set; }
        public string Case { get; set; }
        public string Sport { get; set; }
        public string League { get; set; }
        public int MatchId { get; set; }
        public string MatchCode { get; set; }
        public DateTime EventDate { get; set; }
        public string Event { get; set; }
    }
}