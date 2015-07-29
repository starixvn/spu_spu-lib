// --------------------------------------------------------------------------
// <copyright file="SendingType.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement.SendingTasks
{
    /// <summary>
    ///     Sending Type.
    /// </summary>
    public enum SendingType
    {
        /// <summary>
        ///     No type here.
        /// </summary>
        None,

        /// <summary>
        ///     Adding Task.
        /// </summary>
        AddingTask,

        /// <summary>
        ///     Updating task.
        /// </summary>
        UpdatingTask,

        /// <summary>
        ///     Removing task.
        /// </summary>
        RemovingTask,

        /// <summary>
        ///     Deactivate case.
        /// </summary>
        DeactivatingCase,

        /// <summary>
        ///     Deactivate case.
        /// </summary>
        ActivatingCase
    }
}