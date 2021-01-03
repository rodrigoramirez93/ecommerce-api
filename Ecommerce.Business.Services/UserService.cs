﻿using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        
        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            UserManager<User> userManager
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(SignUpDto signUpDto)
        {
            var user = _mapper.Map<SignUpDto, User>(signUpDto);
            return await _userManager.CreateAsync(user, signUpDto.Password);
        }

        public async Task<List<UserDto>> GetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}