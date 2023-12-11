using AutoMapper;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Automapper
{
    public class GlobalMapper : Profile
    {
        public GlobalMapper()
        {
            CreateMap<HotelesDTO, Hoteles>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.Nombre, opt => opt.MapFrom(source => source.NombreDTO))
                .ForMember(target => target.Direccion, opt => opt.MapFrom(source => source.DireccionDTO))
                .ForMember(target => target.Cuidad, opt => opt.MapFrom(source => source.CuidadDTO))
                .ForMember(target => target.Activo, opt => opt.MapFrom(source => true));

            CreateMap<HabitacionesDTO, Habitaciones>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.IdHotel, opt => opt.MapFrom(source => source.IdHotelDTO))
                .ForMember(target => target.TipoHabitacion, opt => opt.MapFrom(source => source.TipoHabitacionDTO))
                .ForMember(target => target.CostoBase, opt => opt.MapFrom(source => source.CostoBaseDTO))
                .ForMember(target => target.Impuestos, opt => opt.MapFrom(source => source.ImpuestosDTO))
                .ForMember(target => target.CantidadPersonas, opt => opt.MapFrom(source => source.CantidadPersonasDTO))
                .ForMember(target => target.Ubicacion, opt => opt.MapFrom(source => source.UbicacionDTO))
                .ForMember(target => target.Activo, opt => opt.MapFrom(source => true));

            CreateMap<HotelesUpdateDTO, Hoteles>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.IdHotelDTO))
                .ForMember(target => target.Nombre, opt => opt.MapFrom(source => source.NombreDTO))
                .ForMember(target => target.Direccion, opt => opt.MapFrom(source => source.DireccionDTO))
                .ForMember(target => target.Cuidad, opt => opt.MapFrom(source => source.CuidadDTO))
                .ForMember(target => target.Activo, opt => opt.MapFrom(source => source.ActivoDTO));

            CreateMap<HabitacionesUpdateDTO, Habitaciones>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.IdHabitacionDTO))
                .ForMember(target => target.IdHotel, opt => opt.MapFrom(source => source.IdHotelDTO))
                .ForMember(target => target.TipoHabitacion, opt => opt.MapFrom(source => source.TipoHabitacionDTO))
                .ForMember(target => target.CostoBase, opt => opt.MapFrom(source => source.CostoBaseDTO))
                .ForMember(target => target.Impuestos, opt => opt.MapFrom(source => source.ImpuestosDTO))
                .ForMember(target => target.CantidadPersonas, opt => opt.MapFrom(source => source.CantidadPersonasDTO))
                .ForMember(target => target.Ubicacion, opt => opt.MapFrom(source => source.UbicacionDTO))
                .ForMember(target => target.Activo, opt => opt.MapFrom(source => source.ActivoDTO));

            CreateMap<ContactoEmergenciaDTO, ContactoEmergencia>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.NombresCompletos, opt => opt.MapFrom(source => source.NombresCompletosDTO))
                .ForMember(target => target.Telefono, opt => opt.MapFrom(source => source.TelefonoDTO));

            CreateMap<HuespedesDTO, Huespedes>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.Nombres, opt => opt.MapFrom(source => source.NombresDTO))
                .ForMember(target => target.Apellidos, opt => opt.MapFrom(source => source.ApellidosDTO))
                .ForMember(target => target.FechaNacimiento, opt => opt.MapFrom(source => source.FechaNacimientoDTO))
                .ForMember(target => target.Genero, opt => opt.MapFrom(source => source.GeneroDTO))
                .ForMember(target => target.TipoDocumento, opt => opt.MapFrom(source => source.TipoDocumentoDTO))
                .ForMember(target => target.NumeroDocumento, opt => opt.MapFrom(source => source.NumeroDocumentoDTO))
                .ForMember(target => target.Email, opt => opt.MapFrom(source => source.EmailDTO))
                .ForMember(target => target.Telefono, opt => opt.MapFrom(source => source.TelefonoDTO));

            CreateMap<InsertBookingDTO, Reservas>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.IdHabitacion, opt => opt.MapFrom(source => source.IdHabitacionDTO))
                .ForMember(target => target.FechaEntrada, opt => opt.MapFrom(source => source.FechaEntradaDTO))
                .ForMember(target => target.FechaSalida, opt => opt.MapFrom(source => source.FechaSalidaDTO))
                .ForMember(target => target.CantidadPersonas, opt => opt.MapFrom(source => source.CantidadPersonasDTO))
                .ForMember(target => target.CiudadDestino, opt => opt.MapFrom(source => source.CiudadDestinoDTO))
                .ForMember(target => target.Activo, opt => opt.MapFrom(source => source.ActivoDTO));

        }
    }
}
