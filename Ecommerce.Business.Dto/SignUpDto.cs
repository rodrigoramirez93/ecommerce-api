﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class SignUpDto
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}