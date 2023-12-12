using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.Interfaces.ManagementAdmin
{
    public interface IManagementAdminAppServices
    {
        ///<summary>
        ///Traer reservas
        ///</summary>
        ResultResponse<List<ReservationsDTO>> GetBooking();

        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        ResultResponse<Hotels> InsertHotel(HotelsDTO hotels);
        ///<summary>
        ///Insertar Habitaciones a Hoteles
        ///</summary>
        ResultResponse<Rooms> InsertRoomByHotel(RoomsDTO rooms);

        ///<summary>
        ///Actualizar el hotel existente
        /// </summary>
        ResultResponse<Hotels> UpdateHotel(HotelsUpdateDTO hotels);
        ///<summary>
        ///Actualizar la habitacion existente
        /// </summary>
        ResultResponse<Rooms> UpdateRoom(RoomsUpdateDTO rooms);
        ///<summary>
        ///Deshabilitar Hotel Existente
        ///</summary>
        ResultResponse<Hotels> DisabledHotel(DisabledHotelDTO hotels);
        ///<summary>
        ///Deshabilitar Habitacion del hotel Existente
        ///</summary>
        ResultResponse<Rooms> DisabledRoomByHotel(DisabledRoomByHotelDTO rooms);
    }
}
