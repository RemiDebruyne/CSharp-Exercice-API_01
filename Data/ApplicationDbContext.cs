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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().Property(e => e.FirstName).UseCollation("Latin1_General_CI_AI");
            modelBuilder.Entity<Contact>().Property(e => e.LastName).UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<Contact>().HasData(
                new Contact {Id = 1, FirstName = "Rémi", LastName = "Debruyne",  BirthDate = new DateTime(1999, 01, 26), Gender = "Homme" },
                new Contact { Id = 2, FirstName = "Manu", LastName = "Max",  BirthDate = new DateTime(1983, 07, 12), Gender = "Homme" },
                new Contact { Id = 3, FirstName = "Jean", LastName = "Bon",  BirthDate = new DateTime(325, 11, 03), Gender = "Robot" },
                new Contact { Id = 4, FirstName = "Jaina", LastName = "Portvaillant",  BirthDate = new DateTime(122, 03, 31), Gender = "Femme" }

            );
        }
    }
}
