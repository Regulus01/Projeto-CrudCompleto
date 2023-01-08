namespace Pessoa.Domain.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTimeOffset CriadoEm { get; private set; }

    public void InformeCriacao(DateTimeOffset date)
    {
        CriadoEm = date;
    }
}