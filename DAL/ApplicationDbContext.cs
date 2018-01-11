using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IApplicationDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<SubStatus> SubStatuses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserEntity(modelBuilder);

            ConfigureSubStatusEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(s => s.SubStatus)
                .WithOne(u => u.User)
                .HasForeignKey(s => s.UserId);   
        }

        private void ConfigureSubStatusEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubStatus>()
                .HasKey(br => br.Id);
        }


    }
}
