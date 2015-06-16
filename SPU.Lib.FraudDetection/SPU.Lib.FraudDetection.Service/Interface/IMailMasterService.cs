// --------------------------------------------------------------------------
// <copyright file="IMailMasterService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Mail master Service interface.
    /// </summary>
    public interface IMailMasterService
    {
        ICommandResult InsertMail(ICriteria criteria);

        ICommandResult DeleteMail(ICriteria criteria);

        ICommandResult UpdateMail(ICriteria criteria);

        IEnumerable<MailMasterInfo> GetMails(ICriteria criteria);

        MailMasterInfo GetMailById(ICriteria criteria);

        MailMasterInfo GetMailByName(ICriteria criteria);
    }
}
