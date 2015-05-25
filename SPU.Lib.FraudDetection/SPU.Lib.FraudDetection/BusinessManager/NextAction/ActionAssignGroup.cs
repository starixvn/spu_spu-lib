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

    /// <summary>
    ///  Assign a suspicious customer to a customer group.
    /// </summary>
    public class ActionAssignGroup : BaseAction
    {
        private List<SuspiciousInfo> _assignGroupList;
        public ActionAssignGroup(List<SuspiciousInfo> assignGroupList)
        {
            _assignGroupList = assignGroupList;
        }

        public List<SuspiciousInfo> AssignGroupList
        {
            get { return _assignGroupList; }
            set { _assignGroupList = AssignGroupList; }
        }        

        public override bool TakeAction()
        {
            //CustomerGroupAssignCriteria criteria = new CustomerGroupAssignCriteria(); ////todo

            SuspiciousInfoService suspiciousInfoService = new SuspiciousInfoService();

            SuspiciousInfoInsertCriteria criteria = new SuspiciousInfoInsertCriteria();

            string custIdList = string.Empty;
            string matchIdList = string.Empty;
            string workflowIdList = string.Empty;
            string groupTransIdList = string.Empty;

            foreach (var info in _assignGroupList)
            {
                custIdList = string.Join(";", custIdList, info.CustId);
                matchIdList = string.Join(";", matchIdList, info.MatchId);
                workflowIdList = string.Join(";", workflowIdList, info.WorkflowId);
                groupTransIdList = string.Join(";", groupTransIdList, info.ListTransId);
            }

            criteria.CustIdList = custIdList;
            criteria.MatchIdList = matchIdList;
            criteria.WorkflowIdList = workflowIdList;
            criteria.GroupTransIdList = groupTransIdList;

            return suspiciousInfoService.InsertSuspiciousInfo(criteria).IsSuccessful;

            throw new NotImplementedException();
        }
    }
}
