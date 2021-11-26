using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.OrdenDetalle
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblOrdenesDetalle>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblOrdenesDetalles>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblOrdenesDetalle>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var ordenes = await _context.TblOrdenesDetalle.ToListAsync();
                return ordenes;
            }
        }
    }
}
