// --------------------------------------------------------------------------
// <copyright file="ICaseGroupDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using Criteria.CaseGroup;
    using DataAccess;
    using Fanex.NAP.Framework.Command;

    public interface ICaseGroupDataAccess
    {
        ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria);

        ICommandResult DeleteCaseGroup(CaseGroupDeleteCriteria criteria);
    }

    public class CaseGroupDataAccess : BaseDataAccess, ICaseGroupDataAccess
    {
        public ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteCaseGroup(CaseGroupDeleteCriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}