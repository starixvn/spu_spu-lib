using Fanex.Data.Repository;

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    public interface IMatchDataAccess
    {
        object GetMatchList(ICriteria criteria);
    }

    public class MatchDataAccess : IMatchDataAccess
    {
        public object GetMatchList(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}