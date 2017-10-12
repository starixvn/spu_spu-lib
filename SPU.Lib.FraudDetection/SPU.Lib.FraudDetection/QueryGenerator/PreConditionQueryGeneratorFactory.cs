namespace FD.Lib.BusinessManager.QueryGenerator
{
    using Criteria.Task;
    using Lib.QueryGenerator;

    public static class PreConditionQueryGeneratorFactory
    {
        public static PreConditionQueryGenerator CreatePreConditionQueryGenerator(int fraudCaseId, TaskInfoCriteria criteria, int chunkOfSelection)
        {
            if (criteria.ActivityId == (int)ActivityType.ScanCustomerSyncData)
            {
                return new PreConditionQueryGeneratorForSyncDataWithFPS(fraudCaseId, criteria, chunkOfSelection);
            }

            return new PreConditionQueryGenerator(fraudCaseId, criteria, chunkOfSelection);
        }
    }
}