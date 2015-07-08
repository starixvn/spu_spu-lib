namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.CaseGroup;
    using DataAccess.Interface;
    using DTO;
    using Fanex.NAP.Framework.Command;

    public interface ICaseGroupService
    {
        ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria);

        ICommandResult RemoveCaseGroup(CaseGroupDeleteCriteria criteria);
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

        public ICommandResult RemoveCaseGroup(CaseGroupDeleteCriteria criteria)
        {
            return _caseGroupDataAccess.DeleteCaseGroup(criteria);
        }

        public IList<CaseGroup> SelectCaseGroup(CaseGroupSelectCriteria criteria)
        {
            return GetData<CaseGroup>(criteria).ToList();
        }
    }
}