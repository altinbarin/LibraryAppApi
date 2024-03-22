using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        public List<T> GetAll(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        T Get(Expression<Func<T, bool>> filter);

        void Delete(T entity);
    }
}
