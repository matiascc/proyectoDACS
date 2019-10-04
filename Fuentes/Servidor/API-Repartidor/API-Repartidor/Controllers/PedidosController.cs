using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DTOs;

using Microsoft.AspNetCore.Http;
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
            this.pedidosSrv.GetPedidos();
            return Ok("pedidos");
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
            return Ok("return pedidoByID" + id);
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
            return Ok("DeletePedidoResponse" + id);
        }


        /// <summary>
        /// Actualiza un pedido por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id)
        {
            return Ok("UpdatePedidoResponse" + id);
        }
    }
}