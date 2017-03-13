namespace FD.Lib.Service.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    public class FlaggedAccountService : QueryService, IFlaggedAccountService
    {
        public ICommandResult InsertAccounts(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteAccounts(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}