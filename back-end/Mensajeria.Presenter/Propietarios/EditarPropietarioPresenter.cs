using Mensajeria.DTOs.Propietarios;
using Mensajeria.UseCasesPorts.Propietarios.Editar;

namespace Mensajeria.Presenter.Propietarios
{
    public class EditarPropietarioPresenter : IEditarPropietarioOutPutPort, IPresenter<PropietarioDTO>
    {
        public PropietarioDTO Content {get;private set;}    

        public Task Handle(PropietarioDTO propietario)
        {
            Content = propietario;
            return Task.CompletedTask;
        }
    }
}
