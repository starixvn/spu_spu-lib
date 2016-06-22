// --------------------------------------------------------------------------
// <copyright file="DataCaptureListInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron" date="2016.06.22">Created</change>
// </history>

namespace FD.Lib.Criteria.DataCapture
{
    using Fanex.Data.Repository;

    public class DataCaptureListInsertCriteria : CriteriaBase
    {
        public string DataCaptureDoc { get; set; }

        public override string GetSettingKey()
        {
            return "FD_DataCaptureListInsert";
        }

        public override bool IsValid()
        {
            return string.IsNullOrEmpty(DataCaptureDoc);
        }
    }
}