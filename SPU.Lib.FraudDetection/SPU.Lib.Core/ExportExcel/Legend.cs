// --------------------------------------------------------------------------
// <copyright file="Legend.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.13">Created</change>
// </history>


namespace FD.Lib.Core.ExportExcel
{
    /// <summary>
    /// Legend Item.
    /// </summary>
    public class Legend
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public Legend(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
