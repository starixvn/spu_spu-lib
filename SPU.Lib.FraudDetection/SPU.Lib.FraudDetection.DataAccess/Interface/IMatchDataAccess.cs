namespace FD.Lib.DataAccess.Interface
{
    using System;
    using Fanex.Data.Repository;

    public interface IMatchDataAccess
    {
        object GetMatchList(ICriteria criteria);
    }

    public class MatchDataAccess : IMatchDataAccess
    {
        public object GetMatchList(ICriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}