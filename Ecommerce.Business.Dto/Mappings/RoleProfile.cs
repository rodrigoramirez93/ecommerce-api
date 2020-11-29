using AutoMapper;
using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>().ReverseMap();
        }
    }
}
