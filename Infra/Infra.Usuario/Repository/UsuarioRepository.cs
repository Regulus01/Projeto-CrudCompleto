using Domain.Authentication.Interface;
using Infra.Usuario.Common;
using UsuarioDomain = Domain.Authentication.Domain.Usuario;

namespace Infra.Usuario.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UsuarioContext _context;

    public UsuarioRepository(UsuarioContext context)
    {
        _context = context;
    }
    
    public UsuarioDomain? Get(string username, string password)
    {
        return _context.Usuario.FirstOrDefault(x => x!.Username == username && x.Password == password);
        
    }
}