using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TokenBasedAuthentication.RestLibrary.Security;

namespace TokenBasedAuthentication.Tests
{
    [TestClass]
    public class RestApiTests
    {
        [TestMethod]
        public void ReturnsAuthorizedPersonNameIfValid()
        {
            var security = new SecurityService();
            var token = security.GetToken("admin", "admin123");

            var data = security.TestForAuthorizedUsers(token);

            Assert.IsTrue(data.Contains("Administrator"));
        }

        [TestMethod]
        public void AuthorizationDeniedForUsersWithUnauthorizedRole()
        {
            var security = new SecurityService();
            var token = security.GetToken("admin", "admin123");
            var authenticationTest = security.TestAutheorizationForUserWithUnauthorizedRole(token);

            Assert.IsTrue(authenticationTest.Contains(HttpStatusCode.Forbidden.ToString()));
        }
    }
}