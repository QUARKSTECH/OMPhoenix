﻿using AutoMapper;
using OMPhoenix.Entity;
using OMPhoenix.ViewModel;
using System.Linq;

namespace OMPhoenix.Web.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        public DomainToViewModelMappingProfile()
        {
            Configure();
        }

        private void Configure()
        {
            //Mapper.CreateMap<Prospect, ProspectViewModel>()
            //    .ForMember(vm => vm.ID, map => map.MapFrom(m => m.Tract.ID)) //For Reference

            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerViewModel, Customer>().ReverseMap();

            CreateMap<MachineViewModel, Machine>();
            CreateMap<MachineViewModel, Machine>().ReverseMap();

        }
    }
}