using AutoMapper;
using Mensajeria.DTOs;
using Mensajeria.DTOs.Propietarios;
using Mensajeria.Entities.Interfaces;
using Mensajeria.Entities.POCOs;
using Mensajeria.RepositoryEFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Mensajeria.RepositoryEFCore.Repositories
{
    public class PropietarioRepository :  IPropietarioRepository
    {
        private readonly MensajeriaContext Context;
        private readonly IMapper imapper;
        
        public PropietarioRepository(MensajeriaContext context, IMapper imapper)
        {
            Context = context;
            this.imapper = imapper;            
          
        }

        public void Actualizar(PropietarioDTO propietario)
        {
            var find =Context.Propietarios.FirstOrDefault(x=>x.Id==propietario.Id);
            if (find==null)
            {
                throw new Exception("El propietario con el Id " + propietario.Id + " no existe");
            }

            if (propietario.Identificacion!=find.Identificacion)
            {
                var existeIdentificacion = Context.Propietarios.FirstOrDefault(x => x.Identificacion == propietario.Identificacion && x.EmpresaId == propietario.EmpresaId);
                if (existeIdentificacion != null)
                {
                    throw new Exception("La identificación ya existe");
                }
            }            

            var modelo = this.imapper.Map<Propietario>(propietario);
            Context.ChangeTracker.Clear();
            Context.Update(modelo);
        }

        public PropietarioDTO GetPropietario(long Id)
        {
            var propietario = Context.Propietarios.SingleOrDefault(x=>x.Id==Id);

            if (propietario==null)
            {
                throw new Exception("El propietario no existe con Id" + Id);
            }

            var modelo = this.imapper.Map<PropietarioDTO>(propietario);
            Context.ChangeTracker.Clear();
            return modelo;


        }

        public void Crear(PropietarioDTO propietario)
        {
            if (propietario==null) {
                throw new Exception("El propietario no existe");
            }

            var existeIdentioficacion = Context.Propietarios.FirstOrDefault(x => x.Identificacion == propietario.Identificacion && x.EmpresaId == propietario.EmpresaId);
            if (existeIdentioficacion!=null)
            {
                throw new Exception("La identificación ya existe");
            }

            var modelo = this.imapper.Map<Propietario>(propietario);
            Context.ChangeTracker.Clear();
            Context.Add(modelo);

        }


        public ResultDataTable GetAll(Paginator paginator)
        {
            int totalReg=0;
            int filterReg = 0;
            var data= Context.Propietarios.Where(x => x.EmpresaId == paginator.idEmpresa);
            totalReg = data.Count();
            filterReg = data.Count();
            if (!string.IsNullOrWhiteSpace(paginator.searchby))
            {
                var filterBy = data.Where(x =>
                                x.Identificacion.Contains(paginator.searchby) ||
                                x.Nombre.Contains(paginator.searchby) ||
                                x.Apellido.Contains(paginator.searchby) ||
                                x.Direccion.Contains(paginator.searchby) ||
                                x.Telefono.Contains(paginator.searchby));
                data = filterBy;
                filterReg = filterBy.Count();
                totalReg = data.Count();
            }

            if (!string.IsNullOrWhiteSpace(paginator.sortColumn.ToString()) && !string.IsNullOrWhiteSpace(paginator.sortDirection))
            {
                paginator.sortColumn = paginator.sortColumn == "bloqueado" ? "Estado" : paginator.sortColumn;
                data = data.OrderBy(paginator.sortColumn.ToString() + " " + paginator.sortDirection);

            }

            data = data.Skip(paginator.start).Take(paginator.length);



            var modelo = new List<PropietarioDTO>();
            foreach (var item in data)
            {
                modelo.Add(new PropietarioDTO()
                {
                    Id = item.Id,
                    EmpresaId = item.EmpresaId,
                    Identificacion = item.Identificacion,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Direccion = item.Direccion,
                    Telefono = item.Telefono,
                    Estado = item.Estado,
                    //Para mostrar en tabla DataTable.NET
                    Bloqueado = (item.Estado == true) ? "Si" : "No",
                    Edit = ""
                });
            }

                     
             

            return new ResultDataTable()
            {
                data = modelo,
                draw = paginator.draw.Value,
                recordsFiltered = filterReg,
                recordsTotal = totalReg,
            };
        }

        public IEnumerable<PropietarioDTO> GetPropietarios(long empresaId)
        {
            var propietarios= Context.Propietarios.Where(x => x.EmpresaId == empresaId && x.Estado == false).OrderBy(x=>x.Nombre);

            var datos = this.imapper.Map<IEnumerable<PropietarioDTO>>(propietarios);

            return datos;
        }
    }
}
