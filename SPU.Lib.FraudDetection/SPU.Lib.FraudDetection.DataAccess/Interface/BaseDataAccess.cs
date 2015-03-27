// --------------------------------------------------------------------------
// <copyright file="BaseDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using System;
    using System.Collections;
    using System.Data;
    using Fanex.Data;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess.Imp;

    /// <summary>
    /// Base Data Access.
    /// </summary>
    public class BaseDataAccess
    {
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
