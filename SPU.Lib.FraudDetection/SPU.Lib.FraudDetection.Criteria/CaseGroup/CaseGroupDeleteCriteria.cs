// --------------------------------------------------------------------------
// <copyright file="CaseGroupDeleteCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupDeleteCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public int GroupId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_CaseGroupDelete";
        }

        public override bool IsValid()
        {
            return CaseId > 0 && GroupId > 0;
        }
    }
}