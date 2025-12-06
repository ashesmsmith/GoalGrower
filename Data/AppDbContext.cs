using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GoalGrower.Models;

namespace GoalGrower.Data
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        // public DbSet<UserModel> Users { get; set; }
        public DbSet<TransactionModel> Transactions => Set<TransactionModel>();
        public DbSet<GoalModel> Goals => Set<GoalModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // calls for Identity first

            // USER → GOALS (1-to-many)
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Goals)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a user deletes their goals

            // GOAL → TRANSACTIONS (1-to-many — optional link)
            modelBuilder.Entity<GoalModel>()
                .HasMany(g => g.Transactions)
                .WithOne(t => t.Goal)
                .HasForeignKey(t => t.GoalId)
                .IsRequired() // Transactions must have a Goal
                .OnDelete(DeleteBehavior.Cascade); // Deleting a goal deletes its transactions
        }
    }
}