using System;
using API_Repartidor.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("repartos")]
    [ApiController]
    public class RepartosController : ControllerBase
    {
        private readonly Services.RepartosService repartosSrv;


        public RepartosController(Services.RepartosService repartosSrv)
        {
            this.repartosSrv = repartosSrv;
        }


        /// <summary>
        /// Trae todos los repartos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.repartosSrv.GetRepartos());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Pedidos de un reparto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/pedidos")]
        public IActionResult Get(int id)
        {
            return Ok(this.repartosSrv.GetPedidosOfReparto(id));
        }
        
        /// <summary>
        /// Agrega un nuevo reparto
        /// </summary>
        /// <param name="reparto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] RepartoDTO reparto)
        {
            RepartoDTO repartoResult = this.repartosSrv.AddReparto(reparto);
            return Ok(repartoResult);
        }
        
        /// <summary>
        /// Obtiene un reparto a partid de un ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get2(int id)
        {
            return Ok(this.repartosSrv.GetRepartoByID(id));
        }
        
        /// <summary>
        /// Elimina un reparto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            this.repartosSrv.DeleteRepartoByID(id);
            return Ok();
        }


        /// <summary>
        /// Actualiza un reparto por ID
        /// </summary>
        /// <param name="reparto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] RepartoDTO reparto)
        {
            this.repartosSrv.UpdateRepartoByID(reparto);
            return Ok();
        }
        
    }
}