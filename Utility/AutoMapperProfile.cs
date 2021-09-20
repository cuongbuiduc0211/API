
using AutoMapper;
using DatabaseAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Models;

namespace Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserAccount, User>();
            CreateMap<AdminAccount, User>();
            CreateMap<SelfProfile, User>();
            CreateMap<ChangePassword, User>();
            CreateMap<BrandItem, Brand>();
            CreateMap<CarItem, Car>();
            CreateMap<AccessoryItem, Accessory>();
            CreateMap<EventItem, Event>();
        }
        
    }
}
