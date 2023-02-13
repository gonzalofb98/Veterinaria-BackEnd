using System.ComponentModel.DataAnnotations;

namespace Dtos.Request
{
    public class AgregarComboRequest
    {
        [Required]
        public string Nombre { get; set; }
    }
}
