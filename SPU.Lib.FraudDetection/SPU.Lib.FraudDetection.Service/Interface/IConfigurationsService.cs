// --------------------------------------------------------------------------
// <copyright file="IConfigurationsService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Configurations Service interface.
    /// </summary>
    public interface IConfigurationsService
    {
        ICommandResult InsertConfig(ICriteria criteria);
        ICommandResult DeleteConfig(ICriteria criteria);
        IEnumerable<Config> GetConfigs(ICriteria criteria);
        IEnumerable<Parameter> GetParameters(ICriteria criteria);
        ICommandResult UpdateConfigs(ICriteria criteria);
        ICommandResult UpdateConfigParameters(ICriteria criteria);
    }
}