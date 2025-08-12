using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace eGreja.Services.Repositories
{
    public class Parameters<T>(IQueryable<T> query) where T : class
    {
        private List<string> _includes = [];

        private IQueryable<T> _query = query;

        public bool AsNoTracking { get; set; } = true;

        public IQueryable<T> Get()
        {
            Prepare();
            return _query;
        }

        public void Includes(string table)
        {
            _includes ??= [];
            _includes.Add(table);
        }

        public void Query(Expression<Func<T, bool>> query) =>
            _query = _query.Where(query);

        public void Sort(string column, bool asc = true) =>
            _query = _query.OrderBy($"{column} {(asc ? "asc" : "desc")}");

        public void Sort(Expression<Func<T, dynamic>> sort, bool asc = true) =>
            _query = asc ? _query.OrderBy(sort) : _query.OrderByDescending(sort);

        public void Sort(Expression<Func<T, DateTime?>> sort, bool asc = true) =>
            _query = asc ? _query.OrderBy(sort) : _query.OrderByDescending(sort);

        public void Sort(Expression<Func<T, int>> sort, bool asc = true) =>
            _query = asc ? _query.OrderBy(sort) : _query.OrderByDescending(sort);

        private void Prepare()
        {
            if (AsNoTracking)
                _query.AsNoTracking();

            foreach (var item in _includes)
                _query = _query.Include(item);
        }
    }
}