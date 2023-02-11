using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Request
{
    public class AgregarMascotaRequest
    {
        public string Nombre { get; set; }
        public int AnioNacimiento { get; set; }
        public double Peso { get; set; }
        public bool Castrado { get; set; }
    }
}
