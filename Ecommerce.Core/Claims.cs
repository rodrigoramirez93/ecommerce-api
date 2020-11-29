using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class Claims
    {
        public const string CAN_CREATE_PRODUCT = "CAN_CREATE_PRODUCT";
        public const string CAN_READ_PRODUCT = "CAN_READ_PRODUCT";
        public const string CAN_UPDATE_PRODUCT = "CAN_UPDATE_PRODUCT";
        public const string CAN_DELETE_PRODUCT = "CAN_DELETE_PRODUCT";
    }
}
