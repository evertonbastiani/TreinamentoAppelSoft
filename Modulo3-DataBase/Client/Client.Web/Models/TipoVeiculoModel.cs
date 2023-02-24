using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client.Web.Models
{
    public class TipoVeiculoModel
    {
        public long Id { get; set; }


        [Required(ErrorMessage ="Informe a Decrição do tipo")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
