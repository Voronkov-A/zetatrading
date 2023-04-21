using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.Database.Common.Converters;

public class NameValueConverter : ValueConverter<Name, string>
{
    public NameValueConverter() : base(model => model.ToString(), persistence => new Name(persistence))
    {
    }
}
