using System.Net;
using AuthenticationServer.RestLibrary.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationServer.Tests
{
    [TestClass]
    public class RestApiTests
    {
        [TestMethod]
        public void ReturnsAuthorizedPersonNameIfValid()
        {
            var security = new SecurityService();
            var token = security.GetToken("admin", "Admin123");

            var data = security.TestForAuthorizedUsers(token);

            Assert.IsTrue(data.Contains("Administrator"));
        }

        [TestMethod]
        public void AuthorizationDeniedForUnAuthenticatedUsers()
        {
            var security = new SecurityService();
            var token = security.GetToken("admin", "Admin123");
            var authenticationTest = security.TestAuthenticatedUsers(token);

            Assert.IsTrue(authenticationTest.Contains("Authorization has been denied for this request"));
        }

        [TestMethod]
        public void AuthorizationDeniedForUsersWithUnauthorizedRole()
        {
            var security = new SecurityService();
            var token = security.GetToken("admin", "Admin123");
            var authenticationTest = security.TestAutheorizationForUserWithUnauthorizedRole(token);

            Assert.IsTrue(authenticationTest.Contains(HttpStatusCode.Forbidden.ToString()));
        }
    }
}