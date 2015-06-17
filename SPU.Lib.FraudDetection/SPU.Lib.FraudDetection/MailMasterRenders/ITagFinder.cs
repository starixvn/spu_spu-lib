using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public interface ITagFinder
    {
        string  Tag { get; set; }

        IList<int> GetTagPositions(string content);
    }
}