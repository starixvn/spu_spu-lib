// --------------------------------------------------------------------------
// <copyright file="CustomerGroupInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     CustomerGroupAssignCriteria Class.
    /// </summary>
    public class CustomerGroupInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string CustIdList { get; set; }

        public int GroupId { get; set; }

        public int CaseId { get; set; }
       
        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerGroupInsert";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}
