using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ApiClient
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; } = string.Empty;

        [StringLength(50)]
        public string ApiKey { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
