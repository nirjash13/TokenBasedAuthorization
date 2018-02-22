using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace TokenBasedAuthentication.Controllers
{
    /// <summary>
    /// This controller is for test purpose. No business use in our application
    /// </summary>
    [Authorize]
    public class AuthenticationController : ApiController
    {
        [HttpGet]
        [Route("api/data/forall")]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }

        [Infrastructure.Authorize(Roles = "user")]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity) User.Identity;
            return Ok("Hello " + identity.Name);
        }

        [Infrastructure.Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            
            var identity = (ClaimsIdentity) User.Identity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }


        [HttpGet]
        [Route("api/data/foraauthenticated")]
        public IHttpActionResult GetAuthenticatedUsers()
        {
            return Ok("Hello Sir! Now server time is: " + DateTime.Now.ToString());
        }
    }
}