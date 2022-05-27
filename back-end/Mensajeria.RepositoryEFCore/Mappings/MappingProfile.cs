using AutoMapper;
using Mensajeria.DTOs.Motos;
using Mensajeria.DTOs.Propietarios;
using Mensajeria.DTOs.Rutas;
using Mensajeria.DTOs.Turnos;
using Mensajeria.Entities.POCOs;

namespace Mensajeria.DTOs.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Propietario, PropietarioDTO>().ReverseMap();
            CreateMap<Moto, MotoDTO>().ReverseMap();
            CreateMap<Turno, TurnoDTO>().ReverseMap();
            CreateMap<Ruta, RutaDTO>().ReverseMap();

        }
    }
}
