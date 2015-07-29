// --------------------------------------------------------------------------
// <copyright file="IMailMasterDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.15">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Mail master Data Access interface.
    /// </summary>
    public interface IMailMasterDataAccess
    {
        ICommandResult InsertMail(ICriteria criteria);

        ICommandResult UpdateMail(ICriteria criteria);

        ICommandResult DeleteMail(ICriteria criteria);
    }
}
