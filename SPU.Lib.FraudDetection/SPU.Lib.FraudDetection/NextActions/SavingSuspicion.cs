namespace SPU.Lib.FraudDetection.NextActions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Core;
    using Criteria;
    using Criteria.Match;
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
        private readonly string _matchIdList;
        private readonly int _taskId;
        private List<SuspiciousInfo> _suspiciousInfoList;

        public SavingSuspicion(List<SuspiciousInfo> suspiciousInfoList, string matchIdList, int taskId)
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
                    MatchIdList = _matchIdList,
                    TaskId = _taskId,
                    ScannedDate = DateTime.Now
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
                var chunks = _suspiciousInfoList.Chunk(100);

                foreach (var chunk in chunks)
                {
                    var criteria = new SuspiciousInfoInsertCriteria
                    {
                        SuspicionDoc = CreateXmlParam(chunk)
                    };

                    var result = SuspiciousInfoService.InsertSuspiciousInfo(criteria);

                    if (result.IsSuccessful == false)
                    {
                        Logger.Log.Error("Error  InsertSuspiciousInfo : " + result.Message);
                    }
                }

                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception InsertSuspiciousInfo --", ex);
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