// --------------------------------------------------------------------------
// <copyright file="ICustomerGroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    public interface ICustomerGroupService
    {
        ICommandResult InsertCustomerGroup(ICriteria criteria);

        ICommandResult InsertAssociatedAccount(ICriteria criteria);
    }
}