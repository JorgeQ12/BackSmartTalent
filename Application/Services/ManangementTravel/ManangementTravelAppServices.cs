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
        public ResultResponse<List<HotelesByCondition>> GetHotelByCondition(DateTime fechaEntrada, DateTime fechaSalida, int CantidadPersonas, string ciudad)
        {
            try
            {
                var validacionResult = _globalValidator.ValidateHotelByCondition(fechaEntrada, fechaSalida, CantidadPersonas, ciudad);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                List<HotelesByCondition> hotelesFind = _IManangementTravelDomainServices.GetHotelByCondition(fechaEntrada, fechaSalida, CantidadPersonas, ciudad);
                if(hotelesFind.Count() > 0)
                {
                    return new ResultResponse<List<HotelesByCondition>>(true, hotelesFind);
                }

                return new ResultResponse<List<HotelesByCondition>>(true, RespuestasGlobales.NoHotelByCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        ///<summary>
        ///Insertar Reserva 
        ///</summary>
        public ResultResponse<Reservas> InsertBooking(InsertBookingDTO insertBooking)
        {
            try
            {
                var validacionResult = _globalValidator.ValidateBooking(insertBooking);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                //Insertamos Huesped y devolvemos el ID para la relacion.
                Guid idHuesped = _IManangementTravelDomainServices.InsertHuesped(_mapper.Map<HuespedesDTO, Huespedes>(insertBooking.HuespedesDTO));

                _IManangementTravelDomainServices.InsertBooking(_mapper.Map<InsertBookingDTO, Reservas>(insertBooking), idHuesped);

                //Enviar correo de confirmacion
                _sendEmail.Main(insertBooking);

                return new ResultResponse<Reservas>(true, RespuestasGlobales.ReservaInsertada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
