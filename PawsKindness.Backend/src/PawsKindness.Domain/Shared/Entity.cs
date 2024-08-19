namespace PawsKindness.Domain.Shared;

public abstract class Entity<TId> where TId: notnull 
{
    public TId Id { get; private set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
        {
            return false;
        }

        if (GetUnproxyTypeName(this) != GetUnproxyTypeName(other))
        {
            return false;
        }

        return ReferenceEquals(this, other) || Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return (GetUnproxyTypeName(this) + Id).GetHashCode();
    }

    public static bool operator ==(Entity<TId> a, Entity<TId> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TId> a, Entity<TId> b)
    {
        return !(a == b);
    }

    internal static string GetUnproxyTypeName(object obj)
    {
        const string EFCoreProxyPrefix = "Castle.Proxies.";

        var type = obj.GetType();
        var typeName = type.FullName;

        var unproxyType = typeName!.Contains(EFCoreProxyPrefix)
            ? type.BaseType!.FullName
            : typeName;

        return unproxyType!;
    }
}
