namespace SPU.Lib.FraudDetection.NextActions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Core;
    using Criteria.ScannedMatch;
    using Criteria.SuspiciousInfo;
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
        private readonly IList<string> _matchIdList;
        private readonly int _taskId;
        private List<SuspiciousInfo> _suspiciousInfoList;
        protected const int ChunkSize = 60;

        public SavingSuspicion(List<SuspiciousInfo> suspiciousInfoList, IList<string> matchIdList, int taskId)
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

            var tasks = new List<Task>();

            var insertScannedMatchTask = Task.Factory.StartNew(InsertScannedMatch);

            tasks.Add(insertScannedMatchTask);

            var insertSuspicionTask = Task.Factory.StartNew(InsertSuspicion);

            tasks.Add(insertSuspicionTask);

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Logger.Log.Error("Task.WaitAll(tasks.ToArray()); : " + innerEx);
                }
            }
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
                builder.Append(GetElement("WorkflowId", suspiciousInfo.WorkflowId));
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