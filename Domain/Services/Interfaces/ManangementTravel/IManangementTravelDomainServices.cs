using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Domain.Services.Interfaces.ManangementTravel
{
    public interface IManangementTravelDomainServices
    {
        ///<summary>
        ///Traer reservas
        ///</summary>
        List<HotelsByCondition> GetHotelByCondition(DateTime entryDate, DateTime departureDate, int numberPeople, string city);

        /// <summary>
        /// Insertar Huesped
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        Guid InsertHuesped(Guests guests);

        /// <summary>
        /// Insertar Reserva
        /// </summary>
        /// <param name="reservations"></param>
        /// <param name="IdGuests"></param>
        /// <returns></returns>
        Reservations InsertBooking(Reservations reservations, Guid IdGuests);
    }
}
