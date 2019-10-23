using API_Repartidor.DTOs;
using API_Repartidor.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace API_Repartidor.Services
{
    public class RepartosService
    {
        private readonly RepartosDAO repartosDAO;
        public RepartosService(RepartosDAO repartosDAO)
        {
            this.repartosDAO = repartosDAO;
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
            RepartoDTO repDTO = Mapper.Map<Entities.Reparto, RepartoDTO>(this.repartosDAO.findByID(id));
            return repDTO;
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
