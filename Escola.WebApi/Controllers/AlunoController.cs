using eGreja.Api.Controllers;
using Escola.Models.Entities;
using Escola.Models.Extensions;
using Escola.Models.Mvvm;
using Escola.Services.Repositories.Alunos;
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

                if (data == null) return NotFound(new ResultViewModel<Aluno>("Alunos não encontrados"));

                return Ok(new ResultViewModel<IEnumerable<Aluno>>(data));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Aluno>>("Falha no servidor"));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var data = await service.GetById(id);

                if (data == null) return NotFound(new ResultViewModel<Aluno>("Aluno não encontrado"));

                return Ok(new ResultViewModel<Aluno>(data));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Falha no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<Aluno>(ModelState.GetErrors()));

                await service.Create(aluno);

                return Ok(aluno);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro no servidor"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Aluno aluno)
        {
            try
            {
                if (aluno == null) return NotFound(new ResultViewModel<Aluno>("Aluno é nulo"));

                await service.Update(aluno);
                return Ok(new ResultViewModel<Aluno>(aluno));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro no servidor"));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0) return NotFound(new ResultViewModel<Aluno>("Aluno não encontrado"));
                
                await service.Delete(id);
                return Ok(id);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro no servidor"));
            }
        }
    }
}
