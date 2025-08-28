using Escola.Models.Entities;
using Escola.Services.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Escola.Services.Repositories.Contatos
{
    public interface IContatoService
    {
        Task<List<Contato>> GetAll();
        Task<Contato> GetById(int id);
        Task<Contato> Create(ContatoCreateViewModel contato);
        Task Update(ContatoViewModel contato);
        Task Delete(int id);
    }

    public class ContatoService(DatabaseContext _context) : IContatoService
    {
        public async Task<List<Contato>> GetAll()
        {
            var data = await _context.Contatos.AsNoTracking().ToListAsync() 
                ?? throw new Exception("Não a contatos");
    
            return data;
        }

        public async Task<Contato> GetById(int id)
        {
            var data = await _context.Contatos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("Contato não encontrado");

            return data!;
        }

        public async Task<Contato> Create(ContatoCreateViewModel contato)
        {
            if (contato == null)
                throw new Exception("Formulario não preenchido");

            var data = new Contato
            {
                AlunoId = contato.AlunoId,
                Telefone = contato.Telefone,
                Celular = contato.Celular
            };

            await _context.AddAsync(data);
            await _context.SaveChangesAsync();

            return data;
        }
        
        public async Task Update(ContatoViewModel contato)
        {
            if (contato == null)
                throw new Exception("Formulario não preenchido");

            var data = new Contato
            {
                Id = contato.Id,
                AlunoId = contato.AlunoId,
                Telefone = contato.Telefone,
                Celular = contato.Celular
            };

            _context.Contatos.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id) 
                ?? throw new Exception("Contato não encontrado");

            _context.Contatos.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
