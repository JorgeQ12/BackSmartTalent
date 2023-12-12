using BackSmartTalent.Application.Services.Interfaces.ManagementAdmin;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Application.Services.ManagementAdmin
{
    public class ManagementAdminDomainServices : IManagementAdminDomainServices
    {
        private readonly DbContextSmartTalent _context;
        public ManagementAdminDomainServices(DbContextSmartTalent context)
        {
            _context = context;
        }

        ///<summary>
        ///Traer reservas
        ///</summary>
        public List<ReservationsDTO> GetBooking()
        {
            try
            {
                return _context.Reservations
                        .Include(x => x.Rooms)
                            .ThenInclude(y => y.HotelsNavigation)
                        .Where(x => x.Enabled)
                        .Select(x => new ReservationsDTO
                        {
                            NamesHotelsDTO = x.Rooms.HotelsNavigation.Names.ToString(),
                            AddressHotelsDTO = x.Rooms.HotelsNavigation.Address.ToString(),
                            TypeRoomDTO = x.Rooms.TypeRoom.ToString(),
                            CostBaseDTO = x.Rooms.CostBase,
                            TaxesDTO = x.Rooms.Taxes,
                            LocationRoomDTO = x.Rooms.Location.ToString(),
                            EntryDateDTO = x.EntryDate,
                            DepartureDateDTO = x.DepartureDate,
                            NumberPeopleDTO = x.NumberPeople,
                            CityDestinationDTO = x.CityDestination.ToString(),
                            EnabledDTO = x.Enabled
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Hoteles
        ///</summary>
        public Hotels InsertHotel(Hotels hotels)
        {
            try
            {
                _context.Add(hotels);
                _context.SaveChanges();
                return hotels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Rooms a Hoteles
        ///</summary>
        public Rooms InsertRoomByHotel(Rooms rooms)
        {
            try
            {
                _context.Add(rooms);
                _context.SaveChanges();
                return rooms;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Obtener el Hotel Existente
        /// </summary>
        public Hotels GetHotelById(Guid id)
        {
            try
            {
                return _context.Hotels.Where(x => x.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Obtener la Habitacion Existente
        /// </summary>
        public Rooms GetRoomById(Guid id)
        {
            try
            {
                return _context.Rooms.Where(x => x.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar el hotel existente
        /// </summary>
        public Hotels UpdateHotel(Hotels hotels)
        {
            try
            {
                _context.Update(hotels);
                _context.SaveChanges();
                return hotels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar la habitacion existente
        /// </summary>
        public Rooms UpdateRoom(Rooms rooms)
        {
            try
            {
                _context.Update(rooms);
                _context.SaveChanges();
                return rooms;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
