using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly Services.ClientesService clientesSrv;

        public ClientesController(Services.ClientesService clientesSrv)
        {
            this.clientesSrv = clientesSrv;
        }


        [HttpGet]
        public IActionResult GetClientes()
        {
            try
            {
                return Ok(this.clientesSrv.GetClientes());
            }
            catch (Exception)
            { 
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route ("{id}")]
        public IActionResult GetClientByID(int id)
        {
            try
            {
                return Ok(this.clientesSrv.GetClienteByID(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}