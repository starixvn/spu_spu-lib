// --------------------------------------------------------------------------
// <copyright file="ActionSaveSuspiciousInfo.cs" company="Nexcel Solutions Vietnam">
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
    using Criteria.Match;
    using DTO;
    using Service.Implement;

    /// <summary>
    ///  Save suspicious info.
    /// </summary>
    public class ActionSaveSuspiciousInfo : BaseAction
    {
        private List<SuspiciousInfo> _suspiciousInfoList;
        private string _matchIdList = string.Empty;
        private int _workflowId = 0;

        public ActionSaveSuspiciousInfo(List<SuspiciousInfo> suspiciousInfoList, string matchIdList, int workflowId)
        {
            _suspiciousInfoList = suspiciousInfoList;
            _matchIdList = matchIdList;
            _workflowId = workflowId;
        }

        public List<SuspiciousInfo> AssignGroupList
        {
            get { return _suspiciousInfoList; }
            set { _suspiciousInfoList = AssignGroupList; }
        }

        public override void TakeAction()
        {
            if (_suspiciousInfoList.Count > 0)
            {
                var t1 = new System.Threading.Tasks.Task(() => UpdateScannedMatch());

                t1.ContinueWith(task1 =>
                {
                    var t2 = new System.Threading.Tasks.Task(() => InsertSuspiciousInfo());
                    System.Threading.Thread.Sleep(5000);
                    t2.Start();
                });
                t1.Start();                
            }
        }

        private bool UpdateScannedMatch()
        {
            try
            {
                var scannedMatchesService = new ScannedMatchesService();
                var criteria = new MatchInsertCriteria();
                criteria.CreatorId = 0;
                criteria.MatchIdList = _matchIdList;
                criteria.WorkflowId = _workflowId;
                criteria.EventDate = DateTime.Now; // todo

                var result = scannedMatchesService.InsertScannedMatch(criteria);
                if (result.IsSuccessful == false)
                {
                    Fanex.Logging.Logger.Log.Error("Error  UpdateScannedMatch : " + result.Message);
                }

                return result.IsSuccessful;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception UpdateScannedMatch --", ex);
            }
        }

        private bool InsertSuspiciousInfo()
        {
            try
            {
                var suspiciousInfoService = new SuspiciousInfoService();
                var criteria = new SuspiciousInfoInsertCriteria();

                var custIdList = new List<int>();
                var matchIdList = new List<int>();
                var workflowIdList = new List<int>();
                var groupTransIdList = new List<string>();

                foreach (var info in _suspiciousInfoList)
                {
                    custIdList.Add(info.CustId);
                    matchIdList.Add(info.MatchId);
                    workflowIdList.Add(info.WorkflowId);
                    groupTransIdList.Add(info.TransIdList);
                }

                criteria.CreatorId = 0;
                criteria.CustIdList = string.Join(";", custIdList);
                criteria.MatchIdList = string.Join(";", matchIdList);
                criteria.WorkflowIdList = string.Join(";", workflowIdList);
                criteria.GroupTransIdList = string.Join(";", groupTransIdList);

                var result = suspiciousInfoService.InsertSuspiciousInfo(criteria);
                if (result.IsSuccessful == false)
                {
                    Fanex.Logging.Logger.Log.Error("Error  InsertSuspiciousInfo : " + result.Message);
                }

                return result.IsSuccessful;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception InsertSuspiciousInfo --", ex);
            }
        }
    }
}