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
        ResultResponse<List<HotelesByCondition>> GetHotelByCondition(DateTime fechaEntrada, DateTime fechaSalida, int CantidadPersonas, string ciudad);
        ///<summary>
        ///Insertar Reserva 
        ///</summary>
        ResultResponse<Reservas> InsertBooking(InsertBookingDTO insertBooking);
    }
}
