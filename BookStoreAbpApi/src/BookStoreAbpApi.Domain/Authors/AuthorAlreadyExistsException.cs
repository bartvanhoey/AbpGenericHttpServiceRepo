using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;

namespace BookStoreAbpApi.Authors
{
 
    public class AuthorAlreadyExistsException  : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(BookStoreAbpApiDomainErrorCodes.AuthorAlreadyExist)
        {
            WithData("name", name);
        }
    }


}