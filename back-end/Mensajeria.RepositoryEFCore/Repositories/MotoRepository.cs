using AutoMapper;
using Mensajeria.DTOs;
using Mensajeria.DTOs.Motos;
using Mensajeria.Entities.Interfaces;
using Mensajeria.Entities.POCOs;
using Mensajeria.RepositoryEFCore.DataContext;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Mensajeria.RepositoryEFCore.Repositories
{

    public class MotoRepository : IMotoRepository
    {

        private readonly MensajeriaContext context;
        private readonly IMapper imapper;

        public MotoRepository(MensajeriaContext context, IMapper imapper)
        {
            this.context = context;
            this.imapper = imapper;
        }

        public void Actualizar(MotoDTO moto)
        {
            var find = this.context.Motos.FirstOrDefault(x => x.Id == moto.Id);
            if (find == null)
            {
                throw new Exception("La moto con el Id " + moto.Id + " no existe");
            }
            var modelo = this.imapper.Map<Moto>(moto);
            this.context.ChangeTracker.Clear();
            this.context.Update(modelo);
        }

        public void Crear(MotoDTO moto)
        {
            if (moto == null)
            {
                throw new Exception("La moto no existe");
            }
            var modelo = this.imapper.Map<Moto>(moto);
            this.context.Add(modelo);
        }

        public ResultDataTable GetAll(Paginator paginator)
        {
            List<MotoDTO> motos = new List<MotoDTO>();

            int totalReg = 0;
            int filterReg = 0;

            var data = this.context.Motos.Select(x => new { x,x.Propietario }).Where(p=> p.Propietario.EmpresaId == paginator.idEmpresa && p.Propietario.Estado == false).ToList();

            totalReg = data.Count();
            filterReg = data.Count();
            if (!string.IsNullOrWhiteSpace(paginator.searchby))
            {
                var filterBy = data.Where(x => x.x.Placa.Contains(paginator.searchby) ||
                                            x.x.Propietario.Nombre.Contains(paginator.searchby) ||
                                            x.x.Propietario.Apellido.Contains(paginator.searchby)).ToList();
                data = filterBy;
                filterReg = filterBy.Count();
                totalReg = data.Count();
            }

            if (!string.IsNullOrWhiteSpace(paginator.sortColumn.ToString()) && !string.IsNullOrWhiteSpace(paginator.sortDirection))
            {
                if (paginator.sortColumn=="nombrePropietario" && paginator.sortDirection=="asc")
                {
                    data = data.OrderBy(x => x.Propietario.Nombre).ToList();
                }

                if (paginator.sortColumn == "nombrePropietario" && paginator.sortDirection == "desc")
                {
                    data = data.OrderByDescending(x => x.Propietario.Nombre).ToList();
                }

                if (paginator.sortColumn == "placa" && paginator.sortDirection == "asc")
                {
                    data = data.OrderBy(x => x.x.Placa).ToList();
                }

                if (paginator.sortColumn == "placa" && paginator.sortDirection == "desc")
                {
                    data = data.OrderByDescending(x => x.x.Placa).ToList();
                }

            }

            foreach (var item in data)
            {
                motos.Add(new MotoDTO()
                {
                    Id=item.x.Id,
                    Placa=item.x.Placa,
                    Estado=item.x.Estado,
                    PropietarioId=item.x.PropietarioId,
                    NombrePropietario=item.x.Propietario.Nombre + ' ' + item.Propietario.Apellido,
                    Bloqueado = (item.x.Estado == true) ? "Si" : "No",
                    Edit = ""
                });
            }

            return new ResultDataTable()
            {
                data = motos,
                draw = paginator.draw.Value,
                recordsFiltered = filterReg,
                recordsTotal = totalReg,
            };
        }

        public MotoDTO GetMoto(long Id)
        {
            var moto = this.context.Motos.SingleOrDefault(x => x.Id == Id);

            if (moto == null)
            {
                throw new Exception("La moto no existe con Id" + Id);
            }

            var modelo = this.imapper.Map<MotoDTO>(moto);
            this.context.ChangeTracker.Clear();
            return modelo;

        }
    }
}
