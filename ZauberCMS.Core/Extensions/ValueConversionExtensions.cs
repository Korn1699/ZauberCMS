using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ZauberCMS.Core.Extensions;

public static class ValueConversionExtensions
{
    public static void ToJsonConversion<T>(this PropertyBuilder<T> propertyBuilder, int? columnSize)
        where T : class, new()
    {
        // Explicitly set JsonSerializerOptions to prevent indentation
        var options = new JsonSerializerOptions
        {
            WriteIndented = false
        };

        var converter = new ValueConverter<T, string>
        (
            v => JsonSerializer.Serialize(v, options), // Serialize in the most compact form
            v => JsonSerializer.Deserialize<T>(v, options) ?? new T()
        );

        var comparer = new ValueComparer<T>
        (
            (l, r) => JsonSerializer.Serialize(l, options) == JsonSerializer.Serialize(r, options),
            v => v == null ? 0 : JsonSerializer.Serialize(v, options).GetHashCode(),
            v => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(v, options), options)!
        );

        propertyBuilder.HasConversion(converter);
        propertyBuilder.Metadata.SetValueConverter(converter);
        propertyBuilder.Metadata.SetValueComparer(comparer);

        if (columnSize != null)
        {
            propertyBuilder.HasMaxLength(columnSize.Value);
        }
    }
}