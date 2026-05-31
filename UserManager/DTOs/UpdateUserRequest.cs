using System.ComponentModel.DataAnnotations;

namespace UserManagerAPI.DTOs
{
    public class UpdateUserRequest
    {
        [StringLength(100)]
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [StringLength(25)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string Culture { get; set; }

        [MinLength(8)]
        [MaxLength(25)]
        [Required]
        public string Password { get; set; }
    }
}
