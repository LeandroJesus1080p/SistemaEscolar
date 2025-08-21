using ePronto.Util;
using Escola.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class BaseController() : ControllerBase
    {

      

    }
}