using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sucursal
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatSucursales>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatSucursales>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatSucursales>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var sucursal = await _context.TblCatSucursales.ToListAsync();
                return sucursal;
            }
        }
    }
}
