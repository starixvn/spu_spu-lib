// --------------------------------------------------------------------------
// <copyright file="Configurations.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using SPU.Lib.FraudDetection.Criteria;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service;    

    /// <summary>
    /// Configurations Class.
    /// </summary>
    public class Configurations
    {
        private Dictionary<string, Config> _configs = new Dictionary<string, Config>();

        private ConfigurationsService _configService = new ConfigurationsService();      

        /// <summary>
        /// Get configuration list.
        /// </summary>
        /// <returns>The list of configurations.</returns>
        public Dictionary<string, Config> GetConfigurations()
        {
            if (_configs.Count == 0)
            {
                IEnumerable<Config> configs = _configService.GetConfigs(new ConfigSelectAllCriteria());

                foreach (var config in configs)
                {
                    _configs.Add(
                                            config.ConfigName,
                                            new Config
                                            {
                                                ConfigName = config.ConfigName,
                                                ConfigValue = config.ConfigValue,
                                                ConfigOperator = config.ConfigOperator,
                                                IsUpdate = false
                                            });
                }
            }

            return _configs;
        }

        public ICommandResult InsertConfig(Config config)
        {
            _configs.Add(config.ConfigName, config);

            ConfigInsertCriteria criteria = new ConfigInsertCriteria();
            criteria.ConfigName = config.ConfigName;
            criteria.ConfigValue = config.ConfigValue;
            criteria.ConfigOperator = config.ConfigOperator;
           
            return _configService.InsertConfig(criteria);
        }        

        /// <summary>
        /// Update list of configurations.
        /// </summary>
        /// <returns>True if success.</returns>
        public bool UpdateConfigurations()
        {            
            string tmpUpdate = " Update [dbo].[Configurations] Set ConfigValue = {0}, ConfigOperator = {1} Where ConfigName = {2} ";
            string sqlStr = string.Empty;

            foreach (var config in _configs)
            {
                if (config.Value.IsUpdate)
                {
                    sqlStr += string.Format(tmpUpdate, config.Value.ConfigValue, config.Value.ConfigOperator, config.Value.ConfigName);                    
                }
            }

            if (!string.IsNullOrEmpty(sqlStr))
            {
                return _configService.ExecuteNonQueryInline(sqlStr).IsSuccessful;
            }

            return true;
        }

        public bool RemoveConfig(Config config)
        {
            _configs.Remove(config.ConfigName);

            return true;
        }
    }
}
