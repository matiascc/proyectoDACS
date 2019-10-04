using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("repartos")]
    [ApiController]
    public class RepartosController : ControllerBase
    {
        private readonly Services.RepartosService repartosSrv;

        public RepartosController (Services.RepartosService repartosSrv)
        {
            this.repartosSrv = repartosSrv;
        }


        [HttpPost]
        public IActionResult Post([FromBody] RepartoDTO value)
        {
            var result = this.repartosSrv.AddReparto(value);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}