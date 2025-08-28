using Escola.Models.Entities;
using Escola.Services.Repositories.Disciplinas;
using Escola.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController(IDisciplinaService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await service.GetAll();

                return Ok(data);
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(DisciplinaViewModel disciplina)
        {
            try
            {
                var data = await service.Create(disciplina);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(DisciplinaUpdateViewModel disciplina)
        {
            try
            {
                await service.Update(disciplina);

                return Ok(disciplina);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
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
