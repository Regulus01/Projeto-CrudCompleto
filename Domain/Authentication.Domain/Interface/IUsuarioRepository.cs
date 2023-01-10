using Domain.Authentication.Domain;
namespace Domain.Authentication.Interface;
public interface IUsuarioRepository
{
    Usuario? Get(string username, string password);
}