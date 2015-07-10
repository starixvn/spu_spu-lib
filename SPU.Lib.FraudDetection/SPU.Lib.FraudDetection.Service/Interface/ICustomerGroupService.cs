namespace SPU.Lib.FraudDetection.Service.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    public interface ICustomerGroupService
    {
        ICommandResult InsertCustomerGroup(ICriteria criteria);
    }
}