using System.Text.Json;

namespace BookStoreMaui.Functional;

public static class StringExtensions
{
    public static T ToType<T>(this string jsonString) where T : class =>
        jsonString switch
        {
            null => throw new ArgumentNullException($"ToType: You cannot convert a null string to a Type"),
            "[]" => default,
            _ => JsonSerializer.Deserialize<T>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
        } ?? throw new InvalidOperationException();
}