using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examenes
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatPerfilesExamenes>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatPerfilesExamenes>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatPerfilesExamenes>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var perfiles = await _context.TblCatPerfilesExamenes.ToListAsync();
                return perfiles;
            }
        }
    }
}
