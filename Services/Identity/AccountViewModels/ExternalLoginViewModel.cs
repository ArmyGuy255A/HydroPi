using System.ComponentModel.DataAnnotations;

namespace HydroPi.Services.Identity.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
