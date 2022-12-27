using AutoMapper;
using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Business.Mapping.Profiles
{
    public class BayiProfile : Profile
    {
        public BayiProfile()
        {
            CreateMap<CompanyAddDto, Company>().ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));

            CreateMap<CompanyUpdateDto, Company>().ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));

            CreateMap<Company, CompanyUpdateDto>().ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => x.IsActive));
        }
    }
}
