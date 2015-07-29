// --------------------------------------------------------------------------
// <copyright file="ConfigurationsService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Configurations Service.
    /// </summary>
    public class ConfigurationsService : QueryService, IConfigurationsService
    {
        private readonly IConfigurationsDataAccess _configDataAccess;

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

        public List<Config> GetFormattedConfigs(ICriteria criteria, int caseId)
        {
            var configs = GetData<Config>(criteria).ToList();
            var counterTableSQLString = configs.SingleOrDefault(l => l.ConfigName == "Suspicious Time").ConfigSQLTable;
            configs.Where(l => l.ConfigName == "Suspicious Time").First().ConfigSQLTable = counterTableSQLString.Replace("$param1$", caseId.ToString());
            
            return configs;
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