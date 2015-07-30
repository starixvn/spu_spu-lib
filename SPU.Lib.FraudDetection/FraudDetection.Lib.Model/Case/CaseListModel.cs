// --------------------------------------------------------------------------
// <copyright file="CaseListModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.30">Created</change>
// </history>

namespace FD.Lib.Model.Case
{
    using System.Collections.Generic;

    /// <summary>
    /// CaseListModel Class.
    /// </summary>
    public class CaseListModel
    {
        public CaseListModel()
        {
            Cases = new List<CaseModel>();
        }

        public int TotalItem { get; set; }

        public IEnumerable<CaseModel> Cases { get; set; } 
    }
}
