using Aplicacion.Resultados;
using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblResultado>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }
    }
}
