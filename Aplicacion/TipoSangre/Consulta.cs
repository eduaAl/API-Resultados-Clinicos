﻿using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoSangre
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatTipoSangre>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatTipoSangre>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatTipoSangre>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var sangre = await _context.TblCatTipoSangre.ToListAsync();
                return sangre;
            }
        }
    }
}
