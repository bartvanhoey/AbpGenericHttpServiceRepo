using IdentityModel.OidcClient;

namespace BookStoreMaui.Services.SecureStorage
{
    public interface ISecureStorageService
    {
        Task SetAccessTokenAsync(string accessToken);
        Task SetRefreshTokenAsync(string refreshToken);
        Task SetIdentityTokenAsync(string identityToken);
        Task<string> GetIdentityTokenAsync();
        Task<string> GetAccessTokenAsync();
        Task RemoveAccessTokenAsync();
        Task RemoveRefreshTokenAsync();
        Task RemoveIdentityTokenAsync();
        Task SetOpenIddictTokensAsync(LoginResult loginResult);
        Task RemoveOpenIddictTokensAsync();
        
    }
}