using Mensajeria.DTOs;
using Mensajeria.DTOs.Propietarios;
using Mensajeria.UseCasesPorts.Propietarios.GetAll;

namespace Mensajeria.Presenter.Propietarios
{
    public class GetAllPropietariosPresenter : IGetAllPropietarioOutPutPort, IPresenter<ResultDataTable>
    {
        public ResultDataTable Content { get;private set; }

        

        public Task Handle(ResultDataTable resultDataTable)
        {
            Content = resultDataTable;
            return Task.CompletedTask;
        }
    }

    public class GetPropietariosPresenter : IGetPropietariosOutPutPort, IPresenter<IEnumerable<PropietarioDTO>>
    {
        public IEnumerable<PropietarioDTO> Content { get; private set; }

        public Task Handle(IEnumerable<PropietarioDTO> propietarios)
        {
            Content = propietarios;
            return Task.CompletedTask;
        }
    }
}
