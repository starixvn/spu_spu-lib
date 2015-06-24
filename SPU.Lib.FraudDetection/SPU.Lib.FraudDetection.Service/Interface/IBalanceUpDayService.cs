namespace SPU.Lib.FraudDetection.Service.Interface
{
    using Criteria.SuspiciousStatistic;
    using Implement;

    public interface IBalanceUpDayService
    {
        BalanceUpDayDTO GetBalanceUpDay(BalanceUpDaySelectCriteria criteria);
    }

    public class BalanceUpDayService : QueryService, IBalanceUpDayService
    {
        public BalanceUpDayDTO GetBalanceUpDay(BalanceUpDaySelectCriteria criteria)
        {
            var balanceUpDay = Get<BalanceUpDayDTO>(criteria);

            return balanceUpDay;
        }
    }
}