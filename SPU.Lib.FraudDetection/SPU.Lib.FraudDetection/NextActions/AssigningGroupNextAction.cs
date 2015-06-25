namespace SPU.Lib.FraudDetection.NextActions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria;
    using DTO;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    ///     Assign suspicious customers to a customer group.
    /// </summary>
    public class AssigningGroupNextAction : INextAction
    {
        public int GroupId { get; set; }

        public IList<SuspiciousInfo> SuspicionList { get; set; }

        public IGroupService GroupService { get; set; }

        public AssigningGroupNextAction(int groupId)
        {
            GroupId = groupId;
            SuspicionList = new List<SuspiciousInfo>();
            GroupService = new GroupService();
        }

        public AssigningGroupNextAction(int groupId, IGroupService groupService)
        {
            GroupId = groupId;
            SuspicionList = new List<SuspiciousInfo>();
            GroupService = groupService;
        }

        public void TakeAction()
        {
            AssignSuspiciousCustomersToGroup();
        }

        private void AssignSuspiciousCustomersToGroup()
        {
            var custIdList = SuspicionList.Select(t => t.CustId).Distinct().ToList();

            var criteria = new CustomerGroupAssignCriteria
            {
                GroupId = GroupId,
                CustIdList = string.Join(",", custIdList)
            };

            var result = GroupService.AssignCustomerToGroup(criteria);

            if (result.IsSuccessful == false)
            {
                Logger.Log.Error("Error  AssignCustomerGroup : " + result.Message);
            }
        }
    }
}