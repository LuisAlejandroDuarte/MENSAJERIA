using Mensajeria.DTOs;
using Mensajeria.Entities.Interfaces;
using Mensajeria.Entities.POCOs;
using Mensajeria.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.CrearUsuario
{
    public class CrearUsuarioInteractor : ICrearUsuarioInputPort
    {
        readonly IUsuarioRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICrearUsuarioOutPutPort OutputPort;

        public CrearUsuarioInteractor(IUsuarioRepository repository, IUnitOfWork unitOfWork, ICrearUsuarioOutPutPort outputPort)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
            OutputPort = outputPort;
        }

        public async Task Handle(CrearUsuarioDTO usuario)
        {
            Usuario NewUsuario = new Usuario
            {
                User = usuario.User,
                Password = usuario.Password,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                EmpresaId = usuario.EmpresaId,
                Estado=usuario.Estado,
                Rol=usuario.Rol
            };

            Repository.CrearUsuarios(NewUsuario);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle(
                new UsuarioDTO
                {
                    Id = NewUsuario.Id,
                    User = NewUsuario.User,
                    Nombre = NewUsuario.Nombre,
                    Apellido = NewUsuario.Apellido,
                    Direccion = NewUsuario.Direccion,
                    Telefono = NewUsuario.Telefono,     
                    Estado=NewUsuario.Estado,
                    Rol = usuario.Rol
                });
        }
    }
}
