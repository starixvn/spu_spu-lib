using System.Collections.Generic;
using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;
using SPU.Lib.FraudDetection.DTO;

namespace SPU.Lib.FraudDetection.Service.Interface
{
    public interface IMatchService
    {
        IEnumerable<MatchDetail> GetMatchDetails(MatchSelectCriteria criteria);
    }
}