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

        /// <summary>
        /// Trae todos los clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(this.clientesSrv.GetClientes());
        }

        /// <summary>
        /// Trae un cliente a partir de un ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route ("{id}")]
        public IActionResult GetClientByID(int id)
        {
             return Ok(this.clientesSrv.GetClienteByID(id));
        }
    }
}