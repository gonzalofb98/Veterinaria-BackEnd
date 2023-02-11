using AutoMapper;
using Dtos.Request;
using Dtos.Response;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interface;
using VeterinariaPruebaTecnica.Configuracion;

namespace VeterinariaPruebaTecnica.Controllers.Autorizacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly UserManager<Usuario> _userManager;
        private readonly IUsuarioServicio _usuarioServicio;

        ITokenHandlerService _service;

        public AuthController(IUsuarioServicio usuarioServicio, ITokenHandlerService service)
        {
            //_userManager = userManager;
            _usuarioServicio= usuarioServicio;
            _service = service;
        }

        [HttpPost]
        [Route("RegistrarCliente")]
        public async Task<IActionResult> RegistrarCliente([FromBody] AgregarUsuarioRequest usuario)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _usuarioServicio.BuscarPorEmail(usuario.Email);
                if (existingUser != null)
                {
                    return BadRequest("El correo electronico indicado ya existe!");
                }

                var isCreated = _usuarioServicio.Agregar(new Cliente() { 
                    Nombre = usuario.Nombre, 
                    Apellido = usuario.Apellido, 
                    Email = usuario.Email,
                    Contrasenia = usuario.Contrasenia,
                });

                if (isCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error, no se pudo crear el Usuario");
                }

            }
            else
            {
                return BadRequest("Se produjo algun error al registrar el usuario");
            }
        }

        [HttpPost]
        [Route("RegistrarVendedor")]
        public async Task<IActionResult> RegistrarVendedor([FromBody] AgregarUsuarioRequest usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioExistente = _usuarioServicio.BuscarPorEmail(usuario.Email);
                if (usuarioExistente != null)
                {
                    return BadRequest("El correo electronico indicado ya existe!");
                }

                var isCreated = _usuarioServicio.Agregar(new Vendedor()
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email,
                    Contrasenia = usuario.Contrasenia,
                });

                if (isCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error, no se pudo crear el Usuario");
                }

            }
            else
            {
                return BadRequest("Se produjo algun error al registrar el usuario");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUsuarioRequest usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioExistente = _usuarioServicio.BuscarPorEmail(usuario.Email);
                if (usuarioExistente == null)
                {
                    return BadRequest(new LoginUsuarioResponse()
                    {
                        Login = false,
                        Errors = new List<String>()
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
                        TipoCliente = usuarioExistente.GetType().ToString(),
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
                        Errors = new List<String>()
                        {
                            "Usuario o contraseña incorrecto!"
                        }
                    });
                }
            }
            else
            {
                return BadRequest(new LoginUsuarioResponse()
                {
                    Login = false,
                    Errors = new List<String>()
                        {
                            "Usuario o contraseña incorrecto!"
                        }
                });
            }
        }
    }
}
