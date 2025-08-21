using Escola.Models.Entities;
using Escola.Services.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Escola.Services.Repositories.Alunos
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task<Aluno> Create(AlunoViewModel aluno);
        Task Update(AlunoUpdateViewModel aluno);
        Task Delete(int id);
    }

    public class AlunoService(DatabaseContext _context) : IAlunoService
    {
        public async Task<IEnumerable<Aluno>> GetAll()
        {
            var data = await _context.Alunos.Include(x => x.Matriculas).ToListAsync() 
                ?? throw new Exception("Sem dados");

            return data;
        }

        public async Task<Aluno> GetById(int id)
        {
            var data = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("Aluno não encontrado");

            return data!;
        }

        public async Task<Aluno> Create(AlunoViewModel aluno)
        {
            if (aluno == null)
                throw new Exception("Formulario não pode ser vazio");

            var data = new Aluno
            {
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Rg = aluno.Rg,
                Cpf = aluno.Cpf,
                NomeResponsavel = aluno.NomeResponsavel
            };

            await _context.AddAsync(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task Update(AlunoUpdateViewModel aluno)
        {
            if (aluno == null)
                throw new Exception("Formulario vazio");

            var data = new Aluno
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Rg = aluno.Rg,
                Cpf = aluno.Cpf,
                NomeResponsavel = aluno.NomeResponsavel
            };

            _context.Alunos.Update(data);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id) ?? throw new Exception("Aluno não encontrado");

            _context.Alunos.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
