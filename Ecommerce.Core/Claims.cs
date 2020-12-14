using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class Claims
    {
        //product
        public const string CAN_CREATE_PRODUCT = "CAN_CREATE_PRODUCT";
        public const string CAN_READ_PRODUCT = "CAN_READ_PRODUCT";
        public const string CAN_UPDATE_PRODUCT = "CAN_UPDATE_PRODUCT";
        public const string CAN_DELETE_PRODUCT = "CAN_DELETE_PRODUCT";

        //role
        public const string CAN_CREATE_ROLE = "CAN_CREATE_ROLE";
        public const string CAN_READ_ROLE = "CAN_READ_ROLE";
        public const string CAN_READ_CLAIMS = "CAN_READ_CLAIMS";
        public const string CAN_UPDATE_ROLE = "CAN_UPDATE_ROLE";
        public const string CAN_DELETE_ROLE = "CAN_DELETE_ROLE";
        public const string CAN_ADD_CLAIM_TO_ROLE = "CAN_ADD_CLAIM_TO_ROLE";
        public const string CAN_REMOVE_CLAIM_TO_ROLE = "CAN_REMOVE_CLAIM_TO_ROLE";

    }
}
