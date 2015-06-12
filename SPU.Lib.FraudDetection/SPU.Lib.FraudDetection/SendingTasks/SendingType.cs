// --------------------------------------------------------------------------
// <copyright file="SendingType.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.SendingTasks
{
    /// <summary>
    /// Sending Type.
    /// </summary>
    public enum SendingType
    {
        /// <summary>
        /// No type here.
        /// </summary>
        None,

        /// <summary>
        /// Adding Task.
        /// </summary>
        AddingTask,

        /// <summary>
        /// Updating task.
        /// </summary>
        UpdatingTask,

        /// <summary>
        /// Removing task.
        /// </summary>
        RemovingTask
    }
}