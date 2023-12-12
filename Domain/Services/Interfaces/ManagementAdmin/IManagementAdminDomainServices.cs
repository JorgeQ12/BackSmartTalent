using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.Interfaces.ManagementAdmin
{
    public interface IManagementAdminDomainServices 
    {
        ///<summary>
        ///Traer reservas
        ///</summary>
        List<ReservationsDTO> GetBooking();
        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        Hotels InsertHotel(Hotels hotels);
        ///<summary>
        ///Insertar Habitaciones a Hoteles
        ///</summary>
        Rooms InsertRoomByHotel(Rooms rooms);
        ///<summary>
        ///Obtener el Hotel Existente
        /// </summary>
        Hotels GetHotelById(Guid id);
        ///<summary>
        ///Obtener la Habitacion Existente
        /// </summary>
        Rooms GetRoomById(Guid id);
        ///<summary>
        ///Actualizar el hotel existente
        /// </summary>
        Hotels UpdateHotel(Hotels hotels);
        ///<summary>
        ///Actualizar la habitacion existente
        /// </summary>
        Rooms UpdateRoom(Rooms rooms);

        ///<summary>
        ///Deshabilitar Hotel Existente
        ///</summary>
        Hotels DisabledHotel(Hotels hotels,DisabledHotelDTO disabledHotels);
        ///<summary>
        ///Deshabilitar Habitacion del hotel Existente
        ///</summary>
        Rooms DisabledRoomByHotel(Rooms rooms,DisabledRoomByHotelDTO disabledRooms);
    }
}
