// --------------------------------------------------------------------------
// <copyright file="MailMasterDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.Core;

    /// <summary>
    /// Mail master Data Access.
    /// </summary>
    public class MailMasterDataAccess : BaseDataAccess
    {
        public MailMasterDataAccess()
            : base()
        {
        }

        public ICommandResult InsertMail(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateMail(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteMail(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public DataCollection GetMails(ICriteria criteria)
        {
            return ReturnDataCollection(criteria);
        }
    }
}
