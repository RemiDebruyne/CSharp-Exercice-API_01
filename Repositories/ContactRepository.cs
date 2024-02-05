using Exercice_API_01.Data;
using Exercice_API_01.Models;

namespace Exercice_API_01.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private ApplicationDbContext _db;

        public ContactRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Contact entity)
        {
            _db.Contacts.Add(entity);
            _db.SaveChanges();
            return _db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            GetById(id);
            _db.Remove(id);
            return _db.SaveChanges() > 0;
        }

        public List<Contact> GetAll()
        {
            return _db.Contacts.ToList();
        }

        public Contact? GetById(int id)
        {
            return _db.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(Contact entity)
        {
            _db.Contacts.Update(entity);

            return _db.SaveChanges() > 0;
        }
    
    }
}
