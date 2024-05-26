using MCV.net.Models;
using Microsoft.EntityFrameworkCore;


namespace MCV.net.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasKey(u =>  new { u.id, u.Email } );
            modelBuilder.Entity<Account>().HasIndex(u => u.Email).IsUnique();

        }

        public DbSet <Model1>  ModleTable { get; set; }
        public DbSet<MCV.net.Models.ContactModel> Contact { get; set; }
        public DbSet<Account> UserAccount { get; set; }
 
    }
}
