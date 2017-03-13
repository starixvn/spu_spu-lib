// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Criteria.Reports.CustomerDetails;
    using DTO.CustomerDetails;
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;
    using Model.Reports.CustomerDetails;

    /// <summary>
    ///  Customer Details Report Data Access Implement.
    /// </summary>
    public class CustomerDetailsReportDataAccess : BaseDataAccess, ICustomerDetailsReportDataAccess
    {
        public CustomerDetailsModel GetCustomerDetailWinlossStatistic(CustomerDetailsReportWinlossStatisticCriteria criteria)
        {
            var hash = criteria.GetSpParams();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(hash);
                var dataSet = db.ExecuteDataSet();

                try
                {
                    return MapCustomerDetailsData(dataSet);
                }
                catch
                {
                    return new CustomerDetailsModel();
                }
            }
        }

        private CustomerDetailsModel MapCustomerDetailsData(DataSet dataSet)
        {
            return new CustomerDetailsModel
                {
                    Summary = GetSummary(dataSet.Tables[0]),
                    EventChoice = GetEventChoice(dataSet.Tables[1]),
                    TopSportsByMargin = GetTopSportsByMargin(dataSet.Tables[2]),
                    TopBettypesByMargin = GetTopBettypesByMargin(dataSet.Tables[3])
                };
        }

        public string GetTransListByCustId(CustomerDetailsReportTransListCriteria criteria)
        {
            var hash = criteria.GetSpParams();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(hash);
                var dataSet = db.ExecuteDataSet();

                return dataSet.Tables[0].Rows[0]["translist"].ToString();
            }
        }

        public ICommandResult InsertCustomerLog(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult RemoveCustomerLogNote(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult InsertCustomerNote(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateCustomerDelinquent(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public List<int> GetViolatedCases(ICriteria criteria)
        {
            var hash = criteria.GetSpParams();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(hash);
                var dataSet = db.ExecuteDataSet();

                return dataSet.Tables[0].AsEnumerable().Select(l => l.Field<int>("caseid")).ToList();
            }
        }

        public ICommandResult InsertAssignees(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        #region Utilities
        private WinlossStatisticSummary GetSummary(DataTable dataTable)
        {
            return new WinlossStatisticSummary
                {
                    SumTO = float.Parse(dataTable.Rows[0]["sumto"].ToString()),
                    SumWL = float.Parse(dataTable.Rows[0]["sumwl"].ToString()),
                    Margin = float.Parse(dataTable.Rows[0]["margin"].ToString()),
                    BetCount = int.Parse(dataTable.Rows[0]["betcount"].ToString())
                };
        }

        private IEnumerable<WinlossStatisticEventChoice> GetEventChoice(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows
                    select new WinlossStatisticEventChoice
                        {
                            EventChoice = dataRow["eventchoice"].ToString(),
                            SumTO = float.Parse(dataRow["sumto"].ToString()),
                            SumWL = float.Parse(dataRow["sumwl"].ToString()),
                            Margin = float.Parse(dataRow["margin"].ToString())
                        }).ToList();
        }

        private IEnumerable<WinlossStatisticTopSports> GetTopSportsByMargin(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows
                    select new WinlossStatisticTopSports
                    {
                        SportName = dataRow["sportname"].ToString(),
                        SumTO = float.Parse(dataRow["sumto"].ToString()),
                        SumWL = float.Parse(dataRow["sumwl"].ToString()),
                        Margin = float.Parse(dataRow["margin"].ToString())
                    }).ToList();
        }

        private IEnumerable<WinlossStatisticTopBettypes> GetTopBettypesByMargin(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows
                    select new WinlossStatisticTopBettypes
                    {
                        BettypeName = dataRow["bettypename"].ToString(),
                        SumTO = float.Parse(dataRow["sumto"].ToString()),
                        SumWL = float.Parse(dataRow["sumwl"].ToString()),
                        Margin = float.Parse(dataRow["margin"].ToString())
                    }).ToList();
        }

        #endregion
    }
}