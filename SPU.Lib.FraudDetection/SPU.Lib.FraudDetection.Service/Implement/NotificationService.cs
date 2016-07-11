namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Interface;
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;

    public class NotificationService : QueryService, INotificationService
    {
        public ICommandResult InsertUserMessage(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult InsertUserAction(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public IEnumerable<int> GetUsersOnline(ICriteria criteria)
        {
            return GetData<int>(criteria);
        }
    }
}