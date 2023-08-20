#nullable disable
using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.DataAccess.Entities
{
    #region Entity
    public class Category : Record // Id ve Guid miras alındı
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }

    #endregion
}
