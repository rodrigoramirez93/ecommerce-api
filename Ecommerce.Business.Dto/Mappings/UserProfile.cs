using AutoMapper;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));

            CreateMap<User, UserDto>();
        }
    }
}
