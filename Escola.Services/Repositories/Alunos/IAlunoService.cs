using Escola.Models.Entities;
using Escola.Models.Mvvm;
using Microsoft.EntityFrameworkCore;

namespace Escola.Services.Repositories.Alunos
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> GetById(int id);
        Task Create(Aluno aluno);
        Task Update(Aluno aluno);
        Task Delete(int id);
    }

    public class AlunoService(DatabaseContext _context) : IAlunoService
    {
        public async Task<IEnumerable<Aluno>> GetAll()
        {
            var data = await _context.Alunos.Include(x => x.Matriculas).Include(x => x.Enderecos).Include(x => x.Contatos).ToListAsync();

            return data;
        }

        public async Task<Aluno> GetById(int id)
        {
            var data = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

            return data!;
        }

        public async Task Create(Aluno aluno)
        {
            await _context.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Aluno aluno)
        {
            var data = _context.Alunos.Update(aluno);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);

            _context.Alunos.Remove(data);
            await _context.SaveChangesAsync();
        }

    }
}
