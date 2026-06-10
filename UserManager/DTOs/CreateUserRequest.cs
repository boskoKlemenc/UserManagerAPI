using System.ComponentModel.DataAnnotations;

namespace UserManagerAPI.DTOs
{
    public class CreateUserRequest
    {
        [StringLength(25)]
        [Required]
        public string UserName { get; set; }  = string.Empty;

        [StringLength(100)]
        [Required]
        public string FullName { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [StringLength(25)]
        public string MobileNumber { get; set; } = string.Empty;

        [StringLength(50)]
        public string Language { get; set; } = string.Empty;

        [StringLength(50)]
        public string Culture { get; set; } = string.Empty;

        [MinLength(8)]
        [MaxLength(25)]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
