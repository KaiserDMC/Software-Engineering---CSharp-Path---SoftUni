using CreditsAppWithDb.Data;
using CreditsAppWithDb.Services;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace TestingDemo.UnitTests
{
    [TestFixture]
    public class CreditDecisionDbTests
    {
        private IEnumerable<CreditDecision> decisions;
        private AppDbContext dbContext;

        [SetUp]
        public void TestInitialize()
        {
            this.decisions = new List<CreditDecision>()
            {
                new CreditDecision(){Id = 1, Score = 100, Decision = "Declined"},
                new CreditDecision(){Id = 2, Score = 600, Decision = "Maybe" },
                new CreditDecision(){ Id = 3, Score = 800, Decision = "Absolutely" }
            };

            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "CreditsInMemoryDb") // Give a Unique name to the DB
                    .Options;
            this.dbContext = new AppDbContext(options);
            this.dbContext.AddRange(this.decisions);
            this.dbContext.SaveChanges();
        }

        [Test]
        public void Test_GetAllCreditDecisions()
        {
            var decisionId = 1;

            ICreditDecisionService service =
                new CreditDecisionService(this.dbContext); // Pass it to Service as dependency
            var decision = service.GetById(decisionId);

            var dbDecision = this.decisions
                .ToList()
                .Find(d => d.Id == decisionId);

            Assert.True(decision != null);
            Assert.True(decision.Score == dbDecision.Score);
            Assert.True(decision.Decision == dbDecision.Decision);
        }
    }
}
