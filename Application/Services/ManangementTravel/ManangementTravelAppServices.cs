using AutoMapper;
using BackSmartTalent.Application.Services.Interfaces.ManangementTravel;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.Domain.Services.Interfaces.ManangementTravel;
using BackSmartTalent.DTOs;
using BackSmartTalent.Resources;
using BackSmartTalent.Utilities;
using BackSmartTalent.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.ManangementTravel
{
    public class ManangementTravelAppServices : IManangementTravelAppServices
    {
        private readonly IManangementTravelDomainServices _IManangementTravelDomainServices;
        private readonly IMapper _mapper;
        private readonly GlobalValidator _globalValidator;
        private readonly SendEmail _sendEmail;

        public ManangementTravelAppServices(IManangementTravelDomainServices manangementTravelDomainServices, GlobalValidator globalValidator, IMapper mapper, SendEmail sendEmail)
        {
            _mapper = mapper;
            _IManangementTravelDomainServices = manangementTravelDomainServices;
            _globalValidator = globalValidator;
            _sendEmail = sendEmail;
        }
        ///<summary>
        ///Traer reservas
        ///</summary>
        public ResultResponse<List<HotelsByCondition>> GetHotelByCondition(DateTime entryDate, DateTime departureDate, int numberPeople, string city)
        {
            try
            {
                var validacionResult = _globalValidator.ValidateHotelByCondition(entryDate, departureDate, numberPeople, city);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                List<HotelsByCondition> hotelesFind = _IManangementTravelDomainServices.GetHotelByCondition(entryDate, departureDate, numberPeople, city);
                if(hotelesFind.Count() > 0)
                {
                    return new ResultResponse<List<HotelsByCondition>>(true, hotelesFind);
                }

                return new ResultResponse<List<HotelsByCondition>>(true, GlobalResponses.NoHotelByCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        ///<summary>
        ///Insertar Reserva 
        ///</summary>
        public ResultResponse<Reservations> InsertBooking(InsertBookingDTO insertBooking)
        {
            try
            {
                var validacionResult = _globalValidator.ValidateBooking(insertBooking);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                //Insertamos Huesped y devolvemos el ID para la relacion.
                Guid idGuest = _IManangementTravelDomainServices.InsertHuesped(_mapper.Map<GuestsDTO, Guests>(insertBooking.GuestsDTO));

                _IManangementTravelDomainServices.InsertBooking(_mapper.Map<InsertBookingDTO, Reservations>(insertBooking), idGuest);

                //Enviar correo de confirmacion
                _sendEmail.Main(insertBooking);

                return new ResultResponse<Reservations>(true, GlobalResponses.ReservaInsertada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
