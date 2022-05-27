using Mensajeria.DTOs.Reporte;
using Mensajeria.Entities.Interfaces;
using Mensajeria.RepositoryEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.RepositoryEFCore.Repositories
{
    public class ReporteRepository:IReporteRepository
    {
        readonly MensajeriaContext Context;

        public ReporteRepository(MensajeriaContext context)
        {
            Context = context;
        }

        public IEnumerable<RptFacturaDTO> GetReporteFactura(long empresaId)
        {
            var reporte = (from rutas in Context.Rutas
                           join turnos in Context.Turnos on rutas.TurnoId equals turnos.Id
                           join motos in Context.Motos on turnos.MotoId equals motos.Id
                           join propietarios in Context.Propietarios on motos.PropietarioId equals propietarios.Id
                           where (propietarios.EmpresaId == empresaId && rutas.Inicia.Date == DateTime.Now.Date && turnos.Estado==3)
                           group new
                           {
                               propietarios.Id,
                               propietarios.Nombre,
                               propietarios.Apellido,
                               motos.Placa,
                               rutas.Valor
                           } by new { propietarios.Id,propietarios.Nombre,propietarios.Apellido,motos.Placa } into agrupado
                           select new RptFacturaDTO()
                           {
                               PropietarioId=agrupado.Key.Id,
                               NombrePropietario=agrupado.Key.Nombre + ' ' + agrupado.Key.Apellido,
                               Placa=agrupado.Key.Placa,
                               Valor=agrupado.Sum(x=>x.Valor).Value                               
                           });

            return reporte;
   
        }
    }
}
