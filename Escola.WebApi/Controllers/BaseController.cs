using ePronto.Util;
using Escola.Models.Entities;
using Escola.Models.Mvvm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace eGreja.Api.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class BaseController() : ControllerBase
    {

      

    }
}