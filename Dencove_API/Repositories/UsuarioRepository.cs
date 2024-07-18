using Microsoft.EntityFrameworkCore;
using Dencove_API.Models;
using Dencove_API.Data;
using Dencove_API.Repositories;

namespace YourNamespace.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task Cadastrar(UsuarioModel usuario)
        {
            _context.UsuarioModels.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioModel> Logar(UsuarioModel usuario)
        {
            return await _context.UsuarioModels
                .Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha)
                .FirstOrDefaultAsync();
        }
    }
}