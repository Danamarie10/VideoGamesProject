using System.ComponentModel.DataAnnotations;

namespace VideoGames.View_Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
