using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Domain.Entities
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Key]
        public long Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Ano { get; set; }
        public string? Cor { get; set; }
        public string? Placa { get; set; }

        [ForeignKey("id")]
        public TipoVeiculo Tipo { get; set; }

        public Veiculo()
        {
            this.Tipo = new TipoVeiculo();
        }
    }
}
