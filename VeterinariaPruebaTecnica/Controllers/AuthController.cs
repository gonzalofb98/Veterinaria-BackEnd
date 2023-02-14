using AutoMapper;
using Dtos.Request;
using Dtos.Response;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interface;
using VeterinariaPruebaTecnica.Configuracion;

namespace VeterinariaPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        ITokenHandlerService _service;

        public AuthController(IUsuarioServicio usuarioServicio, ITokenHandlerService service)
        {
            _usuarioServicio = usuarioServicio;
            _service = service;
        }

        [HttpPost]
        [Route("RegistrarCliente")]
        public async Task<IActionResult> RegistrarCliente([FromBody] AgregarUsuarioRequest usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Se produjo algun error al registrar el usuario");
            }

            var existingUser = _usuarioServicio.BuscarPorEmail(usuario.Email);
            if (existingUser != null)
            {
                return BadRequest("El correo electronico indicado ya existe!");
            }

            var user = _usuarioServicio.Agregar(new Cliente()
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Contrasenia = usuario.Contrasenia,
            });

            if (user != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error, no se pudo crear el Usuario");
            }
        }

        [HttpPost]
        [Route("RegistrarVendedor")]
        public async Task<IActionResult> RegistrarVendedor([FromBody] AgregarUsuarioRequest usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Se produjo algun error al registrar el usuario");
            }

            var usuarioExistente = _usuarioServicio.BuscarPorEmail(usuario.Email);
            if (usuarioExistente != null)
            {
                return BadRequest("El correo electronico indicado ya existe!");
            }

            var user = _usuarioServicio.Agregar(new Vendedor()
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Contrasenia = usuario.Contrasenia,
            });

            if (user != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error, no se pudo crear el Usuario");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUsuarioRequest usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new LoginUsuarioResponse()
                {
                    Login = false,
                    Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecto!"
                        }
                });
            }

            var usuarioExistente = _usuarioServicio.BuscarPorEmail(usuario.Email);
            if (usuarioExistente == null)
            {
                return BadRequest(new LoginUsuarioResponse()
                {
                    Login = false,
                    Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecto!"
                        }
                });
            }

            var isCorrect = _usuarioServicio.VerificarContraseña(usuarioExistente, usuario.Contrasenia);

            if (isCorrect)
            {
                var pars = new TokenParameters()
                {
                    Id = usuarioExistente.Id,
                    ContraseniaHash = usuarioExistente.Contrasenia,
                    Usuario = usuarioExistente.Email
                };

                var jwtToken = _service.GenerateJwtToken(pars);

                return Ok(new LoginUsuarioResponse()
                {
                    Tipo = usuarioExistente.GetType().ToString(),
                    Email = usuario.Email,
                    Login = true,
                    Token = jwtToken
                });
            }
            else
            {
                return BadRequest(new LoginUsuarioResponse()
                {
                    Login = false,
                    Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecto!"
                        }
                });
            }
        }
    }
}
