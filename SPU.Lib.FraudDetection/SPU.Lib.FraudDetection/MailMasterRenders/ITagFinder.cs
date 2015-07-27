namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    using System.Collections.Generic;

    public interface ITagFinder
    {
        string Tag { get; set; }

        IList<int> GetTagPositions(string content);
    }
}