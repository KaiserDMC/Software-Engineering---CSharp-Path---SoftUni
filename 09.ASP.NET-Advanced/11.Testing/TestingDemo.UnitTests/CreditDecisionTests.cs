using CreditsApp;
using CreditsApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestingDemo.UnitTests
{
    [TestFixture]
    public class CreditDecisionTests
    {
        [Test]
        public void MakeCreditDecision_ShouldReturnCorrectResult()
        {
            var mockCreditDecisionService = new Mock<ICreditDecisionService>();
            mockCreditDecisionService
                .Setup(p => p.GetDecision(100))
                .Returns("Declined");

            var controller = new CreditDecision(mockCreditDecisionService.Object);
            var result = controller.MakeCreditDecision(100);

            Assert.That(result, Is.EqualTo("Declined"));

            mockCreditDecisionService.VerifyAll();
        }



    }
}
