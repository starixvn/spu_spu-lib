// --------------------------------------------------------------------------
// <copyright file="PreConditionQueryGenerator.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueryGenerator
{
    using System;
    using System.Linq;
    using BusinessManager.QueryGenerator;
    using Core;
    using Criteria.Parameter;
    using Criteria.Task;
    using Moq;
    using NUnit.Framework;
    using QueueManagement.SendingTasks;
    using Service.Implement;

    /// <summary>
    /// General Pre-Condition Query Generator.
    /// </summary>
    [TestFixture]
    public class RuleQueryGeneratorForGroupingIntegrationTest : IntegrationTest
    {
        [Test]
        public void When_Group_By_Customer_Then_Generating_Sql_Should_Be_Correct()
        {
            var criteria = GetCriteriaGroupByCustomer();
            var caseId = "2";

            var expected = "declare @tempTable table (custid bigint, matchid bigint, transid bigint) insert into @tempTable select ans.custid, ans.matchid, ans.transid from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans with(nolock) on tch.matchid = ans.matchid join (SELECT max(ans.transid) transid, max(ans.transdate) deletetime, ans.livehomescore, ans.liveawayscore , ans.matchid FROM bodb02.dbo.bettrans ans with (nolock) WHERE ans.matchid in ($param1$) AND ans.STATUSID = 101 AND ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) GROUP BY ans.livehomescore, ans.liveawayscore, ans.matchid) msc on msc.matchid = ans.matchid where ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$) and (ans.statusid = 112 AND ans.transdate BETWEEN DATEADD(ss, -(select p.ParamValue from Parameters p with(nolock) where p.ParamName = 'SecondsToGoal') , msc.deletetime) AND msc.deletetime AND ans.livehomescore = msc.livehomescore AND ans.liveawayscore = msc.liveawayscore) select tbl.* from @tempTable tbl inner join (select tt.custid, tt.matchid from @tempTable tt group by tt.custid, tt.matchid having COUNT(tt.transid) >= 5) res on res.custid = tbl.custid AND res.matchid = tbl.matchid";

            var generator = RuleQueryGeneratorFactory.CreateRuleQueryGenerator(int.Parse(caseId), criteria);

            var actual = criteria.TaskRules = generator.GenerateQuery();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_Group_By_Choice_Then_Generating_Sql_Should_Be_Correct()
        {
            var criteria = GetCriteriaGroupByChoice();
            var caseId = "2";

            var expected = "declare @tempTable table (custid bigint, matchid bigint, transid bigint) insert into @tempTable select ans.custid, ans.matchid, ans.transid from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans with(nolock) on tch.matchid = ans.matchid join (SELECT max(ans.transid) transid, max(ans.transdate) deletetime, ans.livehomescore, ans.liveawayscore , ans.matchid FROM bodb02.dbo.bettrans ans with (nolock) WHERE ans.matchid in ($param1$) AND ans.STATUSID = 101 AND ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) GROUP BY ans.livehomescore, ans.liveawayscore, ans.matchid) msc on msc.matchid = ans.matchid where ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$) and (ans.statusid = 112 AND ans.transdate BETWEEN DATEADD(ss, -(select p.ParamValue from Parameters p with(nolock) where p.ParamName = 'SecondsToGoal') , msc.deletetime) AND msc.deletetime AND ans.livehomescore = msc.livehomescore AND ans.liveawayscore = msc.liveawayscore) select tbl.* from @tempTable tbl inner join (select tt.custid, tt.matchid from @tempTable tt group by tt.custid, tt.matchid having COUNT(tt.transid) >= 5) res on res.custid = tbl.custid AND res.matchid = tbl.matchid";

            var generator = RuleQueryGeneratorFactory.CreateRuleQueryGenerator(int.Parse(caseId), criteria);

            var actual = criteria.TaskRules = generator.GenerateQuery();

        }

        [Test]
        public void When_Group_By_Choice_Then_Generating_Sql_Should_Be_Correct2()
        {
            var criteria = GetCriteriaGroupByChoice2();
            var caseId = "1";

            var expected = "declare @tempTable table (custid bigint, matchid bigint, transid bigint) insert into @tempTable select ans.custid, ans.matchid, ans.transid from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans with(nolock) on tch.matchid = ans.matchid join (SELECT max(ans.transid) transid, max(ans.transdate) deletetime, ans.livehomescore, ans.liveawayscore , ans.matchid FROM bodb02.dbo.bettrans ans with (nolock) WHERE ans.matchid in ($param1$) AND ans.STATUSID = 101 AND ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) GROUP BY ans.livehomescore, ans.liveawayscore, ans.matchid) msc on msc.matchid = ans.matchid where ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$) and (ans.statusid = 112 AND ans.transdate BETWEEN DATEADD(ss, -(select p.ParamValue from Parameters p with(nolock) where p.ParamName = 'SecondsToGoal') , msc.deletetime) AND msc.deletetime AND ans.livehomescore = msc.livehomescore AND ans.liveawayscore = msc.liveawayscore) select tbl.* from @tempTable tbl inner join (select tt.custid, tt.matchid from @tempTable tt group by tt.custid, tt.matchid having COUNT(tt.transid) >= 5) res on res.custid = tbl.custid AND res.matchid = tbl.matchid";

            var queryGeneratorFactory = new QueryGeneratorFactory(
                   int.Parse(caseId),
                   criteria,
                   10);

            var generator = queryGeneratorFactory.GetQueryGenerator(QueryGeneratorType.Rule);

            var actual = criteria.TaskRules = generator.GenerateQuery();

            Assert.AreEqual(expected, actual);
        }

        private TaskUpdateCriteria GetCriteriaGroupByCustomer()
        {
            var criteria = new TaskUpdateCriteria()
            {
                CreatorId = 8,
                EventId = 1,
                Interval = 10,
                IntervalType = "Second",
                IsActive = true,
                IsCheckNotScanned = true,
                NextActionIdList = "1",
                NextActionTargetIdList = "1",
                PreconConfigs = "2#3#5#6",
                RuleConfigs = "9#8#16#17",
                TaskDesc = "Scan matches and find suspicous customers",
                TaskName = "Scan matches and find suspicous customers",
                TaskPreconditions =
                    "Match Status = %completed%@AND#1=1@AND#League Type = gue.IsMainMarket@AND#Sport = 1",
                TaskPreconditionsFormatted =
                    "Match Status = %completed%@AND#1=1@AND#League Type = gue.IsMainMarket@AND#Sport = 1",
                TaskPreconditionsOriginal =
                    "Match Status = Completed@AND#Match State = Not Scanned@AND#League Type = Main Markets@AND#Sport = Soccer",
                TaskRules = "Ticket Status = 112@AND#NEARTHEGOAL@AND#Bet Count On A Match >= 5",
                TaskRulesFormatted = "Ticket Status = 112@AND#NEARTHEGOAL@AND#Bet Count On A Match >= 5",
                TaskRulesOriginal = "Ticket Status = Won@AND#TransDate = In Danger Period@AND#Bet Count On A Match >= 5",
                TaskId = 3
            };

            return criteria;
        }

        private TaskUpdateCriteria GetCriteriaGroupByChoice()
        {
            var criteria = new TaskUpdateCriteria()
            {
                CreatorId = 8,
                EventId = 1,
                Interval = 10,
                IntervalType = "Second",
                IsActive = true,
                IsCheckNotScanned = true,
                NextActionIdList = "1",
                NextActionTargetIdList = "1",
                PreconConfigs = "2#3#5#6",
                RuleConfigs = "9#8#16#22",
                TaskDesc = "Scan matches and find suspicous customers",
                TaskName = "Scan matches and find suspicous customers",
                TaskPreconditions =
                    "Match Status = %completed%@AND#1=1@AND#League Type = gue.IsMainMarket@AND#Sport = 1",
                TaskPreconditionsFormatted =
                    "Match Status = %completed%@AND#1=1@AND#League Type = gue.IsMainMarket@AND#Sport = 1",
                TaskPreconditionsOriginal =
                    "Match Status = Completed@AND#Match State = Not Scanned@AND#League Type = Main Markets@AND#Sport = Soccer",
                TaskRules = "Ticket Status = 112@AND#NEARTHEGOAL@AND#Group Betting Count By Choice >= 5",
                TaskRulesFormatted = "Ticket Status = 112@AND#NEARTHEGOAL@AND#Group Betting Count By Choice >= 5",
                TaskRulesOriginal = "Ticket Status = Won@AND#TransDate = In Danger Period@AND#Group Betting Count By Choice >= 5",
                TaskId = 3
            };

            return criteria;
        }

        private TaskUpdateCriteria GetCriteriaGroupByChoice2()
        {
            var criteria = new TaskUpdateCriteria()
            {
                CreatorId = 8,
                EventId = 1,
                Interval = 10,
                IntervalType = "Second",
                IsActive = true,
                IsCheckNotScanned = true,
                NextActionIdList = "1",
                NextActionTargetIdList = "1",
                PreconConfigs = "2",
                RuleConfigs = "22#9",
                TaskDesc = "Scan matches and find suspicous customers",
                TaskName = "Scan matches and find suspicous customers",
                TaskPreconditions = "Match Status = %completed%",
                TaskPreconditionsFormatted = "Match Status = %completed%",
                TaskPreconditionsOriginal = "Match Status = Completed",
                TaskRules = "Group Betting Count By Choice > 10@AND#Ticket Status > 112",
                TaskRulesFormatted = "Group Betting Count By Choice > 10@AND#Ticket Status > 112",
                TaskRulesOriginal = "Group Betting Count By Choice > 10@AND#Ticket Status > Won",
                TaskId = 5
            };

            return criteria;
        }
    }
}
