using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.Database.Common.Converters;

public class EntityIdValueConverter : ValueConverter<EntityId, long>
{
    public EntityIdValueConverter() : base(model => model.ToInt64(), persistence => new EntityId(persistence))
    {
    }
}
