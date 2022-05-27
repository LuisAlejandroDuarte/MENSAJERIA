using Mensajeria.UseCasesPorts.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Usuarios
{
    public class ActualizarUsuarioPresenter : IActualizarUsuarioOutPutPort, IPresenter<bool>
    {
        public bool Content { get; private set; }

        public Task Handle(bool result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}
