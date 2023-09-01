﻿#nullable disable
using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
    #region Model

    #region Entity
    public partial class Category : Record // Id ve Guid miras alındı
    {
        [Required(ErrorMessage = "{0} is required!" )]
        [StringLength(100, ErrorMessage ="{0} must be maximum {1} characters!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }

    #endregion

    #region VerGösterimi Vb. işlemler için Entity Dışındaki Ekstra Özellikler

    public partial class Category
    {
        [NotMapped]
        [DisplayName("Product Count")]
        public int ProductCountDisplay { get; set; }


        [NotMapped]
        [DisplayName("Products")]
        public string ProductsDisplay { get; set; }
    }
    #endregion

    #endregion
}
