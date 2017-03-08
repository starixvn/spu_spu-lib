namespace FD.Lib.DataAccess.Implement
{
    using Fanex.Data;
    using FD.Lib.Criteria.Reports.LiveMatchMonitoring;
    using FD.Lib.DataAccess.Interface;
    using FD.Lib.DTO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class LiveMatchMonitoringReportDataAccess : BaseDataAccess, ILiveMatchMonitoringReportDataAccess
    {
        public List<LiveMatchMonitoring> GetMatchMonitoringReport(LiveMatchMonitoringReportGetAllCriteria criteria)
        {
            var hash = criteria.GetSpParams();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(hash);
                var dataSet = db.ExecuteDataSet();
                criteria.NumberOfCases = (int)db.GetOuputParams()["numberofcases"];

                return MapMatchMonitoringData(dataSet.Tables[0]);
            }
        }

        private List<LiveMatchMonitoring> MapMatchMonitoringData(DataTable dataTable)
        {
            var matches = new List<LiveMatchMonitoring>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var match = new LiveMatchMonitoring();
                bool temp;
                DateTime tempDate;

                match.MatchId = int.Parse(dataRow["matchid"].ToString());
                match.LeagueName = dataRow["leaguename"].ToString();
                match.MatchCode = dataRow["matchcode"].ToString();
                match.IsVerified = bool.TryParse(dataRow["IsVerified"].ToString(), out temp) ? temp : (bool?)null;
                match.LastVerifiedBy = dataRow["LastVerifiedBy"].ToString();
                match.LastVerifiedDate = DateTime.TryParse(dataRow["LastVerifiedDate"].ToString(), out tempDate) ? tempDate : (DateTime?)null;
                match.HomeId = int.Parse(dataRow["homeid"].ToString());
                match.AwayId = int.Parse(dataRow["awayid"].ToString());
                match.KickOffTime = DateTime.Parse(dataRow["kickofftime"].ToString());
                match.LiveHomeScore = dataRow["livehomescore"] == DBNull.Value ? 0 : int.Parse(dataRow["livehomescore"].ToString());
                match.LiveAwayScore = dataRow["liveawayscore"] == DBNull.Value ? 0 : int.Parse(dataRow["liveawayscore"].ToString());
                match.EventStatus = dataRow["eventstatus"].ToString();

                var totalColumns = dataTable.Columns.Count;
                for (var i = 12; i < totalColumns; i++)
                {
                    match.SuspiciousCases.Add(
                        dataTable.Columns[i].ColumnName,
                        string.IsNullOrEmpty(dataRow[i].ToString()) ? -1 : int.Parse(dataRow[i].ToString()));
                }

                foreach (var item in match.SuspiciousCases)
                {
                    if (item.Value > 0)
                    {
                        match.ScannedStatus = 2;
                        break;
                    }
                    else if (item.Value == 0)
                    {
                        match.ScannedStatus = 1;
                        break;
                    }
                }

                matches.Add(match);
            }

            return matches.OrderByDescending(t => t.ScannedStatus).ToList();
        }
    }
}
