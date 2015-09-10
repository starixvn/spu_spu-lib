// --------------------------------------------------------------------------
// <copyright file="QueryGeneratorFactory.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueryGenerator
{   
    using System;
    using BusinessManager.QueryGenerator;
    using Criteria.Task;

    /// <summary>
    /// Query Generator Factory.
    /// </summary>
    public class QueryGeneratorFactory
    {
        public QueryGeneratorFactory(
            int fraudCaseId,
            TaskInfoCriteria taskInfoCriteria,
            int chunkOfSelection)
        {
            FraudCaseId = fraudCaseId;
            Criteria = taskInfoCriteria;
            ChunkOfSelection = chunkOfSelection;
        }

        private int FraudCaseId { get; set; }

        private TaskInfoCriteria Criteria { get; set; }

        private int ChunkOfSelection { get; set; }

        /// <summary>
        /// Get Query Generator.
        /// </summary>
        /// <param name="ruleType">Rule Type.</param>
        /// <returns>Query Generator object.</returns>
        public QueryGenerator GetQueryGenerator(
            QueryGeneratorType ruleType)
        {
            switch (ruleType)
            {
                case QueryGeneratorType.PreCondition:
                    return new PreConditionQueryGenerator(FraudCaseId, Criteria, ChunkOfSelection);

                case QueryGeneratorType.Rule:
                    return RuleQueryGeneratorFactory.CreateRuleQueryGenerator(FraudCaseId, Criteria);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
