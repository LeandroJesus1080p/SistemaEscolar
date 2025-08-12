using eGreja.Api.Controllers;
using ePronto.Util;
using Escola.Models.Entities;
using Escola.Services.Repositories.Alunos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    public class AlunoController(IAlunoService service) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get(string? nome = null, string? sort = "Nome", bool sortAsc = true, int pageIndex = 1, int pageSize = 50, bool withPagination = true)
        {
            try
            {
                var data = await service.GetList(
                    nome: nome,
                    sort: sort!,
                    sortAsc: sortAsc,
                    pageIndex: pageIndex,
                    pageSize: pageSize,
                    withPagination: withPagination);

                return Ok(new
                {
                    success = true,
                    data
                });

            }
            catch (Exception ex)
            {
                return CathError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno data)
        {
            try
            {
                await service.CreateAsync(data);

                return Ok(new
                {
                    success = true,
                    data = new
                    {
                        data.Id,
                    }
                });

            }
            catch (Exception ex)
            {
                return CathError(ex);
            }
        }
    }
}
