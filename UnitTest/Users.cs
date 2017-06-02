using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImperialRegister.Controllers;

namespace UnitTest
{
    [TestClass]
    public class Users
    {
        [TestMethod]
        public void TestCreateRedirect()
        {
            UsersController controllerUsersTesting = new UsersController();
            var result = controllerUsersTesting.Create() as ViewResult;
            Assert.AreEqual("create", result.ViewName);
        }
    }
}
