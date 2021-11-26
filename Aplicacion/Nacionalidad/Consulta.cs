using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nacionalidad
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatNacionalidad>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatNacionalidad>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatNacionalidad>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var perfiles = await _context.TblCatNacionalidad.ToListAsync();
                return perfiles;
            }
        }
    }
}
