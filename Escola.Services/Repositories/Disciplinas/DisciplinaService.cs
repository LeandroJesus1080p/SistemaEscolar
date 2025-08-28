
using Escola.Models.Entities;
using Escola.Services.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Escola.Services.Repositories.Disciplinas
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<Disciplina>> GetAll();
        Task<Disciplina> GetById(int id);
        Task<Disciplina> Create(DisciplinaViewModel entity);
        Task Update(DisciplinaUpdateViewModel entity);
        Task Delete(int id);
    }
    public class DisciplinaService(DatabaseContext _context) : IDisciplinaService
    {
        public async Task<IEnumerable<Disciplina>> GetAll()
        {
            var data = await _context.Disciplinas.AsNoTracking().ToListAsync() 
                ?? throw new Exception("Dados não encontrados");

            return data;
        }

        public async Task<Disciplina> GetById(int id)
        {
            var data = await _context.Disciplinas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("Disciplina não encontrada");

            return data;
        }

        public async Task<Disciplina> Create(DisciplinaViewModel entity)
        {
            if (entity == null)
                throw new Exception("Formulario vazio");

            var data = new Disciplina
            {
                Nome = entity.Nome,
                CargaHoraria = entity.CargaHoraria
            };

            await Validade(data);

            await _context.Disciplinas.AddAsync(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task Update(DisciplinaUpdateViewModel entity)
        {
            if (entity == null)
                throw new Exception("Formulario vazio");

            var data = new Disciplina
            {
                Id = entity.Id,
                Nome = entity.Nome,
                CargaHoraria = entity.CargaHoraria
            };

            await Validade(data);

            _context.Disciplinas.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id == 0)
                throw new Exception("Id não informado");

            var data = await GetById(id);

            _context.Disciplinas.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task Validade(Disciplina entity)
        {
            var valida = await _context.Disciplinas.AnyAsync(x => x.Nome == entity.Nome);

            if (valida) 
                throw new Exception($"Ja existe uma Disciplina com esse nome");
        }
    }
}
