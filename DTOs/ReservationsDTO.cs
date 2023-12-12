using BackSmartTalent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class ReservationsDTO
    {
        public string NamesHotelsDTO { get; set; }
        public string AddressHotelsDTO { get; set; }
        public string TypeRoomDTO { get; set; }
        public decimal CostBaseDTO { get; set; }
        public decimal TaxesDTO { get; set; }
        public string LocationRoomDTO { get; set; }
        public DateTime EntryDateDTO { get; set; }
        public DateTime DepartureDateDTO { get; set; }
        public int NumberPeopleDTO { get; set; }
        public string CityDestinationDTO { get; set; }
        public bool EnabledDTO { get; set; }
    }

    public class InsertBookingDTO
    {
        public Guid IdRoomDTO { get; set; }
        public GuestsDTO GuestsDTO { get; set; }
        public DateTime EntryDateDTO { get; set; }
        public DateTime DepartureDateDTO { get; set; }
        public int NumberPeopleDTO { get; set; }
        public string CityDestinationDTO { get; set; }
        public bool EnabledDTO { get; set; }
    }
}
