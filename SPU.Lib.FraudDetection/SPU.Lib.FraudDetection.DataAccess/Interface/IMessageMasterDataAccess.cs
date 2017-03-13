namespace FD.Lib.DataAccess.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    public interface IMessageMasterDataAccess
    {
        ICommandResult Insert(ICriteria criteria);

        ICommandResult Update(ICriteria criteria);

        ICommandResult Delete(ICriteria criteria);
    }
}
