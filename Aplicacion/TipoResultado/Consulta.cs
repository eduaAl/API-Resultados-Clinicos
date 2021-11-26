using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoResultado
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatTipoResultado>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatTipoResultado>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatTipoResultado>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var tipo = await _context.TblCatTipoResultado.ToListAsync();
                return tipo;
            }
        }
    }
}
