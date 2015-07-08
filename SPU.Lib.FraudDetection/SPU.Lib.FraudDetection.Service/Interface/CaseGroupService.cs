namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using Criteria.CaseGroup;
    using DataAccess.Interface;
    using Fanex.NAP.Framework.Command;

    public interface ICaseGroupService
    {
        ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria);

        ICommandResult RemoveCaseGroup(CaseGroupRemoveCriteria criteria);
    }

    public class CaseGroupService : QueryService, ICaseGroupService
    {
        private readonly ICaseGroupDataAccess _caseGroupDataAccess;

        public CaseGroupService()
        {
            _caseGroupDataAccess = new CaseGroupDataAccess();
        }

        public CaseGroupService(ICaseGroupDataAccess dataAccess)
        {
            _caseGroupDataAccess = dataAccess;
        }

        public ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria)
        {
            return _caseGroupDataAccess.InsertCaseGroup(criteria);
        }

        public ICommandResult RemoveCaseGroup(CaseGroupRemoveCriteria criteria)
        {
            return _caseGroupDataAccess.DeleteCaseGroup(criteria);
        }
    }
}