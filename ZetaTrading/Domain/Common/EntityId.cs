namespace ZetaTrading.Domain.Common;

public readonly struct EntityId : IEquatable<EntityId>, IComparable<EntityId>
{
    private readonly long _value;

    public EntityId(long value)
    {
        _value = value;
    }

    public long ToInt64()
    {
        return _value;
    }

    public bool Equals(EntityId other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is EntityId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public int CompareTo(EntityId other)
    {
        return _value.CompareTo(other._value);
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    public static bool operator ==(EntityId left, EntityId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(EntityId left, EntityId right)
    {
        return !(left == right);
    }

    public static bool operator <(EntityId left, EntityId right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(EntityId left, EntityId right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(EntityId left, EntityId right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(EntityId left, EntityId right)
    {
        return left.CompareTo(right) >= 0;
    }
}
