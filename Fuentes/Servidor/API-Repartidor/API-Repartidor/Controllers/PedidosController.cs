using System;
using API_Repartidor.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("pedidos")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly Services.PedidosService pedidosSrv;


        public PedidosController(Services.PedidosService pedidosSrv)
        {
            this.pedidosSrv = pedidosSrv;
        }


        /// <summary>
        /// Trae todos los pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.pedidosSrv.GetPedidos());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Trae todos los pedidos pendientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/pedidos/pendientes")]
        public IActionResult GetPendientes()
        {
            try
            {
                return Ok(this.pedidosSrv.GetPedidosCompletos());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Agrega un nuevo pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] PedidoDTO pedido)
        {
            PedidoDTO pedidoResult = this.pedidosSrv.AddPedido(pedido); 
            return Ok(pedidoResult);
        }

        /// <summary>
        /// Obtiene un pedido a partid de un ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(this.pedidosSrv.GetPedidoByID(id));
        }

        /// <summary>
        /// Elimina un pedido por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            this.pedidosSrv.DeletePedidoByID(id);
            return Ok();
        }


        /// <summary>
        /// Actualiza un pedido por ID
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] PedidoDTO pedido)
        {
            this.pedidosSrv.UpdatePedidoByID(pedido);
            return Ok();
        }
    }
}