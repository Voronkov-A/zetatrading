using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ZetaTrading.Adapters.Database.Common.Converters;

public class JsonValueConverter<TModel> : ValueConverter<TModel, string>
{
    public JsonValueConverter()
        : base(
            domain => JsonSerializer.Serialize(domain, JsonSerializerOptions.Default),
            persistence => JsonSerializer.Deserialize<TModel>(persistence, JsonSerializerOptions.Default)!)
    {
    }
}
