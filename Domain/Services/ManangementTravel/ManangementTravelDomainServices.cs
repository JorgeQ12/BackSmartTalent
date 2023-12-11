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
        public List<HotelesByCondition> GetHotelByCondition(DateTime fechaEntrada, DateTime fechaSalida, int CantidadPersonas, string ciudad)
        {
            try
            {
                return _context.Hoteles
                            .Include(x => x.Habitaciones)
                                .ThenInclude(y => y.ReservasNavigation)
                            .Where(hotel => hotel.Habitaciones.All(habitacion =>
                                habitacion.ReservasNavigation.FechaSalida < fechaEntrada ||
                                habitacion.ReservasNavigation.FechaEntrada > fechaSalida) &&
                                hotel.Habitaciones.Any(habitacion =>
                                habitacion.CantidadPersonas.Equals(CantidadPersonas)))
                            .Where(x => x.Cuidad.Equals(ciudad))
                            .Select(x => new HotelesByCondition
                            {
                                NombreHotelDTO = x.Nombre.ToString(),
                                DireccionHotelDTO = x.Direccion.ToString(),
                                TipoHabitacionDTO = x.Habitaciones.FirstOrDefault().TipoHabitacion.ToString(),
                                CostoBaseDTO = x.Habitaciones.FirstOrDefault().CostoBase,
                                ImpuestosDTO = x.Habitaciones.FirstOrDefault().Impuestos,
                                CantidadPersonasDTO = x.Habitaciones.FirstOrDefault().CantidadPersonas,
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
        /// <param name="huespedes"></param>
        /// <returns></returns>
        public Guid InsertHuesped(Huespedes huespedes)
        {
            try
            {
                _context.Add(huespedes);
                return huespedes.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Insertar Reserva
        /// </summary>
        /// <param name="reservas"></param>
        /// <param name="IdHuesped"></param>
        /// <returns></returns>
        public Reservas InsertBooking(Reservas reservas, Guid IdHuesped)
        {
            try
            {
                reservas.IdHuespedes = IdHuesped;
                _context.Add(reservas);
                _context.SaveChanges();
                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
