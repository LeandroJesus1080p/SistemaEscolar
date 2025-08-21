using Escola.Services.Repositories.Alunos;
using Escola.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    public class AlunoController(IAlunoService service) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await service.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetId(int id)
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
        public async Task<IActionResult> Create(AlunoViewModel aluno)
        {
            try
            {
                var create = await service.Create(aluno);

                return Ok(create);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(AlunoUpdateViewModel aluno)
        {
            try
            {
                await service.Update(aluno);
                return Ok(aluno);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
