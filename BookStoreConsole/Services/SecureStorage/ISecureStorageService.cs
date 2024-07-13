using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreConsole.Services.SecureStorage
{
    public interface ISecureStorageService
    {
        Task SetAccessTokenAsync(string accessToken);
         Task<string> GetAccessTokenAsync();
    }
}