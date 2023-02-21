using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Domain.Entities
{
    [Table("tipo_veiculo")]
    public class TipoVeiculo 
    {
        [Key]
        public long Id { get; set; }

        public string? Descricao { get; set; }
    }
}
