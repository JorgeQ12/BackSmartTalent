using BackSmartTalent.Application.Services.Interfaces.ManangementTravel;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Controllers.ManangementTravel
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManangementTravelController : Controller
    {
        private readonly IManangementTravelAppServices _ManangementTravelAppServices;

        public ManangementTravelController(IManangementTravelAppServices manangementTravelAppServices)
        {
            _ManangementTravelAppServices = manangementTravelAppServices;
        }

        ///<summary>
        ///Traer reservas
        ///</summary>
        [HttpGet]
        [Route(nameof(ManangementTravelController.GetHotelByCondition))]
        public ResultResponse<List<HotelsByCondition>> GetHotelByCondition(DateTime entryDate, DateTime departureDate, int numberPeople, string city) => _ManangementTravelAppServices.GetHotelByCondition(entryDate, departureDate, numberPeople, city);

        ///<summary>
        ///Insertar Reserva 
        ///</summary>
        [HttpPost]
        [Route(nameof(ManangementTravelController.InsertBooking))]
        public ResultResponse<Reservations> InsertBooking(InsertBookingDTO insertBooking) => _ManangementTravelAppServices.InsertBooking(insertBooking);
    }
}
