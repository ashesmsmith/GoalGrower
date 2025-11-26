using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalGrower.Models
{
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime CompletionDate { get; set; }

        // Foreign key
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;

        // Navigation property
        public User? User { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}
