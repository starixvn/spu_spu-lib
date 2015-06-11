// --------------------------------------------------------------------------
// <copyright file="TablesForeignKey.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    /// <summary>
    /// Tables Foreign Key Class.
    /// </summary>
    public class TablesForeignKey
    {
        public string DBTable1 { get; set; }

        public string DBTable2 { get; set; }

        public string ForeignKey { get; set; }
    }
}
