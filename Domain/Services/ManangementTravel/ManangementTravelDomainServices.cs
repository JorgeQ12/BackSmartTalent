using BackSmartTalent.Domain.Entities;
using BackSmartTalent.Domain.Services.Interfaces.ManangementTravel;
using BackSmartTalent.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BackSmartTalent.Domain.Services.ManangementTravel
{
    public class ManangementTravelDomainServices : IManangementTravelDomainServices
    {
        private readonly DbContextSmartTalent _context;
        public ManangementTravelDomainServices(DbContextSmartTalent context)
        {
            _context = context;
        }

        ///<summary>
        ///Traer reservas
        ///</summary>
        public List<HotelsByCondition> GetHotelByCondition(DateTime entryDate, DateTime departureDate, int numberPeople, string city)
        {
            try
            {
                return _context.Hotels
                            .Include(x => x.Rooms)
                                .ThenInclude(y => y.ReservationsNavigation)
                            .Where(x => x.Rooms.All(y => y.ReservationsNavigation.DepartureDate < entryDate || y.ReservationsNavigation.EntryDate > departureDate) 
                                        && x.Rooms.Any(z => z.NumberPeople.Equals(numberPeople)))
                            .Where(x => x.City.Equals(city))
                            .Select(x => new HotelsByCondition
                            {
                                NamesHotelsDTO = x.Names.ToString(),
                                AddressHotelsDTO = x.Address.ToString(),
                                TypeRoomDTO = x.Rooms.FirstOrDefault().TypeRoom.ToString(),
                                CostBaseDTO = x.Rooms.FirstOrDefault().CostBase,
                                TaxesDTO = x.Rooms.FirstOrDefault().Taxes,
                                NumberPeopleDTO = x.Rooms.FirstOrDefault().NumberPeople,
                            })
                            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Insertar Huesped
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        public Guid InsertHuesped(Guests guests)
        {
            try
            {
                _context.Add(guests);
                return guests.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Insertar Reserva
        /// </summary>
        /// <param name="reservations"></param>
        /// <param name="IdGuests"></param>
        /// <returns></returns>
        public Reservations InsertBooking(Reservations reservations, Guid IdGuests)
        {
            try
            {
                reservations.IdGuests = IdGuests;
                _context.Add(reservations);
                _context.SaveChanges();
                return reservations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
