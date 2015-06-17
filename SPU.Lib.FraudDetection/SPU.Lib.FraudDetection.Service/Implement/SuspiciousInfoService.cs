// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfoService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using DataAccess.Implement;
    using DataAccess.Interface;
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    /// Suspicious Info Service.
    /// </summary>
    public class SuspiciousInfoService : QueryService, ISuspiciousInfoService
    {
        private ISuspiciousInfoDataAccess _suspiciousDataAccess;

        public SuspiciousInfoService()
        {
            _suspiciousDataAccess = new SuspiciousInfoDataAccess();
        }        

        public ICommandResult InsertSuspiciousInfo(ICriteria criteria)
        {
            return _suspiciousDataAccess.InsertSuspiciousInfo(criteria);
        }
    }
}
