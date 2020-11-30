using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Identity;
using System.Collections.Generic;

namespace Ecommerce.Test.Core
{
    public class UserFactory : EntityAbstractFactory<User, UserType>
    {
        private User CreateBaseUser()
        {
            return new User();
        }

        public override User CreateInstance(UserType options)
        {
            var baseUser = CreateBaseUser();

            return options switch
            {
                UserType.Valid => baseUser,
                //...some other possibilities
                _ => baseUser
            };
        }
    }
}
