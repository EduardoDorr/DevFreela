namespace DevFreela.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; }

    protected BaseEntity() { }
}