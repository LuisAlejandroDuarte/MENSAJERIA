using AutoMapper;
using Mensajeria.DTOs.Rutas;
using Mensajeria.DTOs.Turnos;
using Mensajeria.Entities.Interfaces;
using Mensajeria.Entities.POCOs;
using Mensajeria.RepositoryEFCore.DataContext;


namespace Mensajeria.RepositoryEFCore.Repositories
{
    public class RutaRepository : IRutaRepository
    {
        readonly MensajeriaContext Context;
        readonly IMapper mapper;

        public RutaRepository(MensajeriaContext context,IMapper mapper)
        {
            Context = context;
            this.mapper = mapper;
        }

        public RutaDTO Crear(RutaDTO ruta)
        {
            var turno = Context.Turnos.Where(x => x.Id == ruta.TurnoId).FirstOrDefault();
            if (turno != null)
            {
                turno.Estado = (int)TypeTurnos.EnRuta;
                Context.ChangeTracker.Clear();
                Context.Update(turno);
                Context.SaveChanges();
            }
           ruta.Inicia = DateTime.Now;           
           var newRuta =this.mapper.Map<Ruta>(ruta);
            Context.ChangeTracker.Clear();
            Context.Add(newRuta);
            return ruta;
        }

        public RutaDTO Editar(RutaDTO ruta)
        {
            var newRuta = this.mapper.Map<Ruta>(ruta);

            Context.Update(newRuta);
            return ruta;
        }

        public IEnumerable<RutaDTO> GetAllDate(long empresaId)
        {

            return from rutas in Context.Rutas 
                                join turnos in Context.Turnos on rutas.TurnoId equals turnos.Id 
                                join motos in Context.Motos on turnos.MotoId equals motos.Id
                                join proietario in Context.Propietarios on motos.PropietarioId equals proietario.Id 
                                where (rutas.Estado==true && rutas.Inicia.Date==DateTime.Now.Date && proietario.EmpresaId==empresaId)
                                select new RutaDTO()
                                {
                                    Id=rutas.Id,
                                    Inicia=rutas.Inicia,
                                    Termina=rutas.Termina,
                                    Placa=motos.Placa,
                                    NombrePropietario=proietario.Nombre + ' ' +proietario.Apellido,
                                    Destino=rutas.Destino,
                                    Telefono=rutas.Telefono,
                                    Observacion=rutas.Observacion,
                                    Valor=rutas.Valor,
                                    Estado=rutas.Estado                                    
                                };            
        }

        public RutaDTO GetRutaByTurno(long turnoId)
        {
            var ruta = Context.Rutas.FirstOrDefault(x => x.TurnoId == turnoId);


            var rutaDTO = this.mapper.Map<RutaDTO>(ruta);

            return rutaDTO;
        }
    }
}
