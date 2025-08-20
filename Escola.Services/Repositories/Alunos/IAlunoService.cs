using Escola.Models.Entities;
using Escola.Models.Mvvm;
using Microsoft.EntityFrameworkCore;

namespace Escola.Services.Repositories.Alunos
{
    public interface IAlunoService 
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task<Aluno> Create(Aluno aluno);
        Task<Aluno> Update(int id);
        Task<Aluno> Delete(int id);
    }

    public class AlunoService(DatabaseContext _context) : IAlunoService
    {
        public async Task<IEnumerable<Aluno>> GetAll()
        {
            var data = await _context.Alunos.ToListAsync();
            if(data is null) return null!;

            return data;
        }

        public async Task<Aluno> GetById(int id)
        {
            var data = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if (id == 0) return null!;

            return data!;
        }

        public async Task<Aluno> Create(Aluno aluno)
        {
            await _context.AddAsync(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> Update(int id)
        {
            var data = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

            if (data is null) return null!;

            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<Aluno> Delete(int id)
        {
            var data = await GetById(id);

            if (data is null) return null!;

            _context.Alunos.Remove(data);

            return data;
        }

    }
}
