using Mensajeria.DTOs.Motos;
using System;

namespace Mensajeria.UseCasesPorts.Motos.Editar
{
    public interface IEditarMotoOutPutPort
    {
        Task Handle(MotoDTO moto);
    }
}
