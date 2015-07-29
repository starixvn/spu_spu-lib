// --------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.11">Created</change>
// </history>

namespace FD.Lib.DTO
{
    /// <summary>
    ///     Parameter Class.
    /// </summary>
    public class Parameter
    {
        public int ParamId { get; set; }

        public string ParamName { get; set; }

        public string ParamDesc { get; set; }

        public string ParamDisplayName { get; set; }

        public int ParamValue { get; set; }

        public string ParamUnit { get; set; }
    }
}