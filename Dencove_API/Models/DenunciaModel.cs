using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dencove_API.Models
{
    [Table("Denuncia")]
    public class DenunciaModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Descricao { get; set; }
        [MaxLength(30)]
        public string Rua { get; set; }
        public string Bairro { get; set; }
        [MaxLength(5)]
        public string Numero { get; set; }
        [Column(TypeName = "char(1)")]
        public string GrauAcao { get; set; }
        public string Img { get; set; }
        public string Resposta { get; set; }
        [Column(TypeName = "char(1)")]
        public string Status { get; set; }
        public DateOnly DataDenuncia { get; set; }
    }
}
