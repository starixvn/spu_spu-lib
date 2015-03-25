using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.NAP.Framework.Data;
using SPU.Lib.FraudDetection.DataAccess.Interface;
using Fanex.NAP.Framework.Command;

namespace SPU.Lib.FraudDetection.DataAccess.Imp
{
    public class ConfigurationsDataAccess: BaseDataAccess
    {
        public ICommandResult Insert(ICriteria criteria)
        {
            return executeDB(criteria);            
        }

        public ICommandResult Delete(ICriteria criteria)
        {
            return executeDB(criteria);            
        }
    }
}
