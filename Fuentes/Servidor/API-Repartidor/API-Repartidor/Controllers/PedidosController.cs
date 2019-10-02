using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("pedidos")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "pedidos";
        }
    }
}