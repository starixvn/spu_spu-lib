namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using DataAccess;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Service.UnitTest;

    public interface ICaseGroupDataAccess
    {
        ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria);

        ICommandResult DeleteCaseGroup(ICriteria criteria);
    }

    public class CaseGroupDataAccess : BaseDataAccess, ICaseGroupDataAccess
    {
        public ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult DeleteCaseGroup(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}