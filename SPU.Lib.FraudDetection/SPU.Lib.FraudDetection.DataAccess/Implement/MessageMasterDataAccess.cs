namespace FD.Lib.DataAccess.Implement
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using FD.Lib.DataAccess.Interface;

    public class MessageMasterDataAccess : BaseDataAccess, IMessageMasterDataAccess
    {
        public ICommandResult Insert(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult Update(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult Delete(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
