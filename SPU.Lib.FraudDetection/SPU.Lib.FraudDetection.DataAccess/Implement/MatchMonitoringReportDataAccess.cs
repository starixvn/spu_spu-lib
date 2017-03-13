// --------------------------------------------------------------------------
// <copyright file="MatchMonitoringReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.12">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using Criteria.Reports;
    using DTO;
    using Fanex.Data;
    using Interface;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    ///  Match Monitoring Report Data Access Implement.
    /// </summary>
    public class MatchMonitoringReportDataAccess : BaseDataAccess, IMatchMonitoringReportDataAccess
    {
        public List<MatchMonitoring> GetMatchMonitoringReport(MatchMonitoringReportGetAllCriteria criteria)
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

        public List<MatchMonitoring> GetMatchMonitoringReportFromDBArchive(
            MatchMonitoringReportGetAllDBArchiveCriteria criteria)
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

        private List<MatchMonitoring> MapMatchMonitoringData(DataTable dataTable)
        {
            var matches = new List<MatchMonitoring>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var match = new MatchMonitoring();
                bool temp;
                DateTime tempDate;

                match.MatchId = int.Parse(dataRow["matchid"].ToString());
                match.LeagueName = dataRow["leaguename"].ToString();
                match.MatchCode = dataRow["matchcode"].ToString();
                match.IsDelinquent = bool.TryParse(dataRow["IsDelinquent"].ToString(), out temp) ? temp : (bool?)null;
                match.IsVerified = bool.TryParse(dataRow["IsVerified"].ToString(), out temp) ? temp : (bool?)null;
                match.LastVerifiedBy = dataRow["LastVerifiedBy"].ToString();
                match.LastVerifiedDate = DateTime.TryParse(dataRow["LastVerifiedDate"].ToString(), out tempDate) ? tempDate : (DateTime?)null;
                match.HomeId = int.Parse(dataRow["homeid"].ToString());
                match.AwayId = int.Parse(dataRow["awayid"].ToString());
                match.EventStatus = dataRow["eventstatus"].ToString();

                var totalColumns = dataTable.Columns.Count;
                for (var i = 10; i < totalColumns; i++)
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