namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using Fanex.Data.Repository;

    public class BetTicketByIpCriteria : CriteriaBase
    {
        public string Ip { get; set; }

        public override string GetSettingKey()
        {
            return "FD_BetTicketGetByIp";
        }

        public override bool IsValid()
        {
            return Ip != string.Empty;
        }
    }
}
