using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models.Entities
{
    public class Role : Table
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<User> Users { get; set; }
    }
}
