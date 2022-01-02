using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
