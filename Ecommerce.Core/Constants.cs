using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecommerce.Core
{
    public static class Constants
    {
        public static class Encoding
        {
            public static string ISO_8859_8 = "ISO-8859-8";
        }

        public static class Claim
        {
            public static string Tenant = "Tenant";
        }

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

