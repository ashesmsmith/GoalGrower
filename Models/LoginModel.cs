using System.ComponentModel.DataAnnotations;

namespace GoalGrower.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "The username field is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
