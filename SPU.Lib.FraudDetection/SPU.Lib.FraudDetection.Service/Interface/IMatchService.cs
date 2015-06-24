namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.SuspiciousStatistic;
    using DTO;

    public interface IMatchService
    {
        IEnumerable<MatchDetail> GetMatchDetails(MatchSelectCriteria criteria);
    }
}