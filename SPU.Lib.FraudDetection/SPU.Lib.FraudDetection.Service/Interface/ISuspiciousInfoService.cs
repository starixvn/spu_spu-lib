// --------------------------------------------------------------------------
// <copyright file="ISuspiciousInfoService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Suspicious Info Service interface.
    /// </summary>
    public interface ISuspiciousInfoService
    {
        ICommandResult InsertSuspiciousInfo(ICriteria criteria);
    }
}
