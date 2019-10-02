using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("repartos")]
    [ApiController]
    public class RepartosController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }
    }
}