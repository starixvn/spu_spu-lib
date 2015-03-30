// --------------------------------------------------------------------------
// <copyright file="ConfigurationsService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using System.Collections.Generic;
    using System.Data;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Configurations Service.
    /// </summary>
    public class ConfigurationsService : QueryService
    {
        private ConfigurationsDataAccess _configDataAccess;

        public ConfigurationsService()
        {
            _configDataAccess = new ConfigurationsDataAccess();
        }

        public ICommandResult InsertConfig(ICriteria criteria)
        {
            return _configDataAccess.InsertConfig(criteria);
        }

        public ICommandResult DeleteConfig(ICriteria criteria)
        {
            return _configDataAccess.DeleteConfig(criteria);
        }

        public IEnumerable<Config> GetConfigs(ICriteria criteria)
        {
            return GetData<Config>(criteria);
        }

        public ICommandResult UpdateConfigs(ICriteria criteria)
        {
            return _configDataAccess.UpdateConfigs(criteria);
        }
    }
}
