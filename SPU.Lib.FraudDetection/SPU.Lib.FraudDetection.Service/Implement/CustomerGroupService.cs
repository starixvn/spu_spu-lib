namespace SPU.Lib.FraudDetection.Service.Implement
{
    using DataAccess.Implement;
    using DataAccess.Interface;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    public class CustomerGroupService : QueryService, ICustomerGroupService
    {
        private readonly IGroupDataAccess _groupDataAccess;

        public CustomerGroupService()
        {
            _groupDataAccess = new GroupDataAccess();
        }
        public ICommandResult InsertCustomerGroup(ICriteria criteria)
        {
            return _groupDataAccess.AssignCustToGroup(criteria);
        }
    }
}