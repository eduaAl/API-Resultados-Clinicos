using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Resultados
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblResultado>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblResultado>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblResultado>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var res = await _context.TblResultados.ToListAsync();
                return res;
            }
        }
    }
}
