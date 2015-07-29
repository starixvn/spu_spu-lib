// --------------------------------------------------------------------------
// <copyright file="DataCollection.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.4.27">Create</change>
// </history>

namespace FD.Lib.Core.Utilities
{
    using System.Data;

    /// <summary>
    /// Data Collection.
    /// </summary>
    public class DataCollection
    {
        public DataSet Data { get; set; }

        public int TotalItem { get; set; }
    }
}