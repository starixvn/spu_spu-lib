// --------------------------------------------------------------------------
// <copyright file="TaskCheckAllTicketsSettledCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron" date="2016.05.24">Created</change>
// </history>

namespace FD.Lib.Criteria.Task
{
    using Fanex.Data.Repository;

    public class TaskCheckAllTicketsSettledCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public string BettypeIds { get; set; }

        public override string GetSettingKey()
        {
            return "FD_TaskCheckAllTicketsSettled";
        }

        public override bool IsValid()
        {
            return MatchId > 0;
        }
    }
}
