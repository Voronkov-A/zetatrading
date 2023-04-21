using Microsoft.EntityFrameworkCore;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.Database.Common;

public static class EntityIdSequence
{
    public static async Task<EntityId> Next(
        DbContext context,
        string schemaName,
        string sequenceName,
        CancellationToken cancellationToken)
    {
        var value = await context.Database
            .SqlQueryRaw<long>($@"select nextval('{schemaName}.""{sequenceName}""') as ""Value""")
            .SingleAsync(cancellationToken);
        return new EntityId(value);
    }

    public static string GenerateSqlCreate(string schemaName, string sequenceName)
    {
        return $@"create sequence {schemaName}.""{sequenceName}"" start 1 cache 1;";
    }

    public static string GenerateSqlDrop(string schemaName, string sequenceName)
    {
        return $@"drop sequence {schemaName}.""{sequenceName}"";";
    }
}
