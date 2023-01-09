using MediatR;

namespace Pessoa.Domain.Commands.Notification;

public class ErroNotification : INotification
{
    public string Excecao { get; set; }
    public string? PilhaErro { get; set; }
}