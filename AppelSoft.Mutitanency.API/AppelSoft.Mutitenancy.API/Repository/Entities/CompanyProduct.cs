using System.ComponentModel.DataAnnotations.Schema;

namespace AppelSoft.Mutitenancy.API.Repository.Entities
{
    [Table("company_product")]
    public class CompanyProduct
    {
        public int Id { get; set; }
        public int Id_Company { get; set; }
        public int Id_Product { get; set; }

        public bool Active { get; set; }
        public DateTime? Expiration_Date { get; set; }

    }
}
