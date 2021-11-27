﻿using Aplicacion.Orden;
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
    public class OrdenController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblOrdenes>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }
    }
}
