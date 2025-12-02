using GoalGrower.Data;
using GoalGrower.Models;
using Microsoft.AspNetCore.Identity;

namespace GoalGrower
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context, UserManager<UserModel> userManager)
        {
            // Ensure database exists
            context.Database.EnsureCreated();

            // If users already exist, do nothing
            if (context.Users.Any())
                return;

            // --- USER 1 ---
            var user1 = new UserModel
            {
                Name = "Alice",
                LastName = "Smith",
                BankAmount = 100m,
                Currency = UserModel.CurrencyType.USD,
                Email = "alice@example.com",
                UserName = "alice@example.com"
            };
            await userManager.CreateAsync(user1, "Password123!"); // Default password

            // --- USER 2 ---
            var user2 = new UserModel
            {
                Name = "Bob",
                LastName = "Johnson",
                BankAmount = 50m,
                Currency = UserModel.CurrencyType.USD,
                Email = "bob@example.com",
                UserName = "bob@example.com"
            };
            await userManager.CreateAsync(user2, "Password123!"); // Default password

            // --- GOALS ---
            var goal1 = new GoalModel
            {
                GoalName = "Buy a Laptop",
                GoalDescription = "Save for a new laptop",
                GoalAmount = 1200m,
                CompletionDate = DateTime.UtcNow.AddMonths(3),
                UserId = user1.Id,
                User = user1
            };

            var goal2 = new GoalModel
            {
                GoalName = "Vacation",
                GoalDescription = "Save for summer vacation",
                GoalAmount = 1500m,
                CompletionDate = DateTime.UtcNow.AddMonths(6),
                UserId = user2.Id,
                User = user2
            };

            context.Goals.AddRange(goal1, goal2);

            // --- TRANSACTIONS ---
            var transaction1 = new TransactionModel
            {
                TransactionDescription = "Initial deposit",
                TransactionType = TransactionModel.TransactionTypeEnum.Deposit,
                TransactionAmount = 100m,
                TransactionDate = DateTime.UtcNow,
                UserId = user1.Id,
                User = user1,
                GoalId = goal1.GoalId,
                Goal = goal1
            };

            var transaction2 = new TransactionModel
            {
                TransactionDescription = "Initial deposit",
                TransactionType = TransactionModel.TransactionTypeEnum.Deposit,
                TransactionAmount = 50m,
                TransactionDate = DateTime.UtcNow,
                UserId = user2.Id,
                User = user2,
                GoalId = goal2.GoalId,
                Goal = goal2
            };

            context.Transactions.AddRange(transaction1, transaction2);

            await context.SaveChangesAsync();
        }
    }
}
