// --------------------------------------------------------------------------
// <copyright file="CustomerGroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Implement
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