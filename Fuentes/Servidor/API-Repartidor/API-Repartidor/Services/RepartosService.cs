using API_Repartidor.DTOs;
using API_Repartidor.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using API_Repartidor.Exceptions;

namespace API_Repartidor.Services
{
    public class RepartosService
    {
        private readonly RepartosDAO repartosDAO;
        private readonly PedidosService pedidosService;
        public RepartosService(RepartosDAO repartosDAO, PedidosService pedidosService)
        {
            this.repartosDAO = repartosDAO;
            this.pedidosService = pedidosService;
        }

        public List<RepartoDTO> GetRepartos()
        {
            List<RepartoDTO> repartosDTO = new List<RepartoDTO>();

            foreach (var reparto in repartosDAO.findAll())
            {
                RepartoDTO repDTO = new RepartoDTO();

                repDTO = Mapper.Map<Entities.Reparto, RepartoDTO>(reparto);
                repartosDTO.Add(repDTO);
            }
            return repartosDTO;
        }

        public List<PedidoDTO> GetPedidosOfReparto(int id)
        {
            RepartoDTO repDTO = this.GetRepartoByID(id);
            List<PedidoDTO> pedidosDTO = new List<PedidoDTO>();
            foreach (var pedido in repDTO.pedidos)
            {
                pedidosDTO.Add(pedido);
            }
            return pedidosDTO;
        }

        public RepartoDTO AddReparto(RepartoDTO reparto)
        {
            Entities.Reparto repartoEntity = Mapper.Map<RepartoDTO, Entities.Reparto>(reparto);
            this.repartosDAO.save(repartoEntity);
            return reparto;
        }

        public RepartoDTO GetRepartoByID(int id)
        {
            var reparto = this.repartosDAO.findByID(id);
            if (reparto != null)
            {
                RepartoDTO repDTO = Mapper.Map<Entities.Reparto, RepartoDTO>(reparto);
                return repDTO;
            }
            else
            {
                throw new IdNotFoundException("Pedido");
            }
            
        }

        public void DeleteRepartoByID(int id)
        {
            this.repartosDAO.delete(this.repartosDAO.findByID(id));
        }

        public void UpdateRepartoByID(RepartoDTO reparto)
        {
            Entities.Reparto repartoEntity = Mapper.Map<RepartoDTO, Entities.Reparto>(reparto);
            this.repartosDAO.update(repartoEntity);
        }
    }
}
