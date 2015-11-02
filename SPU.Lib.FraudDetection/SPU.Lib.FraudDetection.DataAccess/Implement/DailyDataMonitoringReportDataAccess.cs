// --------------------------------------------------------------------------
// <copyright file="DailyDataMonitoringReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.12">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using System.Collections.Generic;
    using System.Data;
    using Criteria.Reports;
    using DTO;
    using Fanex.Data;
    using Interface;
    
    /// <summary>
    ///  Daily Data Monitoring Report Data Access Implement.
    /// </summary>
    public class DailyDataMonitoringReportDataAccess : BaseDataAccess, IDailyDataMonitoringReportDataAccess
    {
        public List<MatchMonitoring> GetDailyDataMonitoringReport(DailyDataMonitoringReportGetAllCriteria criteria)
        {
            var hash = criteria.GetSpParams();
            
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(hash);
                var dataSet = db.ExecuteDataSet();

                return MapDailyDataMonitoringData(dataSet.Tables[0]);
            }
        }

        private List<MatchMonitoring> MapDailyDataMonitoringData(DataTable dataTable)
        {
            var matches = new List<MatchMonitoring>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var match = new MatchMonitoring();
                match.MatchId = int.Parse(dataRow["matchid"].ToString());
                match.LeagueName = dataRow["leaguename"].ToString();
                match.MatchCode = dataRow["matchcode"].ToString();
                match.HomeId = int.Parse(dataRow["homeid"].ToString());
                match.AwayId = int.Parse(dataRow["awayid"].ToString());
                match.EventStatus = dataRow["eventstatus"].ToString();

                var totalColumns = dataTable.Columns.Count;
                for(var i = 6; i < totalColumns; i ++)
                {
                    match.SuspiciousCases.Add(
                        dataTable.Columns[i].ColumnName, 
                        string.IsNullOrEmpty(dataRow[i].ToString()) ? -1 : int.Parse(dataRow[i].ToString()));
                }

                matches.Add(match);
            }

            return matches;
        }
    }
}