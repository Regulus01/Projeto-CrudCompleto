using MediatR;
using Pessoa.Domain.Commands.Notification;

namespace Pessoa.Domain.Handle;

public class NotificationHandler : INotificationHandler<PessoaCriadaNotification>, 
                                   INotificationHandler<ErroNotification>

{
    public Task Handle(PessoaCriadaNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"CRIACAO: ' {notification.Nome} - {notification.Email} '");
        });
    }

    public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
        });
    }
}