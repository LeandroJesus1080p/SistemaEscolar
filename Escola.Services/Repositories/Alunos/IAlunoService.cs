using eGreja.Models.Mvvm;
using Escola.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Escola.Services.Repositories.Alunos
{
    public interface IAlunoService : IRepository<Aluno>
    {
        Task<object> GetList(string? nome = null, string sort = "Nome", bool sortAsc = true, int pageIndex = 1, int pageSize = 50, bool withPagination = true);
    }
    public class AlunoService(DatabaseContext databaseContext) : Repository<Aluno>(databaseContext), IAlunoService
    {

        public override async Task<Aluno> Get(int id)
        {
            ResetParams();

            Params.Includes("Endereco");
            Params.Includes("Contato");
            Params.Includes("Matricula");

            Params.Query(a => a.Id == id);

            return await base.GetFirst()
                ?? throw new Exception("Aluno não encontrado");
        }

        public async Task<object> GetList(string? nome = null, string sort = "Nome", bool sortAsc = true, int pageIndex = 1, int pageSize = 50, bool withPagination = true)
        {
            ResetParams();

            Params.Sort(sort, sortAsc);

            if (!string.IsNullOrWhiteSpace(nome))
                Params.Query(a => a.Nome.Contains(nome));

            var data = await ListMvvm<object>.CreateAsync(Params.Get().Select(a => new
            {
                a.Id,
                a.Nome,
                a.DataNascimento,
                a.Rg,
                a.Cpf,
                a.NomeResponsavel,

                Link = IntToBase64(a.Id)

            }), pageIndex, pageSize, withPagination);

            return new
            {
                list = data,
                pagination = data.GetPagination()
            };
        }

        private static string IntToBase64(int number)
        {
            string numberString = number.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(numberString);
            return Convert.ToBase64String(bytes);
        }

        protected override async Task Validate(Aluno data)
        {
            await base.Validate(data);
        }

        protected override async Task ValidateDuplicity(Aluno data)
        {

            if (await base.Exists(a => a.Id != data.Id && a.Nome == data.Nome))
                throw new Exception("Já existe um cadastro com este nome");

            await base.ValidateDuplicity(data);

        }
    }
}
