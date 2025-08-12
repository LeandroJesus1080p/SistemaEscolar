using eGreja.Models.Mvvm;
using eGreja.Services.Repositories;
using Escola.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Escola.Services.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T data);

        Task CreateAsync(T data);

        void Delete(T data);

        Task DeleteAsync(int id);

        Task DeleteAsync(T data);

        Task DeleteAsync(IEnumerable<T> data);

        Task<T> Get(int id);

        Task<T?> GetFirst();

        Task<ListMvvm<T>> GetList(int pageIndex = 1, int pageSize = 50, bool withPagination = true);

        Task<int> SaveAsync();

        void Update(T data);

        Task UpdateAsync(T data);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _databaseContext;
        private readonly DbSet<T> _table;
        private Parameters<T> _params;

        public Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _table = _databaseContext.Set<T>();
            _params = new Parameters<T>(_table);
        }

        public Parameters<T> Params { get { return _params; } }

        public virtual void Create(T data) => _table.Add(data);

        public virtual async Task CreateAsync(T data)
        {
            await Validate(data);
            Create(data);
            await SaveAsync();
        }

        public virtual void Delete(T data) =>
            _table.Remove(data);

        public virtual void Delete(IEnumerable<T> data) =>
            _table.RemoveRange(data);

        public virtual async Task DeleteAsync(int id)
        {
            var data = await Get(id);
            await DeleteAsync(data);
        }

        public virtual async Task DeleteAsync(T data)
        {
            Delete(data);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(IEnumerable<T> data)
        {
            Delete(data);
            await SaveAsync();
        }

        public virtual async Task<T> Get(int id) =>
            await _table.FindAsync(id)
                ?? throw new Exception("Registro não encontrado");

        public virtual Task<T?> GetFirst() =>
            Params.Get().FirstOrDefaultAsync();

        public virtual async Task<ListMvvm<T>> GetList(int pageIndex = 1, int pageSize = 50, bool withPagination = true) =>
            await ListMvvm<T>.CreateAsync(Params.Get(), pageIndex, pageSize, withPagination);

        public void ResetParams() => _params = new Parameters<T>(_table);

        public virtual async Task<int> SaveAsync() =>
            await _databaseContext.SaveChangesAsync();

        public virtual void Update(T data) =>
            _databaseContext.Entry(data).State = EntityState.Modified;

        public virtual async Task UpdateAsync(T data)
        {
            await Validate(data);
            Update(data);
            await SaveAsync();
        }

        protected virtual async Task<bool> Exists(Expression<Func<T, bool>> predicate) => await _table
            .Where(predicate)
            .AsNoTracking()
            .AnyAsync();

        protected virtual async Task Validate(T data) => await ValidateDuplicity(data);

        protected virtual async Task ValidateDuplicity(T data) => await Task.CompletedTask;
    }
}
