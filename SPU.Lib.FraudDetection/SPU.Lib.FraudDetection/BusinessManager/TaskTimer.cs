// --------------------------------------------------------------------------
// <copyright file="TaskTimer.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.05.21">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System.Timers;

    /// <summary>
    /// ThreadTimer class.
    /// </summary>
    public class TaskTimer : Timer
    {
        public TaskTimer(double interval)
            : base(interval)
        {
        }

        public string TaskCode { get; set; }

        public string TimerName { get; set; }
    }
}
