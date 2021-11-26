using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Resultados
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdResultados { get; set; }
            public Guid? IdExamen { get; set; }
            public Guid IdOrden { get; set; }
            public string Resultado { get; set; }
            public string Observaciones { get; set; }
            public string Procesado { get; set; }
            public DateTime? FechaProcesa { get; set; }
            public string UsuarioProcesa { get; set; }
            public string Validado { get; set; }
            public DateTime? FechaValida { get; set; }
            public string UsuarioValida { get; set; }
            public int? Impreso { get; set; }
            public DateTime? FechaImprime { get; set; }
            public string UsuarioImprime { get; set; }
            public int Estado { get; set; }

            public virtual TblExamenes IdExamenNavigation { get; set; }
            public virtual TblOrdenes IdOrdenNavigation { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Resultado).NotEmpty();
                RuleFor(x => x.Observaciones).NotEmpty();
                RuleFor(x => x.Procesado).NotEmpty();
                RuleFor(x => x.FechaProcesa).NotEmpty();
                RuleFor(x => x.Validado).NotEmpty();
                RuleFor(x => x.FechaImprime).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ResultadoContext _context;
            public Manejador(ResultadoContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultado = new tblResultado
                {
                    Resultado = request.Resultado,
                    Observacion = request.Observacion,
                    Procesado = request.Procesado,
                    FechaProcesa = request.FechaProcesa,
                    Validado = request.Validado,
                    FechaImprime = request.FechaImprime

                };

                _context.TblResultado.Add(resultado);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el resultado");
            }
        }
    }
}