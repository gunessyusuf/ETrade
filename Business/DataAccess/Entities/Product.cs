#nullable disable
using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
    public partial class Product : Record
    {
        #region Model
        #region Entity
        // istenirse Id için [Key] Primary Key Data Annotation'ı da kullanılabilir ancak; Entity Framework Id, ID, id, ProductID, vb. özellik isimlerindeki id ğzerinden özelliği otomatik olarak Primary Key olarak belirliyor.
        [Required(ErrorMessage ="{0} is required!")]
        // [StringLength(200)]
        [MinLength(3, ErrorMessage ="{0} must be minimum {1} characters!")]
        [MaxLength(200, ErrorMessage = "{0} must be minimum {1} characters!")]

		public string Name { get; set; }

        [StringLength(300, ErrorMessage ="{0} must be between {1} characters!")]
        public string Description { get; set; }

		[Required(ErrorMessage = "{0} is required!")]
		[Range(0, 1000000, ErrorMessage = "{0} must be maximum {1} and {2}")]
        [DisplayName("Stock Amount")]
        public int? StockAmount { get; set; }

		[Required(ErrorMessage = "{0} is required!")]
		[Range(0, double.MaxValue)]
        [DisplayName("Unit Price")]
        public double? UnitPrice { get; set; }

        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        public bool IsContinued { get; set; }

        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
    #endregion

    #region Veri gösterimi vb. işlemler için entity dışındaki extra özellikler
    public partial class Product
    {
        [NotMapped]
        [DisplayName("Unit Price")]
        public string UnitPriceDisplay { get; set; }

        [NotMapped]
        [DisplayName("Expiration Date")]
        public string ExpirationDateDisplay { get; set; }

        [NotMapped]
        [DisplayName("Is Continued")]
        public string IsContinuedDisplay { get; set; }
    }

    #endregion
    #endregion
}
