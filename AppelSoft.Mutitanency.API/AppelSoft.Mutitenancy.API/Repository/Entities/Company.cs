using Google.Protobuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppelSoft.Mutitenancy.API.Repository.Entities
{
    [Table("company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string CNPJ { get; set; }

        public bool Status { get; set; }
    }
}
