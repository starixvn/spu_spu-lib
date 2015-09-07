using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FD.Lib.Service.Implement
{
    using Criteria.SuspiciousInfo;
    using Fanex.NAP.Framework.Command;

    public interface ISuspiciousGroupInfoService
    {
        ICommandResult InsertSuspiciousGroupInfo(SuspiciousGroupInfoInsertCriteria criteria);
    }
}
