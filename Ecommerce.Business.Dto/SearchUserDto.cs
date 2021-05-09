﻿using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class SearchUserDto
    {
        public SearchUserDto(string id = "", string firstname = "", string lastname = "")
        {
            Id = (int) new NumberFormatter(id)
                        .IsNullOrWhiteSpace()
                        .CanBeParsed()
                        .GetInteger(true);

            FirstName = new StringFormatter(firstname)
                            .IsNullOrWhiteSpace()
                            .ToLower()
                            .GetString();

            LastName = new StringFormatter(lastname)
                            .IsNullOrWhiteSpace()
                            .ToLower()
                            .GetString();
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
