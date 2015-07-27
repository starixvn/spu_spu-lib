namespace SPU.Lib.FraudDetection.NextActions
{
    public enum NextActionType
    {
        /// <summary>
        /// No Next Action.
        /// </summary>
        None = 0,

        /// <summary>
        /// Assign customers to group.
        /// </summary>
        AssigningGroup = 1,

        /// <summary>
        /// Send email to senior.
        /// </summary>
        SendingEmail = 2
    }
}