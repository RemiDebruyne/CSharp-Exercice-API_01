using Exercice_API_01.Data;
using Exercice_API_01.Models;

namespace Exercice_API_01.Repositories
{
    public class ContactRepository : GenericRepository<Contact>
    {
        public ContactRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
