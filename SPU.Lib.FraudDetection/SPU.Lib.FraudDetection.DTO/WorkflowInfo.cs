// --------------------------------------------------------------------------
// <copyright file="WorkflowInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    /// <summary>
    ///     Workflow information.
    /// </summary>
    public class WorkflowInfo
    {
        public int WorkflowId { get; set; }
        public string WorkflowName { get; set; }
        public string WorkflowDesc { get; set; }
        public bool IsActive { get; set; }
    }
}