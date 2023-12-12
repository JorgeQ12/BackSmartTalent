using BackSmartTalent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.DTOs
{
    public class GuestsDTO
    {
        public string NamesDTO { get; set; }
        public string SurnamesDTO { get; set; }
        public DateTime BirthDateDTO { get; set; }
        public string GenderDTO { get; set; }
        public string DocumentTypeDTO { get; set; }
        public string DocumentNumberDTO { get; set; }
        public string EmailDTO { get; set; }
        public string PhoneDTO { get; set; }
        public ContactEmergencyDTO ContactEmergency { get; set; }
    }
}
