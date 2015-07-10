// --------------------------------------------------------------------------
// <copyright file="CustomerBettingGroupDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.09">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using DTO;
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Group Data Access Implement.
    /// </summary>
    public class CustomerBettingGroupDataAccess : BaseDataAccess, ICustomerBettingGroupDataAccess
    {
        public ICommandResult InsertGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult AssignCustToGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult InsertCustomer(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteCustomer(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public Customer GetCustomerByName(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                var customers = db.Query<Customer, Currency, Customer>(
                    (cust, curr) =>
                    {
                        cust.Currency = curr;

                        return cust;
                    },
                    "CurrencyId",
                    criteria.GetSpParams());

                return customers.FirstOrDefault();
            }
        }

        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The list of groups.</returns>
        public IEnumerable<CustomerBettingGroup> GetGroups(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var groups = multi.Read<CustomerBettingGroup>();
                    var groupDetails = multi.Read<dynamic>();
                    var result = AddCustomersToGroup(groups, groupDetails);

                    return result;
                }
            }
        }

        /// <summary>
        /// Get group by ID.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The group.</returns>
        public CustomerBettingGroup GetGroupById(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var groups = multi.Read<CustomerBettingGroup>();
                    var groupDetails = multi.Read<dynamic>();
                    var result = AddCustomersToGroup(groups, groupDetails);

                    return result.FirstOrDefault();
                }
            }
        }

        /// <summary>
        /// Add customers to groups.
        /// </summary>
        /// <param name="groups">The groups.</param>
        /// <param name="groupDetails">The group details.</param>
        /// <returns>List of group.</returns>
        private IEnumerable<CustomerBettingGroup> AddCustomersToGroup(
            IEnumerable<CustomerBettingGroup> groups,
            IEnumerable<dynamic> groupDetails)
        {
            var result = new List<CustomerBettingGroup>();
            foreach (var group in groups)
            {
                foreach (var groupDetail in groupDetails)
                {
                    if (group.GroupId == groupDetail.GroupId)
                    {
                        var customer = new Customer
                        {
                            CustId = groupDetail.CustId,
                            CustName = groupDetail.CustName,
                            Currency = new Currency
                            {
                                CurrencyId = groupDetail.CurrencyId,
                                CurrencyName = groupDetail.CurrencyName
                            }
                        };

                        group.Customers.Add(customer);
                    }
                }

                result.Add(group);
            }

            return result;
        }
    }
}