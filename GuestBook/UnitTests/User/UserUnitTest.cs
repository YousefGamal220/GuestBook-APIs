using GuestBook.Controllers.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace GuestBook.UnitTests.User
{
    
    public class UserUnitTest
    {
        [Fact]
        public void invalidUserData() {
            GuestBook.Models.User.User user = new Models.User.User { Id = 10, Name = "Yousef", Email = "yousef@yousef.com", Password = "12345" };






        }

    }
}
