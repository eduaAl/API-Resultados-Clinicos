using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Usuario
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblUsuario>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblUsuario>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatPais>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _context.TblUsuario.ToListAsync();
                return usuario;
            }
        }
    }
}
