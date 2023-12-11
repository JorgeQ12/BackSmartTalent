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
        List<HotelesByCondition> GetHotelByCondition(DateTime fechaEntrada, DateTime fechaSalida, int CantidadPersonas, string ciudad);

        /// <summary>
        /// Insertar Huesped
        /// </summary>
        /// <param name="huespedes"></param>
        /// <returns></returns>
        Guid InsertHuesped(Huespedes huespedes);

        /// <summary>
        /// Insertar Reserva
        /// </summary>
        /// <param name="reservas"></param>
        /// <param name="IdHuesped"></param>
        /// <returns></returns>
        Reservas InsertBooking(Reservas reservas, Guid IdHuesped);
    }
}
