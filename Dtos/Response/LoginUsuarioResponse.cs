using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Response
{
    public class LoginUsuarioResponse
    {
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Login { get; set; }
        public List<string> Errors { get; set; }
    }
}
