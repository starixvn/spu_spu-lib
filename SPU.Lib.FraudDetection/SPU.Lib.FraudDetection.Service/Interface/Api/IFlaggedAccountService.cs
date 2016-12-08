namespace FD.Lib.Service.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    public interface IFlaggedAccountService
    {
        ICommandResult InsertAccounts(ICriteria criteria);

        ICommandResult DeleteAccounts(ICriteria criteria);
    }
}