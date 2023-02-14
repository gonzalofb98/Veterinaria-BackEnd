using AutoMapper;
using Dtos;
using Dtos.Request;
using Dtos.Response;
using Entities;
using Entities.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interface;

namespace VeterinariaPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMapper _mapper;

        public PedidoController(IUsuarioServicio repositorioUsuario, IMapper mapper)
        {
            _usuarioServicio = repositorioUsuario;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Pedidos")]
        public async Task<IActionResult> ObtenerTodosLosPedidos()
        {
            var clientes = _usuarioServicio.ObtenerClientes();
            var response = _mapper.Map<List<ClientesPedidosResponse>>(clientes);

            if (response == null)
                return Ok("No hay clientes.");

            return Ok(response);
        }

        [HttpGet]
        [Route("PedidoCliente")]
        public async Task<IActionResult> ObtenerPedidosPorCliente([FromQuery] string email)
        {
            var clientes = _usuarioServicio.BuscarPorEmail(email) as Cliente;
            var response = _mapper.Map<ClientesPedidosResponse>(clientes);

            if (response == null)
                return Ok("El Cliente con email: "+email+" no se encuentra registrado.");

            return Ok(response);
        }

        [HttpPost]
        [Route("RegistrarCombo")]
        public async Task<IActionResult> RegistrarPedido([FromQuery] string email, [FromBody] AgregarComboRequest comboDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Se produjo un error al registrar el combo");
            }

            var usuarioExistente = _usuarioServicio.BuscarPorEmail(email) as Cliente;
            if (usuarioExistente == null)
            {
                return BadRequest("El email " + email + " no esta registrado");
            }

            var mascota = usuarioExistente.Mascotas.Where(x => x.Nombre == comboDto.Nombre).FirstOrDefault();

            if (mascota == null)
            {
                return BadRequest("La mascota " + comboDto.Nombre + " no existe");
            }

            var combo = new Combo<Mascota>(mascota);

            var isCreated = _usuarioServicio.AgregarComboAPedido(usuarioExistente, combo);

            if (isCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error, no se pudo registrar el combo.");
            }
        }

        [HttpPost]
        [Route("RegistrarPedido")]
        public async Task<IActionResult> RegistrarPedido([FromQuery] string email, [FromBody] AgregarPedidoRequest pedidoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Se produjo un error al registrar el pedido");
            }
            var usuarioExistente = _usuarioServicio.BuscarPorEmail(email) as Cliente;
            if (usuarioExistente == null)
            {
                return BadRequest("El email " + email + " no esta registrado");
            }
            if (!usuarioExistente.PedidoPendiente.Combos.Any())
            {
                return BadRequest("No hay Combos Seleccionado");
            }
            var pedido = _mapper.Map<Pedido>(pedidoDto);

            var isCreated = _usuarioServicio.AgregarPedido(email, pedido);

            if (isCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error, no se pudo registrar el pedido.");
            }
        }

        [HttpPost]
        [Route("DespacharPedido")]
        public async Task<IActionResult> DespacharPedido([FromQuery] string email, [FromBody] DespacharPedidoRequest pedidoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Se produjo un error al despachar el pedido.");
            }
            var usuarioExistente = _usuarioServicio.BuscarPorEmail(email) as Cliente;
            if (usuarioExistente == null)
            {
                return BadRequest("El email " + email + " no esta registrado");
            }

            var pedido = usuarioExistente.Pedidos.Where(x => x.Codigo == pedidoDto.Codigo).FirstOrDefault();

            if (pedido == null)
            {
                return BadRequest("El pedido con codigo: " + pedidoDto.Codigo + " no existe o no corresponde al cliente");
            }

            var isCreated = _usuarioServicio.DespacharPedido(usuarioExistente, pedidoDto.Codigo);

            if (isCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error, no se pudo despachar el pedido.");
            }
        }

    }
}
