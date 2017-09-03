using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Korepetycje.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
        public DbSet<Exercises> Excercises { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<SchoolList> SchoolList { get; set; }
        public DbSet<SchoolClassList> SchoolClassList { get; set; }
        public DbSet<Homeworks> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercises>()
                .HasRequired(s => s.Section)
                .WithMany(s => s.Exercise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exercises>()
                .HasRequired(s => s.SchoolList)
                .WithMany(s => s.Exercise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exercises>()
                .HasRequired(c => c.SchoolClassList)
                .WithMany(c => c.Exercise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(h => h.Homework)
                .WithRequired(h => h.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Homeworks>()
                .HasRequired(e => e.Exercise)
                .WithMany(e => e.Homeworks)
                .WillCascadeOnDelete(false);
                
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
}