using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Korepetycje.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
        public DbSet<Exercises> Excercises { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercises>()
                .HasRequired(s => s.Subject)
                .WithMany(s => s.Excercise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exercises>()
                .HasRequired(s => s.Section)
                .WithMany(s => s.Exercise)
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