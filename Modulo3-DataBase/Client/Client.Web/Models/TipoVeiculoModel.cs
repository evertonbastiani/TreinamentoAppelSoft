using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client.Web.Models
{
    public class TipoVeiculoModel
    {
        //Código é o nome que irá apenas aparecer na tela para o usuário. Na classe o campo é Id.
        [DisplayName("Código")]
        public long Id { get; set; }

        //Descrição é o nome que irá apenas aparecer na tela para o usuário. Na classe o campo é Descricao (sem acentuação).
        [Required(ErrorMessage ="Informe a Decrição do tipo")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
