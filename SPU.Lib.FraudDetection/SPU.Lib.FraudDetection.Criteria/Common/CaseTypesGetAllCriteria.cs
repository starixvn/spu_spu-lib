// --------------------------------------------------------------------------
// <copyright file="CaseTypesGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.06.24">Created</change>
// </history>

namespace FD.Lib.Criteria.Common
{
    using Fanex.Data.Repository;

    public class CaseTypesGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_CaseTypesGetAll";
        }
    }
}