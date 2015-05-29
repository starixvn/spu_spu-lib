// --------------------------------------------------------------------------
// <copyright file="ActionAssignGroup.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using System.Collections.Generic;
    using SPU.Lib.FraudDetection.Criteria;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service;
    using SPU.Lib.FraudDetection.Criteria.Match;
    using Fanex.NAP.Framework.Command;

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

        private void AssignCustomerGroup()
        {            
            try
            {
                GroupService groupService = new GroupService();

                List<int> custIdList = new List<int>();
                foreach (var info in _suspiciousList)
                {
                    custIdList.Add(info.CustId);
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
            }
            catch (Exception ex)
            {
                throw new Exception("Exception AssignCustomerGroup --", ex);
            }
        }      
    }
}
