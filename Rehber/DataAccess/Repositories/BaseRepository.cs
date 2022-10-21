using Microsoft.EntityFrameworkCore;
using Rehber.Context;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;
using System.Linq.Expressions;

namespace Rehber.DataAccess.Repositories
{
    public abstract class BaseRepository<T>: IBaseDAL<T> where T : class
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<T> _table;
        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        // Create
        public void Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        // Delete
        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        // Get Default
        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
