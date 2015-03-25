using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.NAP.Framework.Command;
using Fanex.NAP.Framework.Data;
using Fanex.Data;
using System.Collections;
using SPU.Lib.FraudDetection.DataAccess.Imp;

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    public class BaseDataAccess
    {

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

        public ICommandResult executeDB(ICriteria criteria)
        {
            // prepare SP parameters
            Hashtable hash = criteria.GetSpParams();

            hash = (new ResultCriteria()).AddSpParams(hash);

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(hash);

                return GetCommandResult(hash);
            }
        }                   
    }
}
