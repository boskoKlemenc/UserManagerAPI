using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        [StringLength(25)]
        public string UserName { get; set; } = string.Empty;

        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [StringLength(25)]
        public string? MobileNumber { get; set; }

        [StringLength(50)]
        public string? Language { get; set; }

        [StringLength(50)]
        public string? Culture { get; set; }

        [StringLength(500)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
