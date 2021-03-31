using System.ComponentModel.DataAnnotations;

namespace HydroPi.Services.Identity.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
