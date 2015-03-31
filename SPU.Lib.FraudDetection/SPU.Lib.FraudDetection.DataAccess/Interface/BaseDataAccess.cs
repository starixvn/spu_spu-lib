// --------------------------------------------------------------------------
// <copyright file="BaseDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using Fanex.Data;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Base Data Access.
    /// </summary>
    public class BaseDataAccess
    {
        /// <summary>
        /// Execute non query.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Command result.</returns>
        public ICommandResult ExecuteNonQuery(ICriteria criteria)
        {
            // Prepare SP parameters
            Hashtable hash = criteria.GetSpParams();

            hash = (new ResultCriteria()).AddSpParams(hash);

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(hash);

                return GetCommandResult(hash);
            } 
        }

        /// <summary>
        /// Execute data reader.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Set of data.</returns>
        public DataSet ExecuteReader(ICriteria criteria)
        {
            using (var objectDb = new ObjectDb(criteria.GetSettingKey()))
            {
                var param = criteria.GetSpParams();
                var ds = objectDb.ExecuteDataSet(param);

                // var mainTable = ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
                // var referenceTable = ds.Tables.Count > 1 ? ds.Tables[1] : new DataTable();
                return ds;
            }
        }

        /// <summary>
        /// Execute Non Query Inline.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <param name="connectionString">Connection string.</param>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Command result.</returns>
        public ICommandResult ExecuteNonQueryInline(ICriteria criteria, string connectionString, string sqlQueryString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);
            var result = (int)sqlCommand.ExecuteScalar();

            return new CommandResult
            {
                Code = result,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Execute Reader Query Inline.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <param name="connectionString">Connection string.</param>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Data table.</returns>
        public DataTable ExecuteReaderQueryInline(ICriteria criteria, string connectionString, string sqlQueryString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
            DataTable sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);

            return sqlDt;
        }
        
        /// <summary>
        /// Get Command Result.
        /// </summary>
        /// <param name="hash">Input parameters.</param>
        /// <returns>Command result.</returns>
        private CommandResult GetCommandResult(Hashtable hash)
        {
            var errCode = hash["errcode"];
            var errMsg = hash["errmsg"];

            return new CommandResult
            {
                Code = (errCode is DBNull) ? 0 : Convert.ToInt32(errCode),
                Message = (errMsg is DBNull) ? string.Empty : Convert.ToString(errMsg)
            };
        }                 
    }
}
