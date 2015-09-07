namespace FD.Lib.Service.UnitTest
{
    using Core;
    using Criteria.Task;
    using Implement;
    using NUnit.Framework;

    [TestFixture]
    public class TaskServiceIntegrationTest : IntegrationTest
    {
        [Test]
        public void When_Insert_New_CaseGroup_Then_Method_InsertCaseGroup_Should_Be_Called()
        {
            var sut = new TaskService();

            var task = sut.GetTaskForExecuting(new TaskGetForExecutingCriteria()
            {
                TaskId = 1
            });
        }


        [Test]
        public void When_Execute_Rule_For_Grouping_Then_Method_InsertCaseGroup_Should_Be_Called()
        {
            var sut = new TaskService();
            var sqlQueryString =
                "declare @tempTable table (custid bigint, matchid bigint, transid bigint, betteam nvarchar(20), currency tinyint)  insert into @tempTable  select ans.custid, ans.matchid, ans.transid, ans.betteam, ans.currency from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans with(nolock) on tch.matchid = ans.matchid  where ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in (14284614) and (ans.statusid > 112)   select tbl.custid, tbl.matchid, tbl.transid, convert(nvarchar(50),tbl.betteam) + '-' + convert(nvarchar(50),tbl.currency) as groupby  from @tempTable tbl  inner join (select tt.betteam, tt.currency  from @tempTable tt group by tt.betteam, tt.currency having COUNT(1) > 10) res on res.betteam = tbl.betteam AND res.currency = tbl.currency";
            var task = sut.ExecuteRuleForGrouping(sqlQueryString, 5, 3);            
        }
    }
}