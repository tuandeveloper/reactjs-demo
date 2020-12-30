using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Report.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController : ControllerBase
    {
        static readonly string[] scopeRequiredByApi = new string[] { "Employees.ReadReport.All" };

        public IActionResult Index()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            return Ok(new { Text = "Test stuff with Authorize Attribute." });
        }

        [HttpGet("anonymous")]
        [AllowAnonymous]
        public IActionResult Anonymous()
        {
            return Ok(new { Text = "I'm an anonymous person." });
        }
    }
}
