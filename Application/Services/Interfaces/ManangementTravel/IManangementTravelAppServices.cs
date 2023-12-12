using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.Interfaces.ManangementTravel
{
    public interface IManangementTravelAppServices
    {
        ///<summary>
        ///Traer reservas
        ///</summary>
        ResultResponse<List<HotelsByCondition>> GetHotelByCondition(DateTime entryDate, DateTime departureDate, int numberPeople, string city);
        ///<summary>
        ///Insertar Reserva 
        ///</summary>
        ResultResponse<Reservations> InsertBooking(InsertBookingDTO insertBooking);
    }
}
