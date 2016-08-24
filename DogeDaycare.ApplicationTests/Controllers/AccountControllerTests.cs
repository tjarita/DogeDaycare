using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogeDaycare.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogeDaycare.Web.Models.Account;

namespace DogeDaycare.Web.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            RegisterViewModel input = new RegisterViewModel
            {
                EmailAddress = "test.com",
                IsExternalLogin = false,
                FirstName = "testmethod",
                Password = "123",
                Surname = "last",
                UserName = "testermethod"
            };


            throw new NotImplementedException();
        }
    }
}