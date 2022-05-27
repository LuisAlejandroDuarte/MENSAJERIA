using Mensajeria.DTOs.Propietarios;
using Mensajeria.UseCasesPorts.Propietarios.Crear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter.Propietarios
{
    public class CrearPropietarioPresenter : ICrearPropietarioOutPutPort, IPresenter<PropietarioDTO>
    {
        public PropietarioDTO Content {get; private set;}

        public Task Handle(PropietarioDTO propietario)
        {
            Content = propietario;
            return Task.CompletedTask;
        }
    }
}
