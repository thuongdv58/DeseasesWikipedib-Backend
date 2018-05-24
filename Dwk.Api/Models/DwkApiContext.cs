using Microsoft.EntityFrameworkCore;

namespace Dwk.Api.Models
{
    public class DwkApiContext : DbContext
    {
        public DwkApiContext(DbContextOptions<DwkApiContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Desease> Deseases { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //	modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}