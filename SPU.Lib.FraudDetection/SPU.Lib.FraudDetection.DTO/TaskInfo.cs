// --------------------------------------------------------------------------
// <copyright file="TaskInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
//   <change who="Thai.Tran" date="2015.05.21">Updated fields for mapping a retrieved task.</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// TaskInfo class.
    /// </summary>
    public class TaskInfo
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public string TaskQuery { get; set; }

        public string TaskPreconditions { get; set; }

        public List<Config> Preconditions { get; set; }

        public string TaskRules { get; set; }

        public List<Config> Rules { get; set; }

        public int WorkflowId { get; set; }

        public bool IsRunMannually { get; set; } //get from [IsBackgroundProcess] in Action table

        public string NextActionIdList { get; set; }

        public int Interval { get; set; }

        public int IntervalType { get; set; } // day, hour, min, second

        public bool IsActive { get; set; }
    }
}
