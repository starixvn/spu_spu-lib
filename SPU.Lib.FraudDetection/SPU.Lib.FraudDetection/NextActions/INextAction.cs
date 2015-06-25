namespace SPU.Lib.FraudDetection.NextActions
{
    using System.Collections.Generic;
    using DTO;

    /// <summary>
    ///     BaseAction Class.
    /// </summary>
    public interface INextAction
    {
        IList<SuspiciousInfo> SuspicionList { get; set; }

        void TakeAction();
    }
}