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
        public ResultResponse<List<ReservationsDTO>> GetBooking()
        {
            try
            {
                List<ReservationsDTO> reservations = _IManagementAdminDomainServices.GetBooking();
                if(reservations.Count() > 0)
                {
                    return new ResultResponse<List<ReservationsDTO>>(true, reservations);
                }
                return new ResultResponse<List<ReservationsDTO>>(true, GlobalResponses.NoBooking);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        public ResultResponse<Hotels> InsertHotel(HotelsDTO hotels)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHotel(hotels);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                _IManagementAdminDomainServices.InsertHotel(_mapper.Map<HotelsDTO, Hotels>(hotels));

                return new ResultResponse<Hotels>(true, GlobalResponses.HotelCreadoCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<Rooms> InsertRoomByHotel(RoomsDTO rooms)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHabitacion(rooms);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                _IManagementAdminDomainServices.InsertRoomByHotel(_mapper.Map<RoomsDTO, Rooms>(rooms));

                return new ResultResponse<Rooms>(true, GlobalResponses.HabitacionCreadoCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<Hotels> UpdateHotel(HotelsUpdateDTO hotels)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHotelUpdate(hotels);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                //Obtenemos el Hotel
                var hotelExist = _IManagementAdminDomainServices.GetHotelById(hotels.IdHotelsDTO);
                if (hotelExist == null)
                {
                    return new ResultResponse<Hotels>(false, GlobalResponses.NoFoundHotel);
                }

                _IManagementAdminDomainServices.UpdateHotel(_mapper.Map(hotels, hotelExist));

                return new ResultResponse<Hotels>(true, GlobalResponses.HotelActualizadoCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<Rooms> UpdateRoom(RoomsUpdateDTO rooms)
        {
            try
            {
                //Validaciones
                var validacionResult = _globalValidator.ValidarHabitacionUpdate(rooms);
                if (validacionResult != null)
                {
                    return validacionResult;
                }

                //Obtenemos la habitacion
                var roomsExist = _IManagementAdminDomainServices.GetRoomById(rooms.IdRoomDTO);
                if(roomsExist == null)
                {
                    return new ResultResponse<Rooms>(false, GlobalResponses.NoFoundRoom);
                }

                _IManagementAdminDomainServices.UpdateRoom(_mapper.Map(rooms, roomsExist));

                return new ResultResponse<Rooms>(true, GlobalResponses.HabitacionActualizadaCorrectamente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
