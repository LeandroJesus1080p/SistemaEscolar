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

                return Ok(new ResultViewModel<IEnumerable<Aluno>>(data));
            }
            catch(Exception ex)
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

                return Ok(new ResultViewModel<Aluno>(data));
            }
            catch(Exception ex)
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

                var data = await service.Create(aluno);

                return Ok(data);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro no servidor"));
            }
       
        }

    }
}
