namespace BuberDinner.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public bool Equals(ValueObject? other) => Equals((object?) other);

    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject) obj;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject left, ValueObject right) => Equals(left, right);

    public static bool operator !=(ValueObject left, ValueObject right) => ! Equals(left, right);

    /// <inheritdoc />
    public override int GetHashCode() =>
        GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
}
