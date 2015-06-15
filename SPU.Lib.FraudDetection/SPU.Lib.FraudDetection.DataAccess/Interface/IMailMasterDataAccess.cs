// --------------------------------------------------------------------------
// <copyright file="IMailMasterDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.15">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Mail master Data Access interface.
    /// </summary>
    public interface IMailMasterDataAccess
    {
        ICommandResult InsertMail(ICriteria criteria);

        ICommandResult UpdateMail(ICriteria criteria);

        ICommandResult DeleteMail(ICriteria criteria);

        IEnumerable<MailMasterInfo> GetMails(ICriteria criteria);
    }
}
