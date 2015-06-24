namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Interface;

    public class MatchService : QueryService, IMatchService
    {
        public IEnumerable<MatchDetail> GetMatchDetails(MatchSelectCriteria criteria)
        {
            return GetData<MatchDetail>(criteria);
        }
    }
}