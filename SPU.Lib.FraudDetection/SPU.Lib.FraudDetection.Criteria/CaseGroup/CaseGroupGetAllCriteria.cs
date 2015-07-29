// --------------------------------------------------------------------------
// <copyright file="CaseGroupGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupGetAllCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_CaseGroupGetAll";
        }
        
        public override bool IsValid()
        {
            return CaseId > 0;
        }
    }
}