using Mensajeria.DTOs;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.GetAllUsuarios
{
    public class GetAllUsuariosInteractor : IGetAllUsuariosInputPort
    {

        readonly IUsuarioRepository Repository;
        readonly IGetAllUsuariosOutputPort OutputPort;

        public GetAllUsuariosInteractor(IUsuarioRepository repository, IGetAllUsuariosOutputPort outputPort)
        {
            Repository = repository;
            OutputPort = outputPort;
        }

        public Task Handle(long EmpresaId)
        {
            var Usuarios = Repository.GetAll()?.Select(u =>
             new UsuarioDTO
             {
                 Id = u.Id,
                 User = u.User,
                 Nombre = u.Nombre,
                 Apellido = u.Apellido,
                 Direccion = u.Direccion,
                 Telefono = u.Telefono,
                 Rol=u.Rol,
                 Estado=u.Estado,
                 EmpresaId=u.EmpresaId                 
             });
                        

            OutputPort.Handle(Usuarios.Where(x => x.EmpresaId == EmpresaId).ToList());
            return Task.CompletedTask;
        }
    }

    public class GetUsuariosInteractor:IGetUsuariosInputPort
    {
        readonly IUsuarioRepository Repository;
        readonly IGetUsuariosOutPutPort OutputPort;

        public GetUsuariosInteractor(IUsuarioRepository repository, IGetUsuariosOutPutPort outputPort)
        {
            Repository = repository;
            OutputPort = outputPort;
        }

        public Task Handle(Paginator paginador)
        {
            var usuarios = this.Repository.GetAllUsuarios(paginador);

            OutputPort.Handle(usuarios);
            return Task.CompletedTask;
        }
    }
}
