using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.UseCases.Usuarios.GetUsuario
{
    public class GetUsuarioInteractor : IGetUsuarioInPutPort
    {

        private readonly IGetUsuarioOutPutPort outPutPort;
        private readonly IUsuarioRepository repository;

        public GetUsuarioInteractor(IGetUsuarioOutPutPort outPutPort, IUsuarioRepository repository)
        {
            this.outPutPort = outPutPort;
            this.repository = repository;
        }

        public Task Handle(long Id)
        {
            var usuario = this.repository.GetUser(Id);

            if (usuario==null)
            {
                throw new Exception("No se encontro el usuario con el Id:" + Id);
            }            

            this.outPutPort.Handle(usuario);
            return Task.CompletedTask;
        }
    }
}
