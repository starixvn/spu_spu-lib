// --------------------------------------------------------------------------
// <copyright file="FDExportExcel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.13">Created</change>
// </history>

namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    using System;
    using RemotingRef;

    public class FraudCaseDetailSummary
    {
        public int MatchId { get; set; }

        public int CaseId { get; set; }

        public DateTime EventDate { get; set; }

        public int CustomerCount { get; set; }

        public int BetCount { get; set; }

        public int HomeId { get; set; }

        public string TransList { get; set; }

        public string CaseName { get; set; }

        public string HomeName
        {
            get
            {
                if (HomeId <= 0)
                {
                    return string.Empty;
                }

                return RefData.GetTeamName(HomeId.ToString(), "en", string.Empty);
            }
        }

        public int AwayId { get; set; }

        public string AwayName
        {
            get
            {
                if (AwayId <= 0)
                {
                    return string.Empty;
                }

                return RefData.GetTeamName(AwayId.ToString(), "en", string.Empty);
            }
        }
    }
}