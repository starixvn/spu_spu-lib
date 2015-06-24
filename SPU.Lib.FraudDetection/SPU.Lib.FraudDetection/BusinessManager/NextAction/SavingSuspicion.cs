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
    using System.Threading;
    using Criteria;
    using Criteria.Match;
    using DTO;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;
    using Task = System.Threading.Tasks.Task;

    /// <summary>
    ///     Save suspicious info.
    /// </summary>
    public class SavingSuspicion
    {
        private readonly string _matchIdList;
        private readonly int _workflowId;
        private List<SuspiciousInfo> _suspiciousInfoList;

        public SavingSuspicion(List<SuspiciousInfo> suspiciousInfoList, string matchIdList, int workflowId)
        {
            _suspiciousInfoList = suspiciousInfoList;
            _matchIdList = matchIdList;
            _workflowId = workflowId;

            ScannedMatchesService = new ScannedMatchesService();
            SuspiciousInfoService = new SuspiciousInfoService();
        }

        public IScannedMatchesService ScannedMatchesService { get; set; }
        public ISuspiciousInfoService SuspiciousInfoService { get; set; }

        public List<SuspiciousInfo> AssignGroupList
        {
            get { return _suspiciousInfoList; }
            set { _suspiciousInfoList = AssignGroupList; }
        }

        public void TakeAction()
        {
            if (_suspiciousInfoList.Count > 0)
            {
                var t1 = new Task(() => UpdateScannedMatch());

                t1.ContinueWith(task1 =>
                {
                    var t2 = new Task(() => InsertSuspicion());
                    Thread.Sleep(5000);
                    t2.Start();
                });
                t1.Start();
            }
        }

        private bool UpdateScannedMatch()
        {
            try
            {
                var criteria = new MatchInsertCriteria
                {
                    CreatorId = 0,
                    MatchIdList = _matchIdList,
                    WorkflowId = _workflowId,
                    EventDate = DateTime.Now // --> ScannedDate
                };

                var result = ScannedMatchesService.InsertScannedMatch(criteria);

                if (result.IsSuccessful == false)
                {
                    Logger.Log.Error("Error  UpdateScannedMatch : " + result.Message);
                }

                return result.IsSuccessful;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception UpdateScannedMatch --", ex);
            }
        }

        private bool InsertSuspicion()
        {
            try
            {
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

                var result = SuspiciousInfoService.InsertSuspiciousInfo(criteria);
                if (result.IsSuccessful == false)
                {
                    Logger.Log.Error("Error  InsertSuspiciousInfo : " + result.Message);
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