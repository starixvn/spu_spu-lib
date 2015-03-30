// --------------------------------------------------------------------------
// <copyright file="TaskInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    using Fanex.NAP.Framework.Data;
    using System.Collections.Generic;

    /// <summary>
    /// Bet type Class.
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

        public bool IsRunMannually { get; set; }

        public int NextActionId { get; set; }

        public int Timer { get; set; }

        public bool IsActive { get; set; }
    }
}
