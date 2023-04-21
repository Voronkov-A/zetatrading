namespace ZetaTrading.Application.Journal;

public readonly struct EventId : IEquatable<EventId>, IComparable<EventId>
{
    private readonly long _value;

    public EventId(long value)
    {
        _value = value;
    }

    public long ToInt64()
    {
        return _value;
    }

    public bool Equals(EventId other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is EventId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public int CompareTo(EventId other)
    {
        return _value.CompareTo(other._value);
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    public static bool operator ==(EventId left, EventId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(EventId left, EventId right)
    {
        return !(left == right);
    }

    public static bool operator <(EventId left, EventId right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(EventId left, EventId right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(EventId left, EventId right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(EventId left, EventId right)
    {
        return left.CompareTo(right) >= 0;
    }
}
