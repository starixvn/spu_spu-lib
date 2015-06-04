// --------------------------------------------------------------------------
// <copyright file="ConfigSettings.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.4.27">Create</change>
// </history>

namespace SPU.Lib.Core
{
    using System;
    using System.Data;
    using System.Configuration;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class ConfigSettings
    {
        /// <summary>
        /// Get connection string.
        /// </summary>
        /// <param name="name">The key name.</param>
        /// <returns>The connection string.</returns>
        public static string GetConnectionStringByName(string name)
        {
            // Assume failure. 
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string. 
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }

            return returnValue;
        }

        public static string GetConfigStringByName(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
