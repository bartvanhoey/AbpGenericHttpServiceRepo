using System.Text.Json;
using static System.ArgumentNullException;
using static System.Text.Json.JsonSerializer;

namespace BookStoreAbpConsole.Functional;

public static class ObjectExtensions
{
    public static string ToJson(this object objectToSerialize)
    {
        ThrowIfNull(objectToSerialize);
        return Serialize(objectToSerialize, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

}