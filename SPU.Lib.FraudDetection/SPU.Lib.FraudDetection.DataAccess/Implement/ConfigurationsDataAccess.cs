// --------------------------------------------------------------------------
// <copyright file="ConfigurationsDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess.Interface;

    /// <summary>
    /// Configurations Data Access Implement.
    /// </summary>
    public class ConfigurationsDataAccess : BaseDataAccess, IConfigurationsDataAccess
    {
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
