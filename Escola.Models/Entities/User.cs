using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities
{
    public class User : Table
    {
        public string Name { get; set; } = string.Empty;
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Slug { get; set; }

        public List<Role> Roles { get; set; }
    }
}
