using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Services.ViewModels
{
    public class Configuration
    {
        public static string JwtKey { get; set; } = "7694022c01a9bd65ec338c03d8b5ef24664986ff8a97523577ece996e7656d64a2ede183a3a9414215aa524040765c7b852e35ec8381a84ea08636927fe890de";
        public static SmtpConfiguration Smtp = new();
        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 587;
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
