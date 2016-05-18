// --------------------------------------------------------------------------
// <copyright file="CustomerDelinquentUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.05.18">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using Fanex.Data.Repository;

    public class CustomerHedgeUpdateCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public int AuthorId { get; set; }

        public bool IsHedge { get; set; }

        public override string GetSettingKey()
        {
            return "FD_CustomerHedgeUpdate";
        }

        public override bool IsValid()
        {
            return CustId > 0;
        }
    }
}
