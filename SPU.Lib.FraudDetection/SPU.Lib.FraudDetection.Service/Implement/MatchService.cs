using System.Collections.Generic;
using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.Service.Implement
{
    public class MatchService : QueryService, IMatchService
    {
        public IEnumerable<MatchDetail> GetMatchDetails(MatchSelectCriteria criteria)
        {
            return GetData<MatchDetail>(criteria);
        }
    }
}