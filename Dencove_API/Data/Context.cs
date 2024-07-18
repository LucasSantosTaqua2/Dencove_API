using Dencove_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dencove_API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<BairroModel> BairroModels { get; set; }
        public DbSet<DenunciaModel> DenunciaModels { get; set; }
        public DbSet<UsuarioModel> UsuarioModels { get; set; }
    }
}
