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
        public ResultResponse<User> validateUser(UserDTO user)
        {

            if (string.IsNullOrWhiteSpace(user.UsernameDTO))
            {
                return new ResultResponse<User>(false, GlobalResponses.LoginNombreUsuario);
            }

            if (string.IsNullOrWhiteSpace(user.PasswordDTO))
            {
                return new ResultResponse<User>(false, GlobalResponses.LoginContraseñaUsuario);
            }

            return null;
        }

        public ResultResponse<Rooms> ValidarHabitacion(RoomsDTO rooms)
        {
            if (rooms.IdHotelsDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.NoRelacionHotel);
            }

            if (string.IsNullOrWhiteSpace(rooms.TypeRoomDTO))
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.ErrorNombreHotel);
            }

            if (rooms.NumberPeopleDTO <= 0)
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.CantidadPersonasCero);
            }

            if (rooms.CostBaseDTO <= 0)
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.PrecioHotelIncorrecto);
            }

            if (rooms.TaxesDTO <= 0)
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.ImpuestoHotelIncorrecto);
            }

            if (string.IsNullOrWhiteSpace(rooms.LocationDTO))
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<Hotels> ValidarHotel(HotelsDTO hotels)
        {
            if (string.IsNullOrWhiteSpace(hotels.NamesDTO))
            {
                return new ResultResponse<Hotels>(false, GlobalResponses.ErrorNombreHotel);
            }
            if (string.IsNullOrWhiteSpace(hotels.AddressDTO))
            {
                return new ResultResponse<Hotels>(false, GlobalResponses.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<Hotels> ValidarHotelUpdate(HotelsUpdateDTO hotels)
        {
            if (hotels.IdHotelsDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Hotels>(false, GlobalResponses.ErrorIdHotel);
            }
            if (string.IsNullOrWhiteSpace(hotels.NamesDTO))
            {
                return new ResultResponse<Hotels>(false, GlobalResponses.ErrorNombreHotel);
            }
            if (string.IsNullOrWhiteSpace(hotels.AddressDTO))
            {
                return new ResultResponse<Hotels>(false, GlobalResponses.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<Rooms> ValidarHabitacionUpdate(RoomsUpdateDTO rooms)
        {
            if (rooms.IdRoomDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.NoRelacionHabitacion);
            }
            if (rooms.IdHotelsDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.NoRelacionHotel);
            }

            if (string.IsNullOrWhiteSpace(rooms.TypeRoomDTO))
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.ErrorNombreHotel);
            }

            if (rooms.NumberPeopleDTO <= 0)
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.CantidadPersonasCero);
            }

            if (rooms.CostBaseDTO <= 0)
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.PrecioHotelIncorrecto);
            }

            if (rooms.TaxesDTO <= 0)
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.ImpuestoHotelIncorrecto);
            }

            if (string.IsNullOrWhiteSpace(rooms.LocationDTO))
            {
                return new ResultResponse<Rooms>(false, GlobalResponses.ErrorDireccionHotel);
            }

            return null;
        }

        public ResultResponse<List<HotelsByCondition>> ValidateHotelByCondition(DateTime entryDate, DateTime departureDate, int numberPeople, string city)
        {
            if (entryDate >= departureDate)
            {
                return new ResultResponse<List<HotelsByCondition>>(false, GlobalResponses.ReservaFechasInvalidas);
            }

            if (numberPeople <= 0)
            {
                return new ResultResponse<List<HotelsByCondition>>(false, GlobalResponses.ReservaCantidadPersonasInvalida);
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                return new ResultResponse<List<HotelsByCondition>>(false, GlobalResponses.ReservaCiudadDestinoRequerido);
            }

            return null;
        }

        public ResultResponse<Reservations> ValidateBooking(InsertBookingDTO booking)
        {
            if (booking.IdRoomDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<Reservations>(false, GlobalResponses.ReservaIdHabitacionRequerido);
            }

            if (booking.GuestsDTO == null)
            {
                return new ResultResponse<Reservations>(false, GlobalResponses.ReservaHuespedesRequerido);
            }

            if (booking.EntryDateDTO >= booking.DepartureDateDTO)
            {
                return new ResultResponse<Reservations>(false, GlobalResponses.ReservaFechasInvalidas);
            }

            if (booking.NumberPeopleDTO <= 0)
            {
                return new ResultResponse<Reservations>(false, GlobalResponses.ReservaCantidadPersonasInvalida);
            }

            if (string.IsNullOrWhiteSpace(booking.CityDestinationDTO))
            {
                return new ResultResponse<Reservations>(false, GlobalResponses.ReservaCiudadDestinoRequerido);
            }

            return null;
        }

    }
}
