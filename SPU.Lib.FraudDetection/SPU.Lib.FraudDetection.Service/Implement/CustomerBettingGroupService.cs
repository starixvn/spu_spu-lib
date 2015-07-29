// --------------------------------------------------------------------------
// <copyright file="CustomerBettingGroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.09">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Group Service.
    /// </summary>
    public class CustomerBettingGroupService : QueryService, ICustomerBettingGroupService
    {
        private readonly ICustomerBettingGroupDataAccess _customerBettingGroupDataAccess;

        public CustomerBettingGroupService()
        {
            _customerBettingGroupDataAccess = new CustomerBettingGroupDataAccess();
        }

        public ICommandResult InsertGroup(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.InsertGroup(criteria);
        }

        public ICommandResult DeleteGroup(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.DeleteGroup(criteria);
        }

        public ICommandResult UpdateGroup(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.UpdateGroup(criteria);
        }

        public IEnumerable<CustomerBettingGroup> GetGroups(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.GetGroups(criteria);
        }

        public CustomerBettingGroup GetGroupById(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.GetGroupById(criteria);
        }

        public ICommandResult InsertCustomer(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.InsertCustomer(criteria);
        }

        public ICommandResult DeleteCustomer(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.DeleteCustomer(criteria);
        }

        public Customer GetCustomerByName(ICriteria criteria)
        {
            return _customerBettingGroupDataAccess.GetCustomerByName(criteria);
        }
    }
}
