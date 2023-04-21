using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EventId = ZetaTrading.Application.Journal.EventId;

namespace ZetaTrading.Adapters.Database.Journal.Converters;

public class EventIdValueConverter : ValueConverter<EventId, long>
{
    public EventIdValueConverter() : base(model => model.ToInt64(), persistence => new EventId(persistence))
    {
    }
}
