using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class RoomsDTO
    {
        public Guid IdHotelsDTO { get; set; }
        public string TypeRoomDTO { get; set; }
        public decimal CostBaseDTO { get; set; }
        public decimal TaxesDTO { get; set; }
        public int NumberPeopleDTO { get; set; }
        public string LocationDTO { get; set; }
    }

    public class RoomsUpdateDTO
    {
        public Guid IdRoomDTO { get; set; }
        public Guid IdHotelsDTO { get; set; }
        public string TypeRoomDTO { get; set; }
        public decimal CostBaseDTO { get; set; }
        public decimal TaxesDTO { get; set; }
        public int NumberPeopleDTO { get; set; }
        public string LocationDTO { get; set; }
        public bool EnabledDTO { get; set; }

    }
}
