using AutoMapper;
using Reservations.Backend.DataEntity.EFModels;
using Reservations.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.backend.Data.Mappings
{
    public class ReservationsMappings : Profile
    {
        public ReservationsMappings()
        { 
            CreateMap<rest_shift, Shift>()
                .ForMember(x => x.Day, y => y.MapFrom(src => (DayOfWeek)src.DayOfWeek))
                .ReverseMap();
            CreateMap<rest_table, RestaurantTable>().ReverseMap();
            CreateMap<rest_reservation, Reservation>().ReverseMap();
            CreateMap<rest_reservation, rest_reservation>();
        }
    }
}
