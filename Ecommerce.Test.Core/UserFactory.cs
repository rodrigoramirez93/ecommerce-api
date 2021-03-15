using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;
using System.Collections.Generic;

namespace Ecommerce.Test.Core
{
    public class UserFactory : EntityAbstractFactory<User, UserType>
    {
        private User CreateValidUser()
        {
            return new User();
        }

        private User CreateInvalidUser()
        {
            return new User();
        }

        public override User CreateInstance(UserType options)
        {
            User user = null;

            switch (options)
            {
                case UserType.Valid:
                    user = CreateValidUser();
                    break;
                case UserType.Invalid:
                    user = CreateInvalidUser();
                    break;

            };

            return user;
        }
    }
}
