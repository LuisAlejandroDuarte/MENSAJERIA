using Mensajeria.DTOs;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Usuarios.ChangePassword
{
    public class ChangePasswordInteractor : IChangePasswordInPutPort
    {

        readonly IUsuarioRepository repository;
        readonly IChangePasswordOutPutPort outPut;
        readonly IUnitOfWork unitOfWork;

        public ChangePasswordInteractor(IUsuarioRepository repository, IChangePasswordOutPutPort outPut, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.outPut = outPut;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UsuarioDTO usuario)
        {
            this.repository.ChangePassword(usuario);
            await this.unitOfWork.SaveChanges();
            await outPut.Handle(true);
        }
    }
}
