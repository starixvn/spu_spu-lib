using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using System.Linq;
    using DataAccess.Interface;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    public class FakeCaseGroupDataAccess : ICaseGroupDataAccess
    {
        public List<CaseGroup> CaseGroups { get; set; }

        public FakeCaseGroupDataAccess()
        {
            CaseGroups = new List<CaseGroup>();
        }

        public ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria)
        {
            if (CaseGroups.Any(t => t.GroupId == criteria.GroupId))
            {
                return new CommandResult
                {
                    Code = 1041
                };
            }

            CaseGroups.Add(new CaseGroup
            {
                CaseId = criteria.CaseId,
                GroupId = criteria.GroupId
            });

            return new CommandResult();
        }

        public ICommandResult DeleteCaseGroup(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }

    public class CaseGroup
    {
        public int CaseId { get; set; }

        public int GroupId { get; set; }
    }
}