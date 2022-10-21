using Microsoft.EntityFrameworkCore;
using Rehber.Models;
using System.Security.Cryptography.X509Certificates;

namespace Rehber.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().HasKey(a => a.ID);
            builder.Entity<Email>().HasKey(a => a.ID);
            builder.Entity<PhoneNumber>().HasKey(a => a.ID);
            builder.Entity<Location>().HasKey(a => a.ID);

            builder.Entity<Email>().HasOne(a => a.Person).WithMany(a => a.Emails).HasForeignKey(a => a.PersonID);
            builder.Entity<PhoneNumber>().HasOne(a => a.Person).WithMany(a => a.PhoneNumbers).HasForeignKey(a => a.PersonID);
            builder.Entity<Location>().HasOne(a => a.Person).WithMany(a => a.Locations).HasForeignKey(a => a.PersonID);

            base.OnModelCreating(builder);
        }










    }

    
    
}
