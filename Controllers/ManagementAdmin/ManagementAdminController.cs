using BackSmartTalent.Application.Services.Interfaces.ManagementAdmin;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Controllers.ManagementAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementAdminController : Controller
    {
        private readonly IManagementAdminAppServices _ManagementAdminAppServices;

        public ManagementAdminController(IManagementAdminAppServices managementAdminAppServices)
        {
            _ManagementAdminAppServices = managementAdminAppServices;
        }

        ///<summary>
        ///Traer reservas
        ///</summary>
        [HttpGet]
        [Route(nameof(ManagementAdminController.GetBooking))]
        public ResultResponse<List<ReservasDTO>> GetBooking() => _ManagementAdminAppServices.GetBooking();


        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        [HttpPost]
        [Route(nameof(ManagementAdminController.InsertHotel))]
        public ResultResponse<Hoteles> InsertHotel(HotelesDTO hotel) => _ManagementAdminAppServices.InsertHotel(hotel);

        ///<summary>
        ///Insertar Habitaciones a Hoteles
        ///</summary>
        [HttpPost]
        [Route(nameof(ManagementAdminController.InsertRoomByHotel))]
        public ResultResponse<Habitaciones> InsertRoomByHotel(HabitacionesDTO habitaciones) => _ManagementAdminAppServices.InsertRoomByHotel(habitaciones);

        ///<summary>
        ///Actualizar el hotel existente
        ///</summary>
        [HttpPut]
        [Route(nameof(ManagementAdminController.UpdateHotel))]
        public ResultResponse<Hoteles> UpdateHotel(HotelesUpdateDTO hotel) => _ManagementAdminAppServices.UpdateHotel(hotel);

        ///<summary>
        ///Actualizar la habitacion existente
        ///</summary>
        [HttpPut]
        [Route(nameof(ManagementAdminController.UpdateRoom))]
        public ResultResponse<Habitaciones> UpdateRoom(HabitacionesUpdateDTO habitaciones) => _ManagementAdminAppServices.UpdateRoom(habitaciones);
    }
}
