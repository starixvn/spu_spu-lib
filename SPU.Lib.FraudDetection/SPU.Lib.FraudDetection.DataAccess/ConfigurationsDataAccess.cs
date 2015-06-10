// --------------------------------------------------------------------------
// <copyright file="ConfigurationsDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Configurations Data Access.
    /// </summary>
    public class ConfigurationsDataAccess : BaseDataAccess
    {
        public ConfigurationsDataAccess() : base()
        {
        }

        public ICommandResult InsertConfig(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);            
        }

        public ICommandResult UpdateConfigs(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteConfig(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);            
        }

        public ICommandResult UpdateConfigParameters(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
