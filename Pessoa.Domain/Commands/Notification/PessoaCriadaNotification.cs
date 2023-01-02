using MediatR;

namespace Pessoa.Domain.Commands.Notification;

public class PessoaCriadaNotification : INotification
{
    public string Nome { get; set; }
    public string Email { get; set; }
}