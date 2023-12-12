using AutoMapper;
using BackSmartTalent.Domain.Entities;
using BackSmartTalent.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Automapper
{
    public class GlobalMapper : Profile
    {
        public GlobalMapper()
        {
            CreateMap<HotelsDTO, Hotels>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.Names, opt => opt.MapFrom(source => source.NamesDTO))
                .ForMember(target => target.Address, opt => opt.MapFrom(source => source.AddressDTO))
                .ForMember(target => target.City, opt => opt.MapFrom(source => source.CityDTO))
                .ForMember(target => target.Enabled, opt => opt.MapFrom(source => true));

            CreateMap<RoomsDTO, Rooms>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.IdHotels, opt => opt.MapFrom(source => source.IdHotelsDTO))
                .ForMember(target => target.TypeRoom, opt => opt.MapFrom(source => source.TypeRoomDTO))
                .ForMember(target => target.CostBase, opt => opt.MapFrom(source => source.CostBaseDTO))
                .ForMember(target => target.Taxes, opt => opt.MapFrom(source => source.TaxesDTO))
                .ForMember(target => target.NumberPeople, opt => opt.MapFrom(source => source.NumberPeopleDTO))
                .ForMember(target => target.Location, opt => opt.MapFrom(source => source.LocationDTO))
                .ForMember(target => target.Enabled, opt => opt.MapFrom(source => true));

            CreateMap<HotelsUpdateDTO, Hotels>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.IdHotelsDTO))
                .ForMember(target => target.Names, opt => opt.MapFrom(source => source.NamesDTO))
                .ForMember(target => target.Address, opt => opt.MapFrom(source => source.AddressDTO))
                .ForMember(target => target.City, opt => opt.MapFrom(source => source.CityDTO))
                .ForMember(target => target.Enabled, opt => opt.MapFrom(source => source.EnabledDTO));

            CreateMap<RoomsUpdateDTO, Rooms>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.IdRoomDTO))
                .ForMember(target => target.IdHotels, opt => opt.MapFrom(source => source.IdHotelsDTO))
                .ForMember(target => target.TypeRoom, opt => opt.MapFrom(source => source.TypeRoomDTO))
                .ForMember(target => target.CostBase, opt => opt.MapFrom(source => source.CostBaseDTO))
                .ForMember(target => target.Taxes, opt => opt.MapFrom(source => source.TaxesDTO))
                .ForMember(target => target.NumberPeople, opt => opt.MapFrom(source => source.NumberPeopleDTO))
                .ForMember(target => target.Location, opt => opt.MapFrom(source => source.LocationDTO))
                .ForMember(target => target.Enabled, opt => opt.MapFrom(source => source.EnabledDTO));

            CreateMap<ContactEmergencyDTO, ContactEmergency>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.NameslastNames, opt => opt.MapFrom(source => source.NameslastNamesDTO))
                .ForMember(target => target.Phone, opt => opt.MapFrom(source => source.PhoneDTO));

            CreateMap<GuestsDTO, Guests>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.Names, opt => opt.MapFrom(source => source.NamesDTO))
                .ForMember(target => target.Surnames, opt => opt.MapFrom(source => source.SurnamesDTO))
                .ForMember(target => target.BirthDate, opt => opt.MapFrom(source => source.BirthDateDTO))
                .ForMember(target => target.Gender, opt => opt.MapFrom(source => source.GenderDTO))
                .ForMember(target => target.DocumentType, opt => opt.MapFrom(source => source.DocumentTypeDTO))
                .ForMember(target => target.DocumentNumber, opt => opt.MapFrom(source => source.DocumentNumberDTO))
                .ForMember(target => target.Email, opt => opt.MapFrom(source => source.EmailDTO))
                .ForMember(target => target.Phone, opt => opt.MapFrom(source => source.PhoneDTO));

            CreateMap<InsertBookingDTO, Reservations>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.IdRooms, opt => opt.MapFrom(source => source.IdRoomDTO))
                .ForMember(target => target.EntryDate, opt => opt.MapFrom(source => source.EntryDateDTO))
                .ForMember(target => target.DepartureDate, opt => opt.MapFrom(source => source.DepartureDateDTO))
                .ForMember(target => target.NumberPeople, opt => opt.MapFrom(source => source.NumberPeopleDTO))
                .ForMember(target => target.CityDestination, opt => opt.MapFrom(source => source.CityDestinationDTO))
                .ForMember(target => target.Enabled, opt => opt.MapFrom(source => source.EnabledDTO));

        }
    }
}
