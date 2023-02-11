﻿using AutoMapper;
using Dtos.Dto;
using Dtos.Request;
using Entities;

namespace Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
            CreateMap<Pedido, PedidoDto>();
            CreateMap<PedidoDto, Pedido>();
            CreateMap<ComboDto, Combo<Mascota>>();
            CreateMap<Combo<Mascota>, ComboDto>();
            CreateMap<Mascota, AgregarMascotaRequest>();
            CreateMap<AgregarMascotaRequest, Mascota>();
            CreateMap<Vendedor, VendedorDto>();
            CreateMap<VendedorDto, Vendedor>();
        }
    }
}