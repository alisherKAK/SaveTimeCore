using Microsoft.EntityFrameworkCore;
using SaveTimeCore.AbstractModels.Marker;
using SaveTimeCore.DataModels.Business;
using SaveTimeCore.DataModels.Organization;

namespace SaveTime.DataAccess
{
    public class YClientsContext : DbContext
    {
        public YClientsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=SaveTimeCore.DataAccess.YClientsContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IAccountOwner>();
        }

        public virtual DbSet<Barber> Barbers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Record> Records { get; set; }
    }
}
