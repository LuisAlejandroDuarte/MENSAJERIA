using Mensajeria.DTOs;
using Mensajeria.UseCasesPorts.Usuarios;


namespace Mensajeria.Presenter.Usuarios
{
    public class RenewTokenPresenter:IRenewTokenOutPutPort, IPresenter<UsuarioDTO>
    {
        public UsuarioDTO Content { get; private set; }

        public Task Handle(UsuarioDTO usuario)
        {
            Content = usuario;
            return Task.CompletedTask;

        }       
    }
}
