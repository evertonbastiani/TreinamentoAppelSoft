using System.ComponentModel.DataAnnotations.Schema;

namespace AppelSoft.Mutitenancy.API.Repository.Entities
{
    [Table("product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
       

    }
}
