// --------------------------------------------------------------------------
// <copyright file="MailMasterService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;
    using SPU.Lib.FraudDetection.DataAccess.Implement;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service.Interface;

    /// <summary>
    /// Mail master Service.
    /// </summary>
    public class MailMasterService : QueryService, IMailMasterService
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

        public ICommandResult UpdateMail(ICriteria criteria)
        {
            return _mailMasterDataAccess.UpdateMail(criteria);
        }

        public IEnumerable<MailMasterInfo> GetMails(ICriteria criteria)
        {
            return GetData<MailMasterInfo>(criteria);
        }

        public MailMasterInfo GetMailById(Fanex.Data.Repository.ICriteria criteria)
        {
            var result = GetData<MailMasterInfo>(criteria);

            return result.SingleOrDefault();
        }

        public MailMasterInfo GetMailByName(ICriteria criteria)
        {
            var result = GetData<MailMasterInfo>(criteria);

            return result.SingleOrDefault();
        }
    }
}
