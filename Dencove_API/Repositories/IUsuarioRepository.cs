using Dencove_API.Models;

namespace Dencove_API.Repositories
{
    public interface IUsuarioRepository
    {
        Task Cadastrar(UsuarioModel usuario);
        Task<UsuarioModel> Logar(UsuarioModel usuario);
    }
}