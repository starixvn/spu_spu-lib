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
    using System.Linq;
    using Criteria.CustomerBettingGroup;
    using Criteria.CustomerBettingGroupDetails;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Group Service.
    /// </summary>
    public class CustomerBettingGroupDetailsService : QueryService, ICustomerBettingGroupDetailsService
    {
        public IList<int> GetRelatedBettingGroups(RelatedBettingGroupGetCriteria criteria)
        {
            return GetData<int>(criteria).ToList();
        }

        public ICommandResult InsertCustomersIntoBettingGroup(CustomersIntoBettingGroupInsertCriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public void MergeCustomerBettingGroups(CustomerBettingGroupsMergeCriteria criteria)
        {
            ExecuteNonQuery(criteria);
        }
    }
}
