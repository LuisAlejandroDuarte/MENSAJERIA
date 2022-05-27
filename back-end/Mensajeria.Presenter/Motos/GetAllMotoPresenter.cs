
using Mensajeria.DTOs;
using Mensajeria.DTOs.Motos;
using Mensajeria.UseCasesPorts.Motos.GetAll;


namespace Mensajeria.Presenter.Motos
{
    public class GetAllMotoPresenter : IGetAllMotoOutPutPort, IPresenter<ResultDataTable>
    {
        public ResultDataTable Content { get; private set; }

        public Task Handle(ResultDataTable motos)
        {
            Content = motos;
            return Task.CompletedTask;
        }
    }
}
