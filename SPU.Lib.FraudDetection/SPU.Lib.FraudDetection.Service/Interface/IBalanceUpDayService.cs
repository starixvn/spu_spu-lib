using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;
using SPU.Lib.FraudDetection.Service.Implement;

namespace SPU.Lib.FraudDetection.Service.Interface
{
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