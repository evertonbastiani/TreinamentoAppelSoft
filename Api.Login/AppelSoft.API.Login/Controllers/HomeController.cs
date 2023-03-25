using Microsoft.AspNetCore.Mvc;

namespace AppelSoft.API.Login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequestModel credentials)
        {
            LoginRequestResponse response = new LoginRequestResponse();

            response.Login = credentials.Login;
            response.Id = 0;
            response.Token = "ASDFJKLASDJFKLSDKLAD";
            return Ok(response);
        }
    }
}
