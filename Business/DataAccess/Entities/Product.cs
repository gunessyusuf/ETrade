#nullable disable
using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.DataAccess.Entities
{
    public class Product : Record
    {
        // istenirse Id için [Key] Primary Key Data Annotation'ı da kullanılabilir ancak; Entity Framework Id, ID, id, ProductID, vb. özellik isimlerindeki id ğzerinden özelliği otomatik olarak Primary Key olarak belirliyor.
        [Required]
        // [StringLength(200)]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Range(0, 1000000)]
        public int StockAmount { get; set; }

        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool IsContinued { get; set; }
    }
}
