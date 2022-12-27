namespace Pessoa.Domain.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CriadoEm { get; private set; }
}