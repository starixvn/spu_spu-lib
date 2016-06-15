namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using Fanex.Data.Repository;

    public class CustomerDetailsReportTicketsByIpCriteria : CriteriaBase
    {
        public string Ip { get; set; }

        public override string GetSettingKey()
        {
            return "FD_CustomerDetailsTicketsGetByIP";
        }

        public override bool IsValid()
        {
            return Ip != string.Empty;
        }
    }
}
