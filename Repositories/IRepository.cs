using Exercice_API_01.Models;
using System.Linq.Expressions;

namespace Exercice_API_01.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T? Get(Expression<Func<T, bool>> predicate);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
