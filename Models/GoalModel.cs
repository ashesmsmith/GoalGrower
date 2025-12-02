using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalGrower.Models
{
    public class GoalModel
    {
        [Key]
        public int GoalId { get; set; }

        [Required]
        public string GoalName { get; set; } = string.Empty;

        public string? GoalDescription { get; set; }

        [Required]
        public decimal GoalAmount { get; set; }

        public DateTime CompletionDate { get; set; }

        // Foreign key
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;

        // Navigation property
        public UserModel User { get; set; } = null!;

        public List<TransactionModel>? Transactions { get; set; }
    }
}
