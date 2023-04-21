namespace ZetaTrading.Domain.Common;

public readonly struct Name : IEquatable<Name>, IComparable<Name>
{
    private readonly string _value;

    public Name(string value)
    {
        _value = value;
    }

    public bool Equals(Name other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Name other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public int CompareTo(Name other)
    {
        return string.Compare(_value, other._value, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return _value;
    }

    public static bool operator ==(Name left, Name right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Name left, Name right)
    {
        return !(left == right);
    }

    public static bool operator <(Name left, Name right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(Name left, Name right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(Name left, Name right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(Name left, Name right)
    {
        return left.CompareTo(right) >= 0;
    }
}
