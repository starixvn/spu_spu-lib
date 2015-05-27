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

        public string TaskPreconditions { get; set; }

        public List<Config> Preconditions { get; set; }

        public string TaskRules { get; set; }

        public List<Config> Rules { get; set; }

        public int WorkflowId { get; set; }

        public bool IsBackgroundProcess { get; set; } //get from [IsBackgroundProcess] in Action table

        public int ActionId { get; set; }

        public string NextActionIdList { get; set; }

        public int Interval { get; set; }

        public string IntervalType { get; set; } // day, hour, min, second

        public bool IsActive { get; set; }

        public int Timer
        {
            get
            {
                switch (IntervalType)
                {
                    case "days": return Interval *24* 3600 * 1000;
                    case "hours": return Interval * 3600 * 1000;
                    case "minutes": return Interval * 60 *1000;
                    default: return Interval*1000;
                }
            }
        }
    }
}
