using System.ComponentModel.DataAnnotations;

namespace Curso.Domain.DTO
{
    public class TipoVeiculoDTO
    {
        public long Id { get; set; }

        //[Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string? Descricao { get; set; }
    }
}
