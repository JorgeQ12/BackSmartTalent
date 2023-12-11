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
        public List<ReservasDTO> GetBooking()
        {
            try
            {
                return _context.Reservas
                        .Include(x => x.Habitaciones)
                            .ThenInclude(y => y.HotelesNavigation)
                        .Where(x => x.Activo)
                        .Select(x => new ReservasDTO
                        {
                            NombreHotelDTO = x.Habitaciones.HotelesNavigation.Nombre.ToString(),
                            DireccionHotelDTO = x.Habitaciones.HotelesNavigation.Direccion.ToString(),
                            TipoHabitacionDTO = x.Habitaciones.TipoHabitacion.ToString(),
                            CostoBaseDTO = x.Habitaciones.CostoBase,
                            ImpuestosDTO = x.Habitaciones.Impuestos,
                            UbicacionHabitacionDTO = x.Habitaciones.Ubicacion.ToString(),
                            FechaEntradaDTO = x.FechaEntrada,
                            FechaSalidaDTO = x.FechaSalida,
                            CantidadPersonasDTO = x.CantidadPersonas,
                            CiudadDestinoDTO = x.CiudadDestino.ToString(),
                            ActivoDTO = x.Activo
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
        public Hoteles InsertHotel(Hoteles hotel)
        {
            try
            {
                _context.Add(hotel);
                _context.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Habitaciones a Hoteles
        ///</summary>
        public Habitaciones InsertRoomByHotel(Habitaciones habitaciones)
        {
            try
            {
                _context.Add(habitaciones);
                _context.SaveChanges();
                return habitaciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Obtener el Hotel Existente
        /// </summary>
        public Hoteles GetHotelById(Guid id)
        {
            try
            {
                return _context.Hoteles.Where(x => x.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Obtener la Habitacion Existente
        /// </summary>
        public Habitaciones GetRoomById(Guid id)
        {
            try
            {
                return _context.Habitaciones.Where(x => x.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar el hotel existente
        /// </summary>
        public Hoteles UpdateHotel(Hoteles hoteles)
        {
            try
            {
                _context.Update(hoteles);
                _context.SaveChanges();
                return hoteles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar la habitacion existente
        /// </summary>
        public Habitaciones UpdateRoom(Habitaciones habitaciones)
        {
            try
            {
                _context.Update(habitaciones);
                _context.SaveChanges();
                return habitaciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
