using System;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.ExternalApiDTOs;
using AutoMapper;

namespace API_Repartidor.Mappings
{
    public class Automapper
    {
        public Automapper()
        {
        }

        //Crea los mapeos necesarios
        public void ConfigureAutomapper()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.id))
                .ForMember(dest => dest.nombre, origin => origin.MapFrom(c => c.name))
                .ForMember(dest => dest.codigoQR, origin => origin.MapFrom(c => c.code))
                .ForMember(dest => dest.descripcion, origin => origin.MapFrom(c => c.description));

                cfg.CreateMap<ProductDTO, ProductoCompletoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.id))
                .ForMember(dest => dest.codigoQR, origin => origin.MapFrom(c => c.code))
                .ForMember(dest => dest.nombre, origin => origin.MapFrom(c => c.name))
                .ForMember(dest => dest.descripcion, origin => origin.MapFrom(c => c.description))
                .ForMember(dest => dest.fabricante, origin => origin.MapFrom(c => c.brand))
                .ForMember(dest => dest.imagen, origin => origin.MapFrom(c => c.image));

                cfg.CreateMap<DTOs.ExternalApiDTOs.StockDTO, DTOs.StockDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.stock_id))
                .ForMember(dest => dest.idZona, origin => origin.MapFrom(c => c.zone_id))
                .ForMember(dest => dest.cantidad, origin => origin.MapFrom(c => c.quantity));

                cfg.CreateMap<DTOs.ExternalApiDTOs.ClientDTO, DTOs.ClienteDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.id))
                .ForMember(dest => dest.nombre, origin => origin.MapFrom(c => c.name))
                .ForMember(dest => dest.direccion, origin => origin.MapFrom(c => c.address))
                .ForMember(dest => dest.email, origin => origin.MapFrom(c => c.email))
                .ForMember(dest => dest.telefonoFijo, origin => origin.MapFrom(c => c.fixed_phone))
                .ForMember(dest => dest.telefonoCelular, origin => origin.MapFrom(c => c.cell_phone))
                .ForMember(dest => dest.cuit, origin => origin.MapFrom(c => c.legal_id));


                //Mapeos entre Entites y DTOs
                cfg.CreateMap<Entities.Pedido, DTOs.PedidoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.Id))
                .ForMember(dest => dest.fechaCreacion, origin => origin.MapFrom(c => c.fechaCreacion))
                .ForMember(dest => dest.fechaFinalizacion, origin => origin.MapFrom(c => c.fechaFinalizacion))
                .ForMember(dest => dest.fechaLimite, origin => origin.MapFrom(c => c.fechaLimite))
                .ForMember(dest => dest.entregado, origin => origin.MapFrom(c => c.entregado))
                .ForMember(dest => dest.precioTotal, origin => origin.MapFrom(c => c.precioTotal))
                .ForMember(dest => dest.idCliente, origin => origin.MapFrom(c => c.idCliente))
                .ReverseMap();

                cfg.CreateMap<Entities.ItemPedido, DTOs.ItemPedidoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.Id))
                .ForMember(dest => dest.cantidad, origin => origin.MapFrom(c => c.cantidad))
                .ForMember(dest => dest.cantidadRechazada, origin => origin.MapFrom(c => c.cantidadRechazada))
                .ForMember(dest => dest.precio, origin => origin.MapFrom(c => c.precio))
                .ForMember(dest => dest.idProducto, origin => origin.MapFrom(c => c.idProducto))
                .ReverseMap();

                cfg.CreateMap<Entities.Reparto, DTOs.RepartoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.Id))
                .ForMember(dest => dest.fecha, origin => origin.MapFrom(c => c.fecha))
                .ForMember(dest => dest.finalizado, origin => origin.MapFrom(c => c.finalizado))
                .ForMember(dest => dest.pedidos, origin => origin.MapFrom(c => c.pedidos))
                .ReverseMap();
            });
        }
    }
}
