using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecommerce.Core
{
    public static class Constants
    {
        public enum EntityNames
        {
            Product,
            Products,
            Role,
            Roles
        }

        public enum PropertyNames
        {
            Access
        }

        public enum PropertyValues
        {
            Name
        }

        public static class Validation
        {
            public static class Max
            {
                public static int Name { get; } = 5;
                public static int Description { get; } = 20;
            }
        }
    }
}

