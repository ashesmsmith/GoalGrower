using GoalGrower.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalGrower.Models
{
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }

        public string? TransactionDescription { get; set; } = string.Empty;

        public enum TransactionTypeEnum { Deposit, Withdrawal };
        [Required]
        public TransactionTypeEnum TransactionType { get; set; }

        [Required]
        public decimal TransactionAmount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;  // FK pointing to IdentityUser.Id
        public UserModel User { get; set; } = null!;             // Navigation property

        [ForeignKey("Goal")]
        public int? GoalId { get; set; }

        // Navigation properties
        public GoalModel? Goal { get; set; }
    }
}
