using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Submit_Information.Entity;

namespace Submit_Information.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Entity.Information> Informations { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
