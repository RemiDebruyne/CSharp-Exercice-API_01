using Exercice_API_01.Data;
using Exercice_API_01.Models;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Exercice_API_01.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return _db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                return false;

            _db.Set<T>().Remove(entity);
            return _db.SaveChanges() > 0;
        }

       

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().FirstOrDefault(predicate);
        }
        public virtual List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }


        public bool Update(T entity)
        {

            var entityFromDb = GetById(entity.Id);

            Type typeCategorie = entity.GetType();

            foreach (PropertyInfo property in typeCategorie.GetProperties())
            {
                var valeurPropriete = property.GetValue(entity, null);
                var valeurProprieteFromDb = property.GetValue(entityFromDb, null);
                if (valeurProprieteFromDb != valeurPropriete)
                    valeurProprieteFromDb = valeurPropriete;
            }

            return _db.SaveChanges() > 0;
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }
    }
}
