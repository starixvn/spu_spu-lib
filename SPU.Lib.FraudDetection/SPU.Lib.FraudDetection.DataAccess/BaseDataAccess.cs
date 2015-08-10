// --------------------------------------------------------------------------
// <copyright file="BaseDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using Core.Utilities;
    using Criteria.Common;
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

    /// <summary>
    ///     Base Data Access.
    /// </summary>
    public class BaseDataAccess
    {
        private readonly string _sqlConnectionString;

        public BaseDataAccess()
        {
            _sqlConnectionString = ConnectionStringGetter.GetConnectionString("DBFD.FraudDetection.bodbSPUNet");
            //_sqlConnectionString = ConfigSettings.GetConnectionStringByName("DBFD.FraudDetection.bodbSPUNet");
        }

        /// <summary>
        ///     Execute non query.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Command result.</returns>
        public ICommandResult ExecuteNonQuery(ICriteria criteria)
        {
            // Prepare SP parameters
            var hash = criteria.GetSpParams();

            hash = (new ResultCriteria()).AddSpParams(hash);

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(hash);

                return GetCommandResult(hash);
            }
        }

        /// <summary>
        ///     Execute data reader.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Set of data.</returns>
        public DataSet ExecuteReader(ICriteria criteria)
        {
            using (var objectDb = new ObjectDb(criteria.GetSettingKey()))
            {
                var param = criteria.GetSpParams();
                var ds = objectDb.ExecuteDataSet(param);

                return ds;
            }
        }

        /// <summary>
        ///     Execute Non Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Command result.</returns>
        public ICommandResult ExecuteNonQueryInline(string sqlQueryString)
        {
            var sqlConnection = new SqlConnection(_sqlConnectionString);
            var sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);
            var result = (int)sqlCommand.ExecuteScalar();

            return new CommandResult
            {
                Code = result,
                Message = string.Empty
            };
        }

        /// <summary>
        ///     Execute Reader Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Data table.</returns>
        public DataTable ExecuteReaderQueryInline(string sqlQueryString)
        {
            var sqlConnection = new SqlConnection(_sqlConnectionString);
            var sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);
            var sqlDa = new SqlDataAdapter(sqlCommand);
            var sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);

            return sqlDt;
        }

        /// <summary>
        ///     Get Command Result.
        /// </summary>
        /// <param name="hash">Input parameters.</param>
        /// <returns>Command result.</returns>
        public CommandResult GetCommandResult(Hashtable hash)
        {
            var errCode = hash["errcode"];
            var errMsg = hash["errmsg"];

            return new CommandResult
            {
                Code = (errCode is DBNull) ? 0 : Convert.ToInt32(errCode),
                Message = (errMsg is DBNull) ? string.Empty : Convert.ToString(errMsg)
            };
        }

        /// <summary>
        ///     Returns the data collection.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Data Collection.</returns>
        public DataCollection ReturnDataCollection(ICriteria criteria)
        {
            // prepare SP parameters
            var hash = criteria.GetSpParams();

            // hash = (new ResultCriteria()).AddSpParams(hash);
            var results = new DataCollection();

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(hash);
                results.Data = db.ExecuteDataSet();
                results.TotalItem = (int)db.GetOuputParams()["rowcount"];

                return results;
            }
        }
    }
}