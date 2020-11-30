using AutoMapper;
using Ecommerce.Domain.Model.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Business.Dto.Mappings
{
    public class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            CreateMap<AccessDto, Claim>()
                .ForMember(x => x.Type, y => y.MapFrom(map => map.Name))
                .ForMember(x => x.Value, y => y.MapFrom(map => map.Value))
                .ReverseMap();

            CreateMap<RoleClaim, AccessDto>();
        }
    }
}
