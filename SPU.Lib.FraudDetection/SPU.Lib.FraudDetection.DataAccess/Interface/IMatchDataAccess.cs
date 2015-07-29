// --------------------------------------------------------------------------
// <copyright file="IMatchDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using Fanex.Data.Repository;

    public interface IMatchDataAccess
    {
        object GetMatchList(ICriteria criteria);
    }
}