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
            return Ok(this.clientesSrv.GetClientes());
        }

        [HttpGet]
        [Route ("{id}")]
        public IActionResult GetClientByID(int id)
        {
             return Ok(this.clientesSrv.GetClienteByID(id));
        }
    }
}