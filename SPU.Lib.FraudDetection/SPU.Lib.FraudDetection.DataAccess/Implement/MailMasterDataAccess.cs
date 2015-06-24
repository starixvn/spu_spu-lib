// --------------------------------------------------------------------------
// <copyright file="MailMasterDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Mail master Data Access.
    /// </summary>
    public class MailMasterDataAccess : BaseDataAccess, IMailMasterDataAccess
    {
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
    }
}