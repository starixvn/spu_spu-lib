namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.QueryGenerator
{
    using FD.Lib.BusinessManager.QueryGenerator;
    using FD.Lib.Core;
    using FD.Lib.Criteria.Task;
    using FD.Lib.QueryGenerator;
    using NUnit.Framework;

    /// <summary>
    /// General Pre-Condition Query Generator.
    /// </summary>
    [TestFixture]
    public class RuleQueryGeneratorForGroupingIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore]
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
        [Ignore]
        public void When_Group_By_Choice_Then_Generating_Sql_Should_Be_Correct()
        {
            var criteria = GetCriteriaGroupByChoice();
            var caseId = "2";

            var expected = "declare @tempTable table (custid bigint, matchid bigint, transid bigint) insert into @tempTable select ans.custid, ans.matchid, ans.transid from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans with(nolock) on tch.matchid = ans.matchid join (SELECT max(ans.transid) transid, max(ans.transdate) deletetime, ans.livehomescore, ans.liveawayscore , ans.matchid FROM bodb02.dbo.bettrans ans with (nolock) WHERE ans.matchid in ($param1$) AND ans.STATUSID = 101 AND ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) GROUP BY ans.livehomescore, ans.liveawayscore, ans.matchid) msc on msc.matchid = ans.matchid where ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$) and (ans.statusid = 112 AND ans.transdate BETWEEN DATEADD(ss, -(select p.ParamValue from Parameters p with(nolock) where p.ParamName = 'SecondsToGoal') , msc.deletetime) AND msc.deletetime AND ans.livehomescore = msc.livehomescore AND ans.liveawayscore = msc.liveawayscore) select tbl.* from @tempTable tbl inner join (select tt.custid, tt.matchid from @tempTable tt group by tt.custid, tt.matchid having COUNT(tt.transid) >= 5) res on res.custid = tbl.custid AND res.matchid = tbl.matchid";

            var generator = RuleQueryGeneratorFactory.CreateRuleQueryGenerator(int.Parse(caseId), criteria);

            var actual = criteria.TaskRules = generator.GenerateQuery();
        }

        [Test]
        [Ignore]
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

        [Test]
        [Ignore]
        public void When_Scan_Office_By_Ip()
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

        [Test]        
        public void When_Generate_Sql_For_Sum_WinLoss_By_Match()
        {
            var criteria = GetCriteriaForSumWinLossByMatch();
            var caseId = "1";

            var expected = @"DECLARE @HomePickers TABLE (custid bigint, matchid bigint, transid bigint, livehomescore int, liveawayscore int, winlost bigint) DECLARE @AwayPickers TABLE (custid bigint, matchid bigint, transid bigint, livehomescore int, liveawayscore int, winlost bigint)\nINSERT INTO @HomePickers\nSELECT ans.custid,\n       ans.matchid,\n       ans.transid,\n       ans.livehomescore,\n       ans.liveawayscore,\n       ans.winlost\nFROM bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans with(nolock) on tch.matchid = ans.matchid inner join bodb02.dbo.odds dds with(nolock) on dds.matchid = ans.matchid and dds.oddsid = ans.oddsid \nWHERE ans.bettype = 1\n  AND ans.betteam = 'h'\n  AND ans.matchid IN ($param1$)  and ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$) and (ans.stake * ans.actualrate >= 50*0.01*coalesce(dds.maxbet, 0) AND ans.bettype = 1)\n  INSERT INTO @AwayPickers\n  SELECT ans.custid,\n         ans.matchid,\n         ans.transid,\n         ans.livehomescore,\n         ans.liveawayscore,\n         ans.winlost\n  FROM bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans with(nolock) on tch.matchid = ans.matchid inner join bodb02.dbo.odds dds with(nolock) on dds.matchid = ans.matchid and dds.oddsid = ans.oddsid  WHERE ans.bettype = 1\n  AND ans.betteam = 'a'\n  AND ans.matchid IN ($param1$)  and ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$) and (ans.stake * ans.actualrate >= 50*0.01*coalesce(dds.maxbet, 0) AND ans.bettype = 1)\n\nDECLARE @tblScores TABLE (matchid INT, custid INT, livehomescore TINYINT, liveawayscore TINYINT)  INSERT INTO @tblScores(matchid, custid, livehomescore, liveawayscore) SELECT ans.matchid, ans.custid, ans.livehomescore, ans.liveawayscore FROM @HomePickers ans INNER JOIN @AwayPickers b ON ans.custid = b.custid \tAND ans.matchid = b.matchid \tAND ans.liveawayscore = b.liveawayscore \tAND ans.livehomescore = b.livehomescore GROUP BY ans.custid,          ans.matchid,                   ans.liveawayscore,          ans.livehomescore HAVING (sum(ans.winlost) + sum(b.winlost)) > 0  DECLARE @tblRawResults TABLE(matchid INT, custid INT, transid INT) INSERT INTO @tblRawResults(matchid, custid, transid) SELECT hp.matchid, hp.custid, hp.transid FROM @HomePickers hp INNER JOIN @tblScores sc ON sc.matchid = hp.matchid \tAND sc.custid = hp.custid \tAND sc.livehomescore = hp.livehomescore \tAND sc.liveawayscore = hp.liveawayscore UNION ALL SELECT ap.matchid, ap.custid, ap.transid FROM @AwayPickers ap INNER JOIN @tblScores sc ON sc.matchid = ap.matchid \tAND sc.custid = ap.custid \tAND sc.livehomescore = ap.livehomescore \tAND sc.liveawayscore = ap.liveawayscore  SELECT a.matchid, a.custid, a.transid FROM @tblRawResults a $additionalsumwl$";

            var queryGeneratorFactory = new QueryGeneratorFactory(
                   int.Parse(caseId),
                   criteria,
                   10);

            var generator = queryGeneratorFactory.GetQueryGenerator(QueryGeneratorType.Rule);

            var actual = criteria.TaskRules = generator.GenerateQuery();

            Assert.AreEqual(expected, actual);
        }

        #region Sample Data

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
                TaskRulesOriginal =
                    "Ticket Status = Won@AND#TransDate = In Danger Period@AND#Group Betting Count By Choice >= 5",
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
                PreconConfigs = "2#6",
                RuleConfigs = "9#22#10",
                TaskDesc = "Scan matches and find suspicous customers",
                TaskName = "Scan matches and find suspicous customers",
                TaskPreconditions = "Match Status = %completed%@AND#Sport = 1",
                TaskPreconditionsFormatted = "Match Status = %completed%@AND#Sport = 1",
                TaskPreconditionsOriginal = "Match Status = Completed@AND#Sport = Soccer",
                TaskRules = "Ticket Status > 112@AND#Group Betting Count By Choice > 50@AND#Bet Type = 1",
                TaskRulesFormatted = "Ticket Status > 112@AND#Group Betting Count By Choice > 50@AND#Bet Type = 1",
                TaskRulesOriginal = "Ticket Status > Won@AND#Group Betting Count By Choice > 50@AND#Bet Type = Handicap",
                TaskId = 5
            };

            return criteria;
        }


        private TaskUpdateCriteria GetCriteriaForSumWinLossByMatch()
        {
            var criteria = new TaskUpdateCriteria()
            {
                CreatorId = 8,
                EventId = 1,
                Interval = 60,
                IntervalType = "Second",
                IsActive = true,
                IsCheckNotScanned = true,
                NextActionIdList = "1",
                NextActionTargetIdList = "1",
                PreconConfigs = "2#5#6#3",
                RuleConfigs = "7#15#10#21",
                TaskDesc = "Scan matches and find suspicous customers",
                TaskName = "Scan matches and find suspicous customers",
                TaskPreconditions = "Match Status = %completed%@AND#League Type = gue.IsMainMarket@AND#Sport = 1@AND#$MatchState$",
                TaskPreconditionsFormatted = "Match Status = %completed%@AND#League Type = gue.IsMainMarket@AND#Sport = 1@AND#$MatchState$",
                TaskPreconditionsOriginal = "Match Status = Completed@AND#League Type = Main Markets@AND#Sport = Soccer@AND#Match State = Not Scanned",
                TaskRules = "Stake >= 50*0.01*% Max Bet@AND#Bet Type = 1@AND#Arbitrage@AND#Sum WinLoss by Match > %100%",
                TaskRulesFormatted = "Stake >= 50*0.01*% Max Bet@AND#Bet Type = 1@AND#Arbitrage@AND#Sum WinLoss by Match > %100%",
                TaskRulesOriginal = "Stake >= 50 % Max Bet@AND#Bet Type = Handicap@AND#Arbitrage = Yes@AND#Sum WinLoss by Match > 100",
                TaskId = 4
            };

            return criteria;
        }

        #endregion
    }
}