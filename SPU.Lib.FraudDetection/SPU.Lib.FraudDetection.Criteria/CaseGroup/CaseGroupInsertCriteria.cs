// --------------------------------------------------------------------------
// <copyright file="CaseGroupInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupInsertCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public string GroupIds { get; set; }
        
        public override string GetSettingKey()
        {
            return "FD_CaseGroupInsert";
        }
        
        public override bool IsValid()
        {
            return CaseId > 0 && !string.IsNullOrEmpty(GroupIds);
        }
    }
}