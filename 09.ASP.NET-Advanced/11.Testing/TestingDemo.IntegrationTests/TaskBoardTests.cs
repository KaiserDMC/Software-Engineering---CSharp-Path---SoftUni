using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestingDemo.IntegrationTests
{
    public class TaskBoardTests
    {
        [Test]
        public async Task TestAllBoards()
        {
            // Arrange
            var httpClient = new HttpClient();

            // Act: send a GET request
            var response = await httpClient.GetAsync("https://taskboard.nakov.repl.co/boards");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}