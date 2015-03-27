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
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess.Imp;

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

        public bool Insert(ICriteria criteria)
        {
            _configDataAccess.Insert(criteria);

            return true;
        }
    }
}
