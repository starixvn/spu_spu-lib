// --------------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="SPU" date="2012.8.15">Created</change>
// </history>
namespace SPU.Lib.FraudDetection.Service
{
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess.Imp;

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
