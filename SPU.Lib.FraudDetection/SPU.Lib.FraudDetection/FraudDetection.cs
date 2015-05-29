// --------------------------------------------------------------------------
// <copyright file="FraudDetection.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Long.Luu" date="2015.04.01">Add ScanMatch: major function</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using SPU.Lib.FraudDetection.Criteria.Workflow;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service;

    /// <summary>
    /// Main Class.
    /// </summary>
    public class FraudDetection
    {
        private Match _match;
        private WorkflowService _workflowService;

        public FraudDetection(int matchId, DateTime eventDate)
        {
            _match = new Match { MatchId = matchId, EventDate = eventDate };
            _workflowService = new WorkflowService();
        }

        public static void Start(string[] args)
        {
            BaseAction action = new ActionSendEmail(new System.Collections.Generic.List<SuspiciousInfo>(), "");
            action.TakeAction();
        }  

        /// <summary>
        /// Major function of Fraud Detection.
        /// </summary>
        public void ScanMatch()
        {
            var workflowInfos = _workflowService.LoadWorkflows(new WorkflowSelectAllCriteria());
            foreach (var workflowInfo in workflowInfos)
            {
                if (workflowInfo.IsActive)
                {
                    var workflow = new Workflow(workflowInfo);
                    workflow.Run(_match);
                }
            }
        }      
    }
}
