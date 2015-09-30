// --------------------------------------------------------------------------
// <copyright file="DataTypeCaptureGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.29">Created</change>
// </history>

namespace FD.Lib.Criteria.Common
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     The criteria to get all data types.
    /// </summary>
    public class DataTypeCaptureGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_DataTypeCaptureGetAll";
        }
    }
}