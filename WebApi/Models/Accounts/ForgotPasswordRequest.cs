using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;

namespace WebApi.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        //.NET Data Annotations used to automatically handle model validation
        // [Required] makes the email required
        // [EmailAddress] validates that it contains a valid email address
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
