using AutoMapper;
using Dtos;
using Dtos.Request;
using Dtos.Response;
using Entities;
using Entities.TiposMascotas;
using System.Collections.ObjectModel;

namespace Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
            CreateMap<Vendedor, VendedorDto>();
            CreateMap<VendedorDto, Vendedor>();
            CreateMap<Pedido, PedidoDto>();
            CreateMap<PedidoDto, Pedido>();
            CreateMap<Pedido, AgregarPedidoRequest>();
            CreateMap<AgregarPedidoRequest,Pedido>();
            CreateMap<ComboDto, Combo<Mascota>>();
            CreateMap<Combo<Mascota>, ComboDto>();
            CreateMap<Perro, AgregarMascotaRequest>();
            CreateMap<Gato, AgregarMascotaRequest>();
            CreateMap<AgregarMascotaRequest, Perro >();
            CreateMap<AgregarMascotaRequest,Gato>();
            CreateMap<Cliente, ClientesMascotasResponse>();
            CreateMap<Cliente, ClientesPedidosResponse>();
            CreateMap<Pedido, DespacharPedidoRequest>();
        }
    }
}