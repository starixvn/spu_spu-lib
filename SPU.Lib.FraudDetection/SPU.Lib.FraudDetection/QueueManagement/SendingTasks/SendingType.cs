namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
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
        ///     Deactivate workflow.
        /// </summary>
        DeactivateWorkflow
    }
}