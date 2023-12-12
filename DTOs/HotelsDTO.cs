using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class HotelsDTO
    {
        public string NamesDTO { get; set; }
        public string AddressDTO { get; set; }
        public string CityDTO { get; set; }

    }

    public class HotelsUpdateDTO
    {
        public Guid IdHotelsDTO { get; set; }
        public string NamesDTO { get; set; }
        public string AddressDTO { get; set; }
        public string CityDTO { get; set; }
        public bool EnabledDTO { get; set; }
    }

    public class HotelsByCondition
    {
        public string NamesHotelsDTO { get; set; }
        public string AddressHotelsDTO { get; set; }
        public string TypeRoomDTO { get; set; }
        public decimal CostBaseDTO { get; set; }
        public decimal TaxesDTO { get; set; }
        public int NumberPeopleDTO { get; set; }

    }
}
