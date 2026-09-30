using System.ComponentModel.DataAnnotations;

namespace IamProvider.API.Models
{
    public class RegisterModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class RoleModel
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }

    public class UserRoleModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}