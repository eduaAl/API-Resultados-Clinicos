using Aplicacion.Pais;
using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaboratorioController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatAreasLabServicios>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }
    }
}
