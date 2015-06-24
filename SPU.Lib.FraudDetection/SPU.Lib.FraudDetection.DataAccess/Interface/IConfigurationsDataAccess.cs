// --------------------------------------------------------------------------
// <copyright file="IConfigurationsDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Configurations Data Access interface.
    /// </summary>
    public interface IConfigurationsDataAccess
    {
        ICommandResult InsertConfig(ICriteria criteria);
        ICommandResult UpdateConfigs(ICriteria criteria);
        ICommandResult DeleteConfig(ICriteria criteria);
        ICommandResult UpdateConfigParameters(ICriteria criteria);
    }
}