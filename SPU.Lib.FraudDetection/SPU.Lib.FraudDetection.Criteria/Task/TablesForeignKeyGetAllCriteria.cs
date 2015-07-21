// --------------------------------------------------------------------------
// <copyright file="SPU_TablesForeignKeyGetAll.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>


namespace SPU.Lib.FraudDetection.Criteria.Task
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     SPU_TablesForeignKeyGetAll Class.
    /// </summary>
    public class TablesForeignKeyGetAllCriteria : CriteriaBase
    {
        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_TablesForeignKeyGetAll";
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