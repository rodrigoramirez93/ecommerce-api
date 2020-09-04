using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class TokenDtoResponse
    {
        public TokenDtoResponse(string token, HttpStatusCode statusCode)
        {
            Token = token;
            HttpStatusCode = statusCode;
        }

        public string Token { get; }
        public HttpStatusCode HttpStatusCode { get; }
    }
}
