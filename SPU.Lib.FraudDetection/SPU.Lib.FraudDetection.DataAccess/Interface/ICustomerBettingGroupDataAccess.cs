// --------------------------------------------------------------------------
// <copyright file="ICustomerBettingGroupDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.09">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Group Data Access Interface.
    /// </summary>
    public interface ICustomerBettingGroupDataAccess
    {
        ICommandResult InsertGroup(ICriteria criteria);

        ICommandResult InsertCustomer(ICriteria criteria);

        ICommandResult DeleteCustomer(ICriteria criteria);

        IEnumerable<CustomerBettingGroup> GetGroups(ICriteria criteria);

        CustomerBettingGroup GetGroupById(ICriteria criteria);

        ICommandResult UpdateGroup(ICriteria criteria);

        ICommandResult DeleteGroup(ICriteria criteria);
    }
}