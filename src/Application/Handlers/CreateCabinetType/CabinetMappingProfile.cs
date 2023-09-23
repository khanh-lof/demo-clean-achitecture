using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CabinetManagement.Application.IO.CreateCabinetType;
using CabinetManagement.Domain.Entities;

namespace CabinetManagement.Application.Handlers.CreateCabinetType;
public class CabinetMappingProfile : Profile
{
    public CabinetMappingProfile()
    {
        CreateMap<CreateCabinetTypeCommand, CabinetType>()
            .ForMember(dest => dest.TypeName, opt=>opt.MapFrom(src=> src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => $"Type for {src.Description}"));
    }
}
