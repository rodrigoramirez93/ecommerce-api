using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Dto
{
    public class SearchUserDto
    {
        public SearchUserDto(string id = "", string firstname = "", string lastname = "")
        {
            bool canParseId = int.TryParse(id, out int _id);

            Id = string.IsNullOrWhiteSpace(id) ?
                0 : canParseId ?
                    _id : 0;
            
            FirstName = firstname ?? "";
            LastName = lastname ?? "";
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
