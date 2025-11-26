using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GoalGrower.Models;

namespace GoalGrower.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Goal> Goals => Set<Goal>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // 🚨 MUST be here for Identity tables

            // USER → TRANSACTIONS (1-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // USER → GOALS (1-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Goals)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // GOAL → TRANSACTIONS (1-to-many — optional link)
            modelBuilder.Entity<Goal>()
                .HasMany(g => g.Transactions)
                .WithOne(t => t.Goal)
                .HasForeignKey(t => t.GoalId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
