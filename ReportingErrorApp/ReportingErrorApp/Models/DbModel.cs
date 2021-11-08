using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ReportingErrorApp.Models
{
    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModels")
        {
        }

        public virtual DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.Contact)
                .IsUnicode(false);
        }

        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<ReportingErrorApp.Models.Login> Registration { get; set; } // Logins

        public System.Data.Entity.DbSet<ReportingErrorApp.Models.Dashboard> Dashboards { get; set; }
    }
}