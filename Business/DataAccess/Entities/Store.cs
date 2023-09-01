#nullable disable
using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Business.DataAccess.Entities
{
	public class Store : Record
	{
		[Required]
		[StringLength(150)]
		[DisplayName("Store Name")]
		public string Name { get; set; }

		[DisplayName("Virtual")]
		public bool IsVirtual { get; set; }

		public List<ProductStore> ProductStores { get; set; }
	}
}
