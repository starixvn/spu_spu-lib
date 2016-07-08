// --------------------------------------------------------------------------
// <copyright file="INotificationService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron" date="2016.07.08">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    public interface INotificationService 
    {
        ICommandResult InsertUserMessage(ICriteria criteria);
    }
}