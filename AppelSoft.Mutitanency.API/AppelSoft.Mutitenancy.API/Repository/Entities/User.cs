using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppelSoft.Mutitenancy.API.Repository.Entities
{
    [Table("usuario")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        public DateTime CreatedDate { get; set; }
        public string Nome { get; internal set; }
        public int Companyid { get; internal set; }

       
    }
}
