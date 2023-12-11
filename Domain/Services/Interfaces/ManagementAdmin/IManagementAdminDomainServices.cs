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
        List<ReservasDTO> GetBooking();
        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        Hoteles InsertHotel(Hoteles hotel);
        ///<summary>
        ///Insertar Habitaciones a Hoteles
        ///</summary>
        Habitaciones InsertRoomByHotel(Habitaciones habitaciones);
        ///<summary>
        ///Obtener el Hotel Existente
        /// </summary>
        Hoteles GetHotelById(Guid id);
        ///<summary>
        ///Obtener la Habitacion Existente
        /// </summary>
        Habitaciones GetRoomById(Guid id);
        ///<summary>
        ///Actualizar el hotel existente
        /// </summary>
        Hoteles UpdateHotel(Hoteles hoteles);
        ///<summary>
        ///Actualizar la habitacion existente
        /// </summary>
        Habitaciones UpdateRoom(Habitaciones habitaciones);
    }
}
