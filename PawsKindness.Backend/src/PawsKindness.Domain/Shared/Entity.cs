namespace PawsKindness.Domain.Shared;

public class Entity<TId> where TId: notnull 
{
    public TId Id { get; private set; }

    protected Entity(TId id)
    {
        Id = id;
    }
}
