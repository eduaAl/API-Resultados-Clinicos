using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Laboratorio
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatAreasLabServicio>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatAreasLabServicio>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatAreasLabServicio>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var laboratorio = await _context.TblCatAreasLabServicio.ToListAsync();
                return laboratorio;
            }
        }
    }
}
