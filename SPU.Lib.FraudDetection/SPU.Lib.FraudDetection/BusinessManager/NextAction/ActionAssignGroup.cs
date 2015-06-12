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
    using Fanex.NAP.Framework.Command;
    using SPU.Lib.FraudDetection.Criteria;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service.Implement;
    using SPU.Lib.FraudDetection.Service.Interface;   

    /// <summary>
    ///  Assign a suspicious customer to a customer group.
    /// </summary>
    public class ActionAssignGroup : BaseAction
    {
        private List<SuspiciousInfo> _suspiciousList;
        private int _nextActionTargetId = 0;

        public ActionAssignGroup(List<SuspiciousInfo> suspiciousList, int nextActionTargetId)
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

                List<int> custIdList = new List<int>();
                foreach (var info in _suspiciousList)
                {
                    if (!custIdList.Contains(info.CustId))
                    {
                        custIdList.Add(info.CustId);
                    }
                }

                CustomerGroupAssignCriteria criteria = new CustomerGroupAssignCriteria();
                criteria.CreatorId = 0;
                criteria.GroupId = _nextActionTargetId;
                criteria.CustIdList = string.Join(";", custIdList);

                ICommandResult result = groupService.AssignCustToGroup(criteria);
                if (result.IsSuccessful == false)
                {
                    Fanex.Logging.Logger.Log.Error("Error  AssignCustomerGroup : " + result.Message);
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