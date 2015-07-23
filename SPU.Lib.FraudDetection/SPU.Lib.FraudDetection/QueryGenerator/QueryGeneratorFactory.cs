// --------------------------------------------------------------------------
// <copyright file="QueryGeneratorFactory.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.QueryGenerator
{   
    using System;

    /// <summary>
    /// Query Generator Factory.
    /// </summary>
    public class QueryGeneratorFactory
    {
        private const int CheckBettingHistory = 2;

        private int FraudCaseId { get; set; }

        private int EventId { get; set; }

        private bool IsCheckNotScanned { get; set; }

        private int ChunkOfSelection { get; set; }

        public QueryGeneratorFactory(
            int fraudCaseId,
            int eventId,
            bool isCheckNotScanned,
            int chunkOfSelection)
        {
            FraudCaseId = fraudCaseId;
            EventId = eventId;
            IsCheckNotScanned = isCheckNotScanned;
            ChunkOfSelection = chunkOfSelection;
        }

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
                    return new PreConditionQueryGenerator(
                        FraudCaseId,
                        EventId == CheckBettingHistory,
                        IsCheckNotScanned,
                        ChunkOfSelection);

                case QueryGeneratorType.Rule:
                    return new RuleQueryGenerator(FraudCaseId);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
