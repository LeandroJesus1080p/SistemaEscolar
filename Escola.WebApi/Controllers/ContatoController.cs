using Escola.Models.Entities;
using Escola.Services.Repositories.Contatos;
using Escola.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController(IContatoService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await service.GetAll();

                return Ok(new
                {
                    datas = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await service.GetById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContatoCreateViewModel contato)
        {
            try
            {
                var data = await service.Create(contato);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ContatoViewModel contato)
        {
            try
            {
                await service.Update(contato);
                return Ok(contato);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await service.Delete(id);
                return Ok(id);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
