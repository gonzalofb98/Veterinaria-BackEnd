using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Mascota : EntidadBase
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int AnioNacimiento { get; set; }
        [Required]
        public double Peso { get; set; }
        [Required]
        public bool Castrado { get; set; }

        public Mascota()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Mascota(string nombre, int anioNacimiento, double peso, bool castrado)
        {
            Nombre = nombre;
            AnioNacimiento = anioNacimiento;
            Peso = peso;
            Castrado = castrado;
        }

        public int getEdad()
        {
            return DateTime.Now.Year - AnioNacimiento;
        }

        public virtual double CalcularAlimento() { return 0; }
        public virtual int CalcularComplemento() { return 0; }
    }
}
