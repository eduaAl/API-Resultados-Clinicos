﻿using Aplicacion.Pais;
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
    public class ResultadoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblResultado>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}
