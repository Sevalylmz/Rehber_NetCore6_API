using System.Linq.Expressions;

namespace Rehber.DataAccess.Interfaces
{
    public interface IBaseDAL<T> where T : class
    {
        // Create
        void Create(T entity);

        // Update
        void Update(T entity);

        // Delete
        void Delete(T entity);

        // Select One
        T GetDefault(Expression<Func<T, bool>> expression);

        // Select Many
        List<T> GetDefaults(Expression<Func<T, bool>> expression);
    }
}
