// --------------------------------------------------------------------------
// <copyright file="ConfigurationsService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using Interface;

    /// <summary>
    /// Configurations Service.
    /// </summary>
    public class ConfigurationsService : QueryService, IConfigurationsService
    {
        private IConfigurationsDataAccess _configDataAccess;

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

        public IEnumerable<Parameter> GetParameters(ICriteria criteria)
        {
            return GetData<Parameter>(criteria);
        }

        public ICommandResult UpdateConfigs(ICriteria criteria)
        {
            return _configDataAccess.UpdateConfigs(criteria);
        }

        public ICommandResult UpdateConfigParameters(ICriteria criteria)
        {
            return _configDataAccess.UpdateConfigParameters(criteria);
        }
    }
}
