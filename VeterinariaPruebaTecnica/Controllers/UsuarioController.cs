using Dtos.Request;
using Entities;
using Entities.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interface;

namespace VeterinariaPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMascotaServicio _mascotaServicio;
        public UsuarioController(IUsuarioServicio servicioUsuario, IMascotaServicio servicioMascota)
        {
            _usuarioServicio = servicioUsuario;
            _mascotaServicio = servicioMascota;
        }

        [HttpGet]
        [Route("Clientes")]
        public async Task<IActionResult> ObtenerClientes()
        {
            var response = _usuarioServicio.ObtenerClientes();
            
            if(response == null)
                return Ok("No hay clientes.");
            
            return Ok(response);
        }

        [HttpGet]
        [Route("Vendedores")]
        public async Task<IActionResult> ObtenerVendedores()
        {
            var response = _usuarioServicio.ObtenerVendedores();

            if (response == null)
                return Ok("No hay vendedores.");

            return Ok(response);
        }

        [HttpPost]
        [Route("RegistrarMascota")]
        public async Task<IActionResult> RegistrarMascota([FromQuery] string email, [FromBody] AgregarMascotaRequest mascotaDto)
        {
            if (ModelState.IsValid)
            {
                var usuarioExistente = _usuarioServicio.BuscarPorEmail(email);
                if (usuarioExistente == null)
                {
                    return BadRequest("El email " + email + " no esta registrado");
                }
                var mascotaExistente = _usuarioServicio.BuscarMascota(email, mascotaDto.Nombre);
                if (mascotaExistente != null)
                {
                    return BadRequest("La mascota "+mascotaDto.Nombre+" ya esta registrada");
                }

                var isCreated = _usuarioServicio.RegistrarMascota(mascotaDto, email);

                if (isCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error, no se pudo registrar.");
                }

            }
            else
            {
                return BadRequest("Se produjo algun error al registrar la mascota");
            }
        }

    }
}
