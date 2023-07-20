using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using em.Domain.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using em.Domain.Authorize;

namespace em.Persistence.Context
{
    public class conDBContext : DbContext
    {
        public conDBContext(DbContextOptions<conDBContext> dbContextOptions) : base(dbContextOptions)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        // @ Mantığı içeriye tek slash koymamak için yani onu kaldırıp // yapabilirim.

        const string conString = @"Data Source=BurakPC\SQLEXPRESS;Initial Catalog=PersonelOtomasyon;Persist Security Info=False;TrustServerCertificate=True;User ID=sa;Password=1";
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Reason> Reason { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<AuthorizedPerson> AuthorizedPerson { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasKey(e => e.ID);
            modelBuilder.Entity<Permission>()
                        .HasKey(p => p.ID);
            modelBuilder.Entity<Company>()
                        .HasKey(c => c.ID);
            modelBuilder.Entity<Reason>()
                        .HasKey(c => c.ID);
            //Primary Key Tanımlamaları.

            modelBuilder.Entity<Employee>()
                        .HasOne(ı => ı.Company)
                        .WithMany()
                        .HasForeignKey(e => e.CompanyID);
            //CompanyID ile Employee tablosundaki ID eşleştirmesi.

            modelBuilder.Entity<Permission>()
                        .HasOne(p => p.Employee)
                        .WithMany(x => x.Permission)
                        .HasForeignKey(p => p.employeeID);
            //employeeID ile Employee tablosundaki ID eşleştirmesi.

            modelBuilder.Entity<Permission>()
                        .HasOne(p => p.Reason)
                        .WithMany()
                        .HasForeignKey(p => p.reasonID);
            //reasonID ile Reason tablosundaki ID eşleştirmesi.

            modelBuilder.Entity<AuthorizedPerson>(entity =>
            {
                entity.ToTable("AuthorizedPerson");
                entity.HasKey(c => c.ID);
                entity.HasOne(p => p.roles)
                .WithMany(x => x.AuthorizedPerson)
                .HasForeignKey(p => p.authorizationID);
                //authorizationID ile Authorizations tablosundaki ID eşleştirmesi.
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles")
                .HasKey(c => c.ID);
                //authorizationID ile Authorizations tablosundaki ID eşleştirmesi.
            });




        }
    }
}
