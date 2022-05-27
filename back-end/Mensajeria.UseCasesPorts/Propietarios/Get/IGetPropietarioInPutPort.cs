namespace Mensajeria.UseCasesPorts.Propietarios.Get
{
    public interface IGetPropietarioInPutPort
    {
        Task Handle(long Id);
    }
}
