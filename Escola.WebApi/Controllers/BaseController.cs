using ePronto.Util;
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
        protected IActionResult CathError(Exception ex) => Ok(new
        {
            success = false,
            message = GetError(ex)
        });
        
        private static string GetError(Exception data)
        {
            List<string> result = [];

            try
            {
                if (data == null)
                {
                    result.Add("Falha no processamento");
                }
                else
                {
                    // adiciona os erros de validação e entity
                    if (data.Data != null && data.Data.Values != null)
                    {
                        foreach (object? item in data.Data.Values)
                            if (item != null) result.Add(Converters.ToString(item));
                    }
                }

                if (result.Count == 0 && data != null)
                    result.Add(data.Message);

                return string.Join(". ", result.ToList());

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}