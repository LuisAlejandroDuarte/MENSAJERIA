using Mensajeria.DTOs;
using Mensajeria.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.Presenter
{
    public class GetAllUsuariosPresenter : IGetAllUsuariosOutputPort, IPresenter<IEnumerable<UsuarioDTO>>
    {
        public IEnumerable<UsuarioDTO> Content { get; private set; }

        public Task Handle(IEnumerable<UsuarioDTO> usuarios)
        {
            Content = usuarios;
            return Task.CompletedTask;
        }
    }

    public class GetUsuariosPresenter : IGetUsuariosOutPutPort, IPresenter<ResultDataTable>
    {
        public ResultDataTable Content { get; private set; }

        public Task Handle(ResultDataTable usuarios)
        {
            Content = usuarios;
            return Task.CompletedTask;
        }
    }
}
