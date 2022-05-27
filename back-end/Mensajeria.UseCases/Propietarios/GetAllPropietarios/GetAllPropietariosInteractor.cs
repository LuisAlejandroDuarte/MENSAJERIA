using Mensajeria.DTOs;
using Mensajeria.DTOs.Propietarios;
using Mensajeria.Entities.Interfaces;
using Mensajeria.UseCasesPorts.Propietarios.GetAll;


namespace Mensajeria.UseCases.Propietarios.GetAllPropietarios
{
    public class GetAllPropietariosInteractor : IGetAllPropietariosInPutPort
    {
        readonly IPropietarioRepository repository;
        readonly IGetAllPropietarioOutPutPort outPort;

        public GetAllPropietariosInteractor(IPropietarioRepository repository, IGetAllPropietarioOutPutPort outPort)
        {
            this.repository = repository;
            this.outPort = outPort;
        }



        public Task Handle(Paginator paginador)
        {
            var propietarios = this.repository.GetAll(paginador);


            outPort.Handle(propietarios);
            return Task.CompletedTask;
        }


    }

    public class GetPropietariosInteractor : IGetPropietariosInPutPort
    {
        readonly IPropietarioRepository repository;
        readonly IGetPropietariosOutPutPort outPort;

        public GetPropietariosInteractor(IPropietarioRepository repository, IGetPropietariosOutPutPort outPort)
        {
            this.repository = repository;
            this.outPort = outPort;
        }

        public Task Handle(long empresaId)
        {
           var propietarios= this.repository.GetPropietarios(empresaId);
            outPort.Handle(propietarios);
            return Task.CompletedTask;
        }
    }

}
