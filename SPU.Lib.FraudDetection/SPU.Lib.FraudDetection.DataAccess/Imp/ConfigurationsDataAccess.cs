// --------------------------------------------------------------------------
// <copyright file="ConfigurationsDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Imp
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess.Interface;

    /// <summary>
    /// Configurations Data Access.
    /// </summary>
    public class ConfigurationsDataAccess : BaseDataAccess
    {
        public ICommandResult Insert(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);            
        }

        public ICommandResult Delete(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);            
        }
    }
}
