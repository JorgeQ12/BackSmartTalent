using AutoMapper;
using BackSmartTalent.Application.Services.Interfaces.ManagementAdmin;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using BackSmartTalent.Resources;
using BackSmartTalent.Validators;
using BackSmartTalent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.ManagementAdmin
{
    public class ManagementAdminAppServices : IManagementAdminAppServices
    {
        private readonly IMapper _mapper;
        private readonly IManagementAdminDomainServices _IManagementAdminDomainServices;
        private readonly GlobalValidator _globalValidator;

        public ManagementAdminAppServices(IManagementAdminDomainServices managementAdminDomainServices, IMapper mapper, GlobalValidator globalValidator)
        {
            _mapper = mapper;
            _IManagementAdminDomainServices = managementAdminDomainServices;
            _globalValidator = globalValidator;
        }

        ///<summary>
        ///Traer reservas
        ///</summary>
        public ResultResponse<List<ReservasDTO>> GetBooking()
        {
            try
            {
                List<ReservasDTO> reservas = _IManagementAdminDomainServices.GetBooking();
                if(reservas.Count() > 0)
                {
                    return new ResultResponse<List<ReservasDTO>>(true, reservas);
                }
                return new ResultResponse<List<ReservasDTO>>(true, RespuestasGlobales.NoBooking);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        public ResultResponse<Hoteles> InsertHotel(HotelesDTO hoteles)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHotel(hoteles);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                _IManagementAdminDomainServices.InsertHotel(_mapper.Map<HotelesDTO, Hoteles>(hoteles));

                return new ResultResponse<Hoteles>(true, RespuestasGlobales.HotelCreadoCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<Habitaciones> InsertRoomByHotel(HabitacionesDTO habitaciones)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHabitacion(habitaciones);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                _IManagementAdminDomainServices.InsertRoomByHotel(_mapper.Map<HabitacionesDTO, Habitaciones>(habitaciones));

                return new ResultResponse<Habitaciones>(true, RespuestasGlobales.HabitacionCreadoCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<Hoteles> UpdateHotel(HotelesUpdateDTO hoteles)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHotelUpdate(hoteles);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                //Obtenemos el Hotel
                var hotelExistente = _IManagementAdminDomainServices.GetHotelById(hoteles.IdHotelDTO);
                if (hotelExistente == null)
                {
                    return new ResultResponse<Hoteles>(false, RespuestasGlobales.NoFoundHotel);
                }

                _IManagementAdminDomainServices.UpdateHotel(_mapper.Map(hoteles, hotelExistente));

                return new ResultResponse<Hoteles>(true, RespuestasGlobales.HotelActualizadoCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<Habitaciones> UpdateRoom(HabitacionesUpdateDTO habitaciones)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHabitacionUpdate(habitaciones);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                //Obtenemos la habitacion
                var habitacionExistente = _IManagementAdminDomainServices.GetRoomById(habitaciones.IdHabitacionDTO);
                if(habitacionExistente == null)
                {
                    return new ResultResponse<Habitaciones>(false, RespuestasGlobales.NoFoundRoom);
                }

                _IManagementAdminDomainServices.UpdateRoom(_mapper.Map(habitaciones, habitacionExistente));

                return new ResultResponse<Habitaciones>(true, RespuestasGlobales.HabitacionActualizadaCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
