using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Resources;
using BackSmartTalent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Validators
{
    public class GlobalValidator
    {
        public ResultResponse<Usuario> validateUser(UsuarioDTO usuario)
        {

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuarioDTO))
            {
                return new ResultResponse<Usuario>(false, RespuestasGlobales.LoginNombreUsuario);
            }

            if (string.IsNullOrWhiteSpace(usuario.ContraseñaDTO))
            {
                return new ResultResponse<Usuario>(false, RespuestasGlobales.LoginContraseñaUsuario);
            }

            return null;
        }

        public ResultResponse<Habitaciones> ValidarHabitacion(HabitacionesDTO habitaciones)
        {
            if (habitaciones.IdHotelDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.NoRelacionHotel);
            }

            if (string.IsNullOrWhiteSpace(habitaciones.TipoHabitacionDTO))
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.ErrorNombreHotel);
            }

            if (habitaciones.CantidadPersonasDTO <= 0)
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.CantidadPersonasCero);
            }

            if (habitaciones.CostoBaseDTO <= 0)
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.PrecioHotelIncorrecto);
            }

            if (habitaciones.ImpuestosDTO <= 0)
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.ImpuestoHotelIncorrecto);
            }

            if (string.IsNullOrWhiteSpace(habitaciones.UbicacionDTO))
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<Hoteles> ValidarHotel(HotelesDTO hoteles)
        {
            if (string.IsNullOrWhiteSpace(hoteles.NombreDTO))
            {
                return new ResultResponse<Hoteles>(false, RespuestasGlobales.ErrorNombreHotel);
            }
            if (string.IsNullOrWhiteSpace(hoteles.DireccionDTO))
            {
                return new ResultResponse<Hoteles>(false, RespuestasGlobales.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<Hoteles> ValidarHotelUpdate(HotelesUpdateDTO hoteles)
        {
            if (hoteles.IdHotelDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Hoteles>(false, RespuestasGlobales.ErrorIdHotel);
            }
            if (string.IsNullOrWhiteSpace(hoteles.NombreDTO))
            {
                return new ResultResponse<Hoteles>(false, RespuestasGlobales.ErrorNombreHotel);
            }
            if (string.IsNullOrWhiteSpace(hoteles.DireccionDTO))
            {
                return new ResultResponse<Hoteles>(false, RespuestasGlobales.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<Habitaciones> ValidarHabitacionUpdate(HabitacionesUpdateDTO habitaciones)
        {
            if (habitaciones.IdHabitacionDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.NoRelacionHabitacion);
            }
            if (habitaciones.IdHotelDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.NoRelacionHotel);
            }

            if (string.IsNullOrWhiteSpace(habitaciones.TipoHabitacionDTO))
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.ErrorNombreHotel);
            }

            if (habitaciones.CantidadPersonasDTO <= 0)
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.CantidadPersonasCero);
            }

            if (habitaciones.CostoBaseDTO <= 0)
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.PrecioHotelIncorrecto);
            }

            if (habitaciones.ImpuestosDTO <= 0)
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.ImpuestoHotelIncorrecto);
            }

            if (string.IsNullOrWhiteSpace(habitaciones.UbicacionDTO))
            {
                return new ResultResponse<Habitaciones>(false, RespuestasGlobales.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<List<HotelesByCondition>> ValidateHotelByCondition(DateTime fechaEntrada, DateTime fechaSalida, int CantidadPersonas, string ciudad)
        {
            if (fechaEntrada >= fechaSalida)
            {
                return new ResultResponse<List<HotelesByCondition>>(false, RespuestasGlobales.ReservaFechasInvalidas);
            }

            if (CantidadPersonas <= 0)
            {
                return new ResultResponse<List<HotelesByCondition>>(false, RespuestasGlobales.ReservaCantidadPersonasInvalida);
            }

            if (string.IsNullOrWhiteSpace(ciudad))
            {
                return new ResultResponse<List<HotelesByCondition>>(false, RespuestasGlobales.ReservaCiudadDestinoRequerido);
            }

            return null;
        }

        public ResultResponse<Reservas> ValidateBooking(InsertBookingDTO reserva)
        {
            if (reserva.IdHabitacionDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Reservas>(false, RespuestasGlobales.ReservaIdHabitacionRequerido);
            }

            if (reserva.HuespedesDTO == null)
            {
                return new ResultResponse<Reservas>(false, RespuestasGlobales.ReservaHuespedesRequerido);
            }

            if (reserva.FechaEntradaDTO >= reserva.FechaSalidaDTO)
            {
                return new ResultResponse<Reservas>(false, RespuestasGlobales.ReservaFechasInvalidas);
            }

            if (reserva.CantidadPersonasDTO <= 0)
            {
                return new ResultResponse<Reservas>(false, RespuestasGlobales.ReservaCantidadPersonasInvalida);
            }

            if (string.IsNullOrWhiteSpace(reserva.CiudadDestinoDTO))
            {
                return new ResultResponse<Reservas>(false, RespuestasGlobales.ReservaCiudadDestinoRequerido);
            }

            return null;
        }

    }
}
