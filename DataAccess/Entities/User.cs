using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Language { get; set; }

        public string Culture { get; set; }

        public string PasswordHash { get; set; }
    }
}
