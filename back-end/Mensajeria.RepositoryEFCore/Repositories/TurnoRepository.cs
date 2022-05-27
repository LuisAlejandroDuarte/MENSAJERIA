using AutoMapper;
using Mensajeria.DTOs.Motos;
using Mensajeria.DTOs.Turnos;
using Mensajeria.Entities.Interfaces;
using Mensajeria.Entities.POCOs;
using Mensajeria.RepositoryEFCore.DataContext;

namespace Mensajeria.RepositoryEFCore.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {

        private readonly MensajeriaContext Context;
        private readonly IMapper imapper;

        public TurnoRepository(MensajeriaContext context, IMapper imapper)
        {
            Context = context;
            this.imapper = imapper;
        }

        public TurnoDTO Crear(TurnoDTO turno)
        {
            int maxPosicion = 0;
            var datos = Context.Turnos.Select(s => new { s, s.Moto.Propietario })
                                .Where(x => x.s.FechaHora.Date == DateTime.Now.Date                                       
                                       && x.s.Moto.Propietario.EmpresaId == turno.EmpresaId);
                                
           if (datos.Any())
            {
             maxPosicion =   Context.Turnos.Select(s => new { s, s.Moto.Propietario })
                               .Where(x => x.s.FechaHora.Date == DateTime.Now.Date                                      
                                      && x.s.Moto.Propietario.EmpresaId == turno.EmpresaId)
                               .Max(p=>p.s.Posicion);
            }
            
          turno.Posicion = maxPosicion + 1;
            turno.FechaHora = DateTime.Now;
            turno.Estado = TypeTurnos.Disponible; 
            Context.ChangeTracker.Clear();

            var newTurno = this.imapper.Map<Turno>(turno);

            Context.Add(newTurno);            
            return turno;
        }

        public IEnumerable<TurnoDTO> ObtenerEnEspera(long empresaId)
        {
            //y.item.FechaHora.Date.ToString("yyyy-MM-dd") == DateTime.Now.Date.ToString("yyyy-MM-dd") &&
            var fecha = DateTime.Now.Date;
            List<TurnoDTO> listTurnos = new List<TurnoDTO>();
            var turnos = Context.Turnos.Select(item => new { item,item.Moto, item.Moto.Propietario })
                .Where(y=>y.item.Moto.Estado==false && (y.item.Estado==(int)TypeTurnos.Disponible || y.item.Estado==(int)TypeTurnos.EnRuta) &&
                     y.item.Moto.Propietario.EmpresaId==empresaId && 
                     y.item.FechaHora.Date== DateTime.Now.Date)
                .OrderBy(p=>p.item.Posicion);
            
            if (turnos.Any())
            {
                foreach (var item in turnos)
                {
                    listTurnos.Add(new TurnoDTO()
                    {
                        Id = item.item.Id,                        
                        Placa = item.item.Moto.Placa,
                        NombrePropietario = String.Concat(item.item.Moto.Propietario.Nombre, ' ', item.item.Moto.Propietario.Apellido),
                        Estado = (item.item.Estado==1)? TypeTurnos.Disponible: (item.item.Estado == 2) ? TypeTurnos.EnRuta:TypeTurnos.Terminado,
                        FechaHora = item.item.FechaHora,
                        MotoId = item.item.MotoId,
                        Posicion = item.item.Posicion                        
                    });
                }
            }

            foreach (var item in listTurnos)
            {
                if (Context.Rutas.FirstOrDefault(x => x.TurnoId == item.Id)!=null)
                    item.Inicia = Context.Rutas.FirstOrDefault(x => x.TurnoId == item.Id).Inicia;
            }

                return listTurnos;
        }

        public IEnumerable<MotoDTO> GetMotoDisponible(long empresaId)
        {
           return from motos in Context.Motos
                        join propietario in Context.Propietarios on motos.PropietarioId equals propietario.Id
                        where (propietario.EmpresaId == empresaId && motos.Estado == false && propietario.Estado == false)
                        where !(from turnos in Context.Turnos
                                where (turnos.FechaHora.Date == DateTime.Now.Date && (turnos.Estado==1 || turnos.Estado==2))
                                select turnos.MotoId)
                        .Contains(motos.Id)
                        select new MotoDTO
                        {
                            Id = motos.Id,
                            Placa = motos.Placa,
                            Estado = motos.Estado,
                            NombrePropietario=motos.Propietario.Nombre + ' ' + motos.Propietario.Apellido
                        };            
        }

        public TurnoDTO Get(long Id)
        {
            var findturno = (from turno in Context.Turnos
                         join moto in Context.Motos on turno.MotoId equals moto.Id
                         join propietario in Context.Propietarios on moto.PropietarioId equals propietario.Id
                         where turno.Id == Id select new TurnoDTO()
                         {
                             Id=turno.Id,
                             EmpresaId=propietario.EmpresaId,
                             Estado = (turno.Estado == 1) ? TypeTurnos.Disponible : (turno.Estado == 2) ? TypeTurnos.EnRuta : TypeTurnos.Terminado,
                             FechaHora=turno.FechaHora,
                             MotoId=moto.Id,
                             NombrePropietario=String.Concat(propietario.Nombre + ' ' + propietario.Apellido),
                             Placa=moto.Placa,
                             Posicion=turno.Posicion                            
                         }).FirstOrDefault();
                        
            if (findturno == null)
            {
                throw new Exception("El turno no existe con ese Id " + Id);
            }            
            return findturno;

        }

        public TurnoDTO Delete(long Id)
        {
           var turno = Context.Turnos.FirstOrDefault(x=>x.Id==Id);
            if (turno==null)
            {
                throw new Exception("El turno con Id " + Id + " no existe");
            }

            Context.Remove(turno);

            return this.imapper.Map<TurnoDTO>(turno);
        }

        public TurnoDTO Editar(TurnoDTO turno)
        {
            var turnoEditado = Context.Turnos.FirstOrDefault(x => x.Id == turno.Id);
            if (turnoEditado==null)
            {
                throw new Exception("El turno con el Id " + turno.Id + " no existe");
            }

            turnoEditado.Id = turno.Id;
            turnoEditado.Estado =(int)turno.Estado;
            turnoEditado.Posicion = turno.Posicion;
            turnoEditado.FechaHora = turno.FechaHora;
            

            Context.Update(turnoEditado);

            return turno;

        }
    }
}
