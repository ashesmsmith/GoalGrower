using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GoalGrower.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Last name must be less than 50 characters")]
        
        public string LastName { get; set; } = string.Empty;

        [Required]

        [Range(0, double.MaxValue, ErrorMessage = "Bank amount must be 0 or above")]
        public decimal BankAmount { get; set; }
        
        
        public enum CurrencyType { USD, EUR, GBP, MXN, ARS, CLP }
        [Required]
        public CurrencyType Currency { get; set; } = CurrencyType.USD;


        // Relationships
        public List<TransactionModel>? Transactions { get; set; }
        public List<GoalModel>? Goals { get; set; }
    }
}
