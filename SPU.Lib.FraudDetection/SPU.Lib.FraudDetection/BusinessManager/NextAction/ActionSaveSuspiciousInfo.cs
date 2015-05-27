// --------------------------------------------------------------------------
// <copyright file="ActionSaveSuspiciousInfo.cs" company="Nexcel Solutions Vietnam">
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

    /// <summary>
    ///  Save suspicious info.
    /// </summary>
    public class ActionSaveSuspiciousInfo : BaseAction
    {
        private List<SuspiciousInfo> _suspiciousInfoList;

        public ActionSaveSuspiciousInfo(List<SuspiciousInfo> suspiciousInfoList)
        {
            _suspiciousInfoList = suspiciousInfoList;
        }

        public List<SuspiciousInfo> AssignGroupList
        {
            get { return _suspiciousInfoList; }
            set { _suspiciousInfoList = AssignGroupList; }
        }        

        public override bool TakeAction()
        {            
            return UpdateScannedMatch() && InsertSuspiciousInfo() ;// && AssignCustomerGroup();
        }

        private bool AssignCustomerGroup()
        {
            GroupService groupService = new GroupService();
            CustomerGroupAssignCriteria criteria = new CustomerGroupAssignCriteria();
            return groupService.AssignCustToGroup(criteria).IsSuccessful;
        }

        private bool UpdateScannedMatch()
        {
            ScannedMatchesService scannedMatchesService = new ScannedMatchesService();
            MatchInsertCriteria criteria = new MatchInsertCriteria();
            
            string matchIdList = string.Empty;
            string workflowIdList = string.Empty;            
            string eventDateList = string.Empty;

            foreach (var info in _suspiciousInfoList)
            {                
                matchIdList = string.Join(";", matchIdList, info.MatchId);
                workflowIdList = string.Join(";", workflowIdList, info.WorkflowId);                                
            }

            criteria.MatchIdList = matchIdList;
            criteria.WorkflowIdList = workflowIdList;
            criteria.EventDate = new DateTime(); //todo

            return scannedMatchesService.InsertScannedMatch(criteria).IsSuccessful;
        }

        private bool InsertSuspiciousInfo()
        {            
            SuspiciousInfoService suspiciousInfoService = new SuspiciousInfoService();
            SuspiciousInfoInsertCriteria criteria = new SuspiciousInfoInsertCriteria();

            string custIdList = string.Empty;
            string matchIdList = string.Empty;
            string workflowIdList = string.Empty;
            string groupTransIdList = string.Empty;

            foreach (var info in _suspiciousInfoList)
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
        }
    }
}
