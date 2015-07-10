namespace SPU.Lib.FraudDetection.NextActions
{
    using System;

    /// <summary>
    ///     ActionFactory Class.
    /// </summary>
    public static class NextActionFactory
    {
        public static INextAction GetNextAction(NextActionType actionType, int targetId, int caseId)
        {
            switch (actionType)
            {
                case NextActionType.AssigningGroup:
                    return new AssigningGroupNextAction(targetId, caseId);

                case NextActionType.SendingEmail:
                    return new SendingEmailNextAction(targetId);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}