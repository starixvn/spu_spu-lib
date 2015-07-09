namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.CaseGroup;
    using DTO;
    using Fanex.NAP.Framework.Command;
    using UnitTest;

    public interface ICaseGroupService
    {
        ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria);

        ICommandResult RemoveCaseGroup(CaseGroupDeleteCriteria criteria);

        IList<CaseGroup> SelectCaseGroup(CaseGroupSelectCriteria criteria);
    }
}