using Escola.Services.Repositories.CreateTokens;
using Escola.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(TokenService service) : ControllerBase
    {
        [HttpPost("v1/accounts/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var token = await service.Login(model);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
