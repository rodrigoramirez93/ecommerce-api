using AutoMapper;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<ReadRoleDto, Role>().ReverseMap();
            CreateMap<CreateRoleDto, Role>();
        }
    }
}
