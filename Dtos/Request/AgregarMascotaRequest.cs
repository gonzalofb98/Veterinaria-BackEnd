using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Request
{
    public class AgregarMascotaRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int AnioNacimiento { get; set; }
        [Required]
        public double Peso { get; set; }
        [Required]
        public bool Castrado { get; set; }
        [Required]
        public string TipoMascota { get; set; }
    }
}
