using AutoMapper;
using Dtos;
using Dtos.Request;
using Dtos.Response;
using Entities;
using Entities.Interface;
using Entities.TiposMascotas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interface;
using System.Collections.ObjectModel;

namespace VeterinariaPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServicio servicioUsuario, IMapper mapper)
        {
            _usuarioServicio = servicioUsuario;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Clientes")]
        public async Task<IActionResult> ObtenerClientes()
        {
            var clientes = _usuarioServicio.ObtenerClientes();
            var response = _mapper.Map<List<ClienteDto>>(clientes);

            if (response == null)
                return Ok("No hay clientes.");
            
            return Ok(response);
        }

        [HttpGet]
        [Route("ClientesMascotas")]
        public async Task<IActionResult> ObtenerClientesMascotas()
        {
            var clientes = _usuarioServicio.ObtenerClientes();
            var response = _mapper.Map<List<ClientesMascotasResponse>>(clientes);

            if (response == null)
                return Ok("No hay clientes.");

            return Ok(response);
        }

        [HttpGet]
        [Route("Vendedores")]
        public async Task<IActionResult> ObtenerVendedores()
        {
            var vendedores = _usuarioServicio.ObtenerVendedores();

            var response = _mapper.Map<List<VendedorDto>>(vendedores);

            if (response == null)
                return Ok("No hay vendedores.");

            return Ok(response);
        }

        [HttpPost]
        [Route("RegistrarMascota")]
        public async Task<IActionResult> RegistrarMascota([FromQuery] string email, [FromBody] AgregarMascotaRequest mascotaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Se produjo algun error al registrar la mascota");
            }

            var usuarioExistente = _usuarioServicio.BuscarPorEmail(email);
            if (usuarioExistente == null)
            {
                return BadRequest("El email " + email + " no esta registrado");
            }
            var mascotaExistente = _usuarioServicio.BuscarMascota(email, mascotaDto.Nombre);
            if (mascotaExistente != null)
            {
                return BadRequest("La mascota " + mascotaDto.Nombre + " ya esta registrada");
            }

            Mascota mascota;

            switch (mascotaDto.TipoMascota)
            {
                case "Perro":
                    mascota = _mapper.Map<Perro>(mascotaDto);
                    break;
                case "Gato":
                    mascota = _mapper.Map<Gato>(mascotaDto);
                    break;
                default:
                    mascota = null;
                    break;
            }

            if (mascota != null)
            {
                var isCreated = _usuarioServicio.RegistrarMascota(mascota, email);

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
                return BadRequest("Error, no se reconocio el tipo de mascota.");
            }
        }

    }
}
