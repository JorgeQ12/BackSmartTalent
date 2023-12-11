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
        ResultResponse<List<ReservasDTO>> GetBooking();

        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        ResultResponse<Hoteles> InsertHotel(HotelesDTO hoteles);
        ///<summary>
        ///Insertar Habitaciones a Hoteles
        ///</summary>
        ResultResponse<Habitaciones> InsertRoomByHotel(HabitacionesDTO habitaciones);

        ///<summary>
        ///Actualizar el hotel existente
        /// </summary>
        ResultResponse<Hoteles> UpdateHotel(HotelesUpdateDTO hoteles);
        ///<summary>
        ///Actualizar la habitacion existente
        /// </summary>
        ResultResponse<Habitaciones> UpdateRoom(HabitacionesUpdateDTO habitaciones);
    }
}
