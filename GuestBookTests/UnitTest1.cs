using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;
using GuestBook;
using GuestBook.Controllers.Authentication;

namespace GuestBookTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        public UnitTest1(Microsoft.Extensions.Configuration.IConfiguration configuration) {
            this.configuration = configuration;
        }
        [TestMethod]
public void OptimisticRegisteration()
{
            GuestBook.Models.User.User user = new GuestBook.Models.User.User { Id = 12, Name = "Yousef", Email = "yousef@yousef.com", Password = "12345" };

            var controller = new AuthController(configuration);

            IActionResult result = controller.register(user);

            HttpStatusCode resultStatusCode = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK;

            Assert.AreEqual(resultStatusCode, expectedStatusCode);


        }

        [TestMethod, Description("This test tries to enter same userId")]
        public void PessimisticRegistrationSameUser() {
            GuestBook.Models.User.User user = new GuestBook.Models.User.User { Id = 11, Name = "Yousef", Email = "yousef@yousef.com", Password = "12345" };
            
            var controller = new AuthController(configuration);
            IActionResult result = controller.register(user);

            HttpStatusCode resultStatusCode = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            HttpStatusCode expectedStatusCode = HttpStatusCode.BadRequest;

            Assert.AreEqual(resultStatusCode, expectedStatusCode);
        }

        [TestMethod, Description("Tries to enter empty user")]
        public void PessimisticRegistrationNullUser() {
            GuestBook.Models.User.User user = null;

            var controller = new AuthController(configuration);
            IActionResult result = controller.register(user);

            HttpStatusCode resultStatusCode = (HttpStatusCode)result.GetType().GetProperty("StatusCode").GetValue(result, null);
            HttpStatusCode expectedStatusCode = HttpStatusCode.NotFound;

            Assert.AreEqual(resultStatusCode, expectedStatusCode);
        }
    }
}