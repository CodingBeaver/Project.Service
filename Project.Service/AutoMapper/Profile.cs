using AutoMapper;
using Project.Service.Controllers;
using Project.Service.Entity;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Service.AutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<TempMake, IVehicleMake>().ReverseMap();
            CreateMap<TempModel, IVehicleModel>().ReverseMap();
        }
    }
}