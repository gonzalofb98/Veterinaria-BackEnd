﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Request
{
    public class LoginUsuarioRequest
    {
        public string Email { get; set; }

        public string Contrasenia { get; set; }
    }
}
