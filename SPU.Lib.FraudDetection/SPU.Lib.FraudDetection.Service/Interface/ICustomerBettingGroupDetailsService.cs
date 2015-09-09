// --------------------------------------------------------------------------
// <copyright file="ICustomerBettingGroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.09">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.CustomerBettingGroup;
    using Criteria.CustomerBettingGroupDetails;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     ICustomerBettingGroupService interface.
    /// </summary>
    public interface ICustomerBettingGroupDetailsService
    {
        IList<int> GetRelatedBettingGroups(RelatedBettingGroupGetCriteria criteria);

        ICommandResult InsertCustomersIntoBettingGroup(CustomersIntoBettingGroupInsertCriteria criteria);

        void MergeCustomerBettingGroups(CustomerBettingGroupsMergeCriteria criteria);
    }
}
