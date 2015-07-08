namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using System.Collections.Generic;
    using Criteria.CaseGroup;
    using DataAccess;
    using DTO;
    using Fanex.NAP.Framework.Command;
    using Service.UnitTest;

    public interface ICaseGroupDataAccess
    {
        ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria);

        ICommandResult DeleteCaseGroup(CaseGroupDeleteCriteria criteria);
    }

    public class CaseGroupDataAccess : BaseDataAccess, ICaseGroupDataAccess
    {
        public ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteCaseGroup(CaseGroupDeleteCriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}