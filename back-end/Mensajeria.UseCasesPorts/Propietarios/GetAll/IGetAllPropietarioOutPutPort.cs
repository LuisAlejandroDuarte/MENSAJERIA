using Mensajeria.DTOs;
using Mensajeria.DTOs.Propietarios;

namespace Mensajeria.UseCasesPorts.Propietarios.GetAll
{
    public interface IGetAllPropietarioOutPutPort
    {
        Task Handle(ResultDataTable resultDataTable);

     
    }

    public interface IGetPropietariosOutPutPort
    {
        Task Handle(IEnumerable<PropietarioDTO> propietarios);
    }
}
