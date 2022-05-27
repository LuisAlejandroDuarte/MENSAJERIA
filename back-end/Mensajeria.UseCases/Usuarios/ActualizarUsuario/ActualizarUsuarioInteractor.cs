using Mensajeria.DTOs.Usuarios;
using Mensajeria.Entities.Interfaces;
using Mensajeria.Entities.POCOs;
using Mensajeria.UseCasesPorts.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Usuarios.ActualizarUsuario
{
    internal class ActualizarUsuarioInteractor : IActualizarUsuarioInPutPort
    {
        readonly IUsuarioRepository Repository;
        readonly IActualizarUsuarioOutPutPort OutPutPort;
        readonly IUnitOfWork UnitOfWork;
public ActualizarUsuarioInteractor(IUsuarioRepository repository, IActualizarUsuarioOutPutPort outPutPort, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            OutPutPort = outPutPort;
            UnitOfWork = unitOfWork;
        }

        public async Task Handle(ActualizarUsuarioDTO usuario)
        {
            Repository.ActualizarUsuario(usuario);
            await UnitOfWork.SaveChanges();
            await OutPutPort.Handle(true);
        }
    }
}
