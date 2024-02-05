using Exercice_API_01.Models;
using Microsoft.EntityFrameworkCore;


namespace Exercice_API_01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Contact>().HasData(
        //        new Contact {FirstName ="", LastName="", Age = 6, BirthDate="", IsMale = true}

        //    );
        //}
    }
}
