// --------------------------------------------------------------------------
// <copyright file="ActionAssignGroup.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager.NextAction
{
    using System;
    using System.Collections.Generic;
    using Criteria;
    using DTO;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    ///     Assign a suspicious customer to a customer group.
    /// </summary>
    public class ActionAssignGroup : BaseAction
    {
        private readonly int _nextActionTargetId;
        private readonly IList<SuspiciousInfo> _suspiciousList;

        public ActionAssignGroup(IList<SuspiciousInfo> suspiciousList, int nextActionTargetId)
        {
            _suspiciousList = suspiciousList;
            _nextActionTargetId = nextActionTargetId;
        }

        public override void TakeAction()
        {
            AssignCustomerGroup();
        }

        private bool AssignCustomerGroup()
        {
            try
            {
                IGroupService groupService = new GroupService();

                var custIdList = new List<int>();
                foreach (var info in _suspiciousList)
                {
                    if (!custIdList.Contains(info.CustId))
                    {
                        custIdList.Add(info.CustId);
                    }
                }

                var criteria = new CustomerGroupAssignCriteria();
                criteria.CreatorId = 0;
                criteria.GroupId = _nextActionTargetId;
                criteria.CustIdList = string.Join(";", custIdList);

                var result = groupService.AssignCustToGroup(criteria);
                if (result.IsSuccessful == false)
                {
                    Logger.Log.Error("Error  AssignCustomerGroup : " + result.Message);
                }

                return result.IsSuccessful;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception AssignCustomerGroup --" + ex.Message);
            }
        }
    }
}