using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dencove_API.Models;
using Dencove_API.Repositories;

namespace Dencove_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _repository.GetUsuarios();
            return Ok(usuarios);
        }
    }

    [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            usuario.Senha = ConvertToHash(usuario.Senha);
            await _repository.Cadastrar(usuario);
            return CreatedAtAction(nameof(Cadastrar), new { id = usuario.Id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Logar([FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            usuario.Senha = ConvertToHash(usuario.Senha);
            var usuarioLogado = await _repository.Logar(usuario);
            if (usuarioLogado != null)
                return Ok(usuarioLogado);
            else
                return Unauthorized();
        }

        private string ConvertToHash(string senha)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}