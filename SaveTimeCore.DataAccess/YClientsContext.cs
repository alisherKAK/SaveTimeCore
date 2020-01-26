using Microsoft.EntityFrameworkCore;
using SaveTimeCore.AbstractModels.Marker;
using SaveTimeCore.DataModels.Business;
using SaveTimeCore.DataModels.Dictionary;
using SaveTimeCore.DataModels.Organization;
using System.Collections.Generic;

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
            modelBuilder.Ignore<List<IEmployee>>();
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<Barber> Barbers { get; set; }
        public virtual DbSet<SystemAdmin> SystemAdmins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Record> Records { get; set; }

        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<BarberService> BarberServices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
    }
}
