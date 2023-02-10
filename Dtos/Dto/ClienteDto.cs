﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Dto
{
    public class ClienteDto
    {
        public List<MascotaDto> Mascotas { get; set; }
        public List<PedidoDto> Pedidos { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}