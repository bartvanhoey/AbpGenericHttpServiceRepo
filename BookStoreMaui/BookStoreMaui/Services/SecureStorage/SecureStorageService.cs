using IdentityModel.OidcClient;

namespace BookStoreMaui.Services.SecureStorage
{
    public class SecureStorageService : SecureStorageServiceBase, ISecureStorageService
    {
        public async Task SetAccessTokenAsync(string accessToken)
            => await SaveString("accessToken", accessToken);

        public async Task SetRefreshTokenAsync(string refreshToken)
            => await SaveString("refreshToken", refreshToken);

        public async Task SetIdentityTokenAsync(string identityToken)
            => await SaveString("identityToken", identityToken);

        public async Task<string> GetIdentityTokenAsync()
            => await GetString("identityToken", "");

        public async Task<string> GetAccessTokenAsync()
            => await GetString("accessToken", "");

        public async Task RemoveAccessTokenAsync()
            => await ClearAsync("accessToken");

        public async Task RemoveRefreshTokenAsync()
            => await ClearAsync("refreshToken");

        public async Task RemoveIdentityTokenAsync()
            => await ClearAsync("identityToken");

        public async Task SetOpenIddictTokensAsync(LoginResult loginResult)
        {
            await SetIdentityTokenAsync(loginResult.IdentityToken);
            await SetAccessTokenAsync(loginResult.AccessToken);
            await SetRefreshTokenAsync(loginResult.RefreshToken);
        }

        public async Task RemoveOpenIddictTokensAsync()
        {
            await RemoveIdentityTokenAsync();
            await RemoveAccessTokenAsync();
            await RemoveRefreshTokenAsync();
        }
    }
}