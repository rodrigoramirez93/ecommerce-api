using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Ecommerce.Business.Dto
{
    public class UserDto
    {
        public UserDto(string id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }

    public class TokenDto
    {

        public TokenDto(string idToken, DateTime expirationDate, UserDto user)
        {
            IdToken = idToken;
            ExpirationDate = expirationDate;
            User = user;
        }
        public string IdToken { get; }
        public DateTime ExpirationDate { get; }
        public UserDto User { get; }
    }
}
