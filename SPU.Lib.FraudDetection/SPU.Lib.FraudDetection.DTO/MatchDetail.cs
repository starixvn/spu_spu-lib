// --------------------------------------------------------------------------
// <copyright file="MatchDetail.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO
{
    using System;
    using RemotingRef;

    public class MatchDetail
    {
        public int SportType { get; set; }

        public string SportName
        {
            get { return RefData.GetSportName(SportType.ToString(), "en", string.Empty); }
        }

        public int LeagueId { get; set; }

        public string LeagueName
        {
            get { return RefData.GetLeagueName(LeagueId.ToString(), "en", string.Empty); }
        }

        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public DateTime EventDate { get; set; }

        public int HomeId { get; set; }

        public string HomeName
        {
            get { return RefData.GetTeamName(HomeId.ToString(), "en", string.Empty); }
        }

        public int AwayId { get; set; }

        public string AwayName
        {
            get { return RefData.GetTeamName(AwayId.ToString(), "en", string.Empty); }
        }
    }
}