using Mensajeria.DTOs.Motos;
using Mensajeria.UseCasesPorts.Motos.Get;

namespace Mensajeria.Presenter.Motos
{
    public class GetMotoPresenter : IGetMotoOutPutPort, IPresenter<MotoDTO>
    {
        public MotoDTO Content { get; private set; }

        public Task Handle(MotoDTO moto)
        {
            Content = moto;
            return Task.CompletedTask;
        }
    }
}
