// --------------------------------------------------------------------------
// <copyright file="QueryGeneratorType.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.QueryGenerator
{
    /// <summary>
    /// Query Generator Type.
    /// </summary>
    public enum QueryGeneratorType
    {
        /// <summary>
        /// No Query Generator type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Generating Pre-Condition.
        /// </summary>
        PreCondition = 1,

        /// <summary>
        /// Generating Rules.
        /// </summary>
        Rule = 2
    }
}
