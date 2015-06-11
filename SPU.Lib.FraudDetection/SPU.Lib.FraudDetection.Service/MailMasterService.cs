// --------------------------------------------------------------------------
// <copyright file="MailMasterService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.Core;
    using SPU.Lib.FraudDetection.DataAccess;

    /// <summary>
    /// Mail master Service.
    /// </summary>
    public class MailMasterService : QueryService
    {
        private readonly MailMasterDataAccess _mailMasterDataAccess;

        public MailMasterService()
        {
            _mailMasterDataAccess = new MailMasterDataAccess();
        }

        public ICommandResult InsertMail(ICriteria criteria)
        {
            return _mailMasterDataAccess.InsertMail(criteria);
        }

        public ICommandResult DeleteMail(ICriteria criteria)
        {
            return _mailMasterDataAccess.DeleteMail(criteria);
        }

        public DataCollection GetMails(ICriteria criteria)
        {
            return _mailMasterDataAccess.GetMails(criteria);
        }

        public ICommandResult UpdateMail(ICriteria criteria)
        {
            return _mailMasterDataAccess.UpdateMail(criteria);
        }
    }
}
