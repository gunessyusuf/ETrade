using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
	[PrimaryKey(nameof(ProductId), nameof(StoreId))]
	public class ProductStore
	{
		
		public int ProductId { get; set; }

		public Product? Product { get; set; }

		
		public int StoreId { get; set; }

		public Store? Store { get; set; }
	}
}
