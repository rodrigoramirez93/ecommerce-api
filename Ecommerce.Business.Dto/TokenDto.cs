using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class TokenDto
    {
        public TokenDto(string idToken, DateTime expirationDate)
        {
            IdToken = idToken;
            ExpirationDate = expirationDate;
        }
        public string IdToken { get; }
        public DateTime ExpirationDate { get; }
    }
}
