using System.Globalization;
using static System.ArgumentNullException;
using DeviceType = Microsoft.Maui.Devices.DeviceType;

namespace BookStoreMaui.Services.SecureStorage;

public class SecureStorageServiceBase
{
    protected async Task SaveBoolean(string key, bool value) => await SetAsync(key, value.ToString());

    protected async Task<bool> GetBoolean(string key, bool defaultValue) =>
        Convert.ToBoolean(await GetAsync(key, defaultValue.ToString()));

    protected async Task SaveDouble(string key, double value) =>
        await SetAsync(key, value.ToString(CultureInfo.InvariantCulture));

    protected async Task<double> GetDouble(string key, double defaultValue) =>
        Convert.ToDouble(await GetAsync(key, defaultValue.ToString(CultureInfo.InvariantCulture)));

    protected async Task SaveInteger(string key, int value) => await SetAsync(key, value.ToString());

    protected async Task<int> GetInteger(string key, int defaultValue) =>
        Convert.ToInt32(await GetAsync(key, defaultValue.ToString()));

    protected async Task SaveLong(string key, long value) => await SetAsync(key, value.ToString());

    private async Task<long> GetLong(string key, long defaultValue) =>
        Convert.ToInt64(await GetAsync(key, defaultValue.ToString()));

    protected async Task SaveDateTime(string key, DateTime value) =>
        await SetAsync(key, value.ToString(CultureInfo.InvariantCulture));

    protected async Task<DateTime> GetDateTime(string key, DateTime defaultValue) =>
        Convert.ToDateTime(await GetAsync(key, defaultValue.ToString(CultureInfo.InvariantCulture)));

    protected static async Task SaveString(string key, string value) => await SetAsync(key, value);
    protected static async Task<string> GetString(string key, string defaultValue) => await GetAsync(key, defaultValue);

    private static async Task<string> GetAsync(string key, string defaultValue)
    {
        try
        {
            if (DeviceInfo.DeviceType == DeviceType.Physical)
                defaultValue = await Microsoft.Maui.Storage.SecureStorage.GetAsync(key) ?? defaultValue;
            else
            {
                try
                {
                    var hasKey = Preferences.Default.ContainsKey(key);
                    if (hasKey)
                    {
                        var value = Preferences.Default.Get(key, defaultValue);
                        return value ?? defaultValue;
                    }
                }
                catch (Exception exception)
                {
                }
            }
        }
        catch (Exception exception)
        {
        }

        return defaultValue;
    }


    private static async Task SetAsync(string key, string value)
    {
        try
        {
            ThrowIfNull(key);
            ThrowIfNull(value);
            if (DeviceInfo.DeviceType == DeviceType.Physical)
                await Microsoft.Maui.Storage.SecureStorage.SetAsync(key, value);
            else
                Preferences.Default.Set(key, value);
        }
        catch (Exception exception)
        {
        }
    }

    public async Task ClearAsync(string key)
    {
        try
        {
            if (DeviceInfo.DeviceType == DeviceType.Physical)
                await Microsoft.Maui.Storage.SecureStorage.SetAsync(key, "");
            else
            {
                try
                {
                    var hasKey = Preferences.Default.ContainsKey(key);
                    if (hasKey)
                    {
                        Preferences.Default.Remove(key);
                    }
                }
                catch (Exception exception)
                {
                }
            }
        }
        catch (Exception exception)
        {
        }
    }
}