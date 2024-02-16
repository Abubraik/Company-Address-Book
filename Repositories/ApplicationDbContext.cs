using Company_Address_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Address_Book.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                        
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CompanyAddressBook;Integrated Security=True");
        //}
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
