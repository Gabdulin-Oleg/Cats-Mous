using Cats_Mous.Models;
using Microsoft.EntityFrameworkCore;

namespace Cats_Mous.DBCats_Mous
{
    public class Context : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public Context(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;DataBase=DBCats-Mous;Trusted_Connection=True;");
        }
    }
}
