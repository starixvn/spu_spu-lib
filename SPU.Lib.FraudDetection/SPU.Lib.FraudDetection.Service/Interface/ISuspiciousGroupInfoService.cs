namespace FD.Lib.Service.Interface
{
    using Criteria.SuspiciousInfo;
    using Fanex.NAP.Framework.Command;

    public interface ISuspiciousGroupInfoService
    {
        ICommandResult InsertSuspiciousGroupInfo(SuspiciousGroupInfoInsertCriteria criteria);
    }
}
