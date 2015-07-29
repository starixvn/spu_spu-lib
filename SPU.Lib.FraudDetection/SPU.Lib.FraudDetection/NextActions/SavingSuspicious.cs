// --------------------------------------------------------------------------
// <copyright file="SavingSuspicious.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.NextActions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Core.Utilities;
    using Criteria.ScannedMatch;
    using Criteria.SuspiciousInfo;
    using DTO;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    /// Save suspicious info.
    /// </summary>
    public class SavingSuspicious
    {
        protected const int ChunkSize = 60;

        private readonly IList<string> _matchIdList;

        private readonly int _taskId;

        private List<SuspiciousInfo> _suspiciousInfoList;

        public SavingSuspicious(List<SuspiciousInfo> suspiciousInfoList, IList<string> matchIdList, int taskId)
        {
            _suspiciousInfoList = suspiciousInfoList;
            _matchIdList = matchIdList;
            _taskId = taskId;

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
            if (_suspiciousInfoList.Count <= 0)
            {
                return;
            }

            InsertScannedMatch();

            InsertSuspicion();
        }

        private void InsertScannedMatch()
        {
            var matchChunks = _matchIdList.Chunk(ChunkSize);

            foreach (var matchChunk in matchChunks)
            {
                var criteria = new MatchInsertCriteria
                {
                    MatchIdList = string.Join(",", matchChunk),
                    TaskId = _taskId,
                    ScannedDate = DateTime.Now
                };

                var result = ScannedMatchesService.InsertScannedMatch(criteria);

                if (result.IsSuccessful == false)
                {
                    Logger.Log.Error("Error  UpdateScannedMatch : " + result.Message);
                }
            }
        }

        private void InsertSuspicion()
        {
            var suspiciousChunks = _suspiciousInfoList.Chunk(ChunkSize);

            foreach (var suspiciousChunk in suspiciousChunks)
            {
                var criteria = new SuspiciousInfoInsertCriteria
                {
                    SuspicionDoc = CreateXmlParam(suspiciousChunk)
                };

                var result = SuspiciousInfoService.InsertSuspiciousInfo(criteria);

                if (result.IsSuccessful == false)
                {
                    Logger.Log.Error("Error  InsertSuspiciousInfo : " + result.Message);
                }
            }
        }

        private string CreateXmlParam(IEnumerable<SuspiciousInfo> chunk)
        {
            var builder = new StringBuilder();
            builder.Append("<Root>");

            foreach (var suspiciousInfo in chunk)
            {
                builder.Append("<Row>");
                builder.Append(GetElement("CustId", suspiciousInfo.CustId));
                builder.Append(GetElement("MatchId", suspiciousInfo.MatchId));
                builder.Append(GetElement("TransId", suspiciousInfo.TransId));
                builder.Append(GetElement("TaskId", suspiciousInfo.TaskId));
                builder.Append(GetElement("CaseId", suspiciousInfo.CaseId));
                builder.Append("</Row>");
            }

            builder.Append("</Root>");

            return builder.ToString();
        }

        private string GetElement(string tagName, object value)
        {
            return string.Format("<{0}>{1}</{0}>", tagName, value);
        }
    }
}