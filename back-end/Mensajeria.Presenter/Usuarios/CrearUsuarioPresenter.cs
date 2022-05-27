using Mensajeria.DTOs;
using Mensajeria.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter
{
    public class CrearUsuarioPresenter : ICrearUsuarioOutPutPort, IPresenter<UsuarioDTO>
    {
        public UsuarioDTO Content { get; private set; }

        public Task Handle(UsuarioDTO usuario)
        {
            Content = usuario;
            return Task.CompletedTask;
        }
    }
}
