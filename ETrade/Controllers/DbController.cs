using Business.DataAccess.Context;
using Business.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Globalization;
using System.Text;

namespace MVC.Controllers
{
	public class DbController : Controller
	{

		private readonly Db _db;

		public DbController(Db db)
		{
			_db = db;
		}

		public IActionResult Seed()
		{
			var productStores = _db.ProductStores.ToList();
			_db.ProductStores.RemoveRange(productStores);

			var stores = _db.Stores.ToList();
			_db.Stores.RemoveRange(stores);

			var products = _db.Products.ToList();
			_db.Products.RemoveRange(products);

			var categories = _db.Categories.ToList();
			_db.Categories.RemoveRange(categories);

			


			_db.Stores.Add(new Store()
			{
				Name = "Trendyol",
				IsVirtual = true,
			});

			_db.Stores.Add(new Store()
			{
				Name = "MediaMarkt",
				IsVirtual = false,
			});

			_db.SaveChanges();

			_db.Categories.Add(new Category()
			{
				Name = "Computer",
				Description = "Laptops, desktops and computer peeripherals",
				Products = new List<Product>()
				{
					new Product()
					{
						Name = "Laptop",
						UnitPrice = 300.5,
						ExpirationDate = new DateTime(2032, 1, 27),
						StockAmount = 10,

					   ProductStores = new List<ProductStore>()
					   {
						   new ProductStore()
						   {
						   StoreId = _db.Stores.SingleOrDefault(s => s.Name =="Trendyol").Id
						   }
					   }

                    },
					new Product()
					{
						Name = "Mouse",
						UnitPrice = 20.5,
						StockAmount = 50,
						Description = "Computer peripheral",
						  ProductStores = new List<ProductStore>()
					   {
						   new ProductStore()
						   {
						   StoreId = _db.Stores.SingleOrDefault(s => s.Name =="MediaMarkt").Id
						   }
					   }
					},
					new Product()
					{
						Name = "Keyboard",
						UnitPrice = 40,
						StockAmount = 45,
						Description = "Computer peripheral",
						  ProductStores = new List<ProductStore>()
					   {
						   new ProductStore()
						   {
						   StoreId = _db.Stores.SingleOrDefault(s => s.Name =="Trendyol").Id
						   }
					   }
					},
					new Product()
					{
						Name = "Monitor",
						UnitPrice = 2500,
						ExpirationDate = DateTime.Parse("05/19/2027", new CultureInfo("en-US")),
						StockAmount = 20,
						Description = "Computer peripheral",
						  ProductStores = new List<ProductStore>()
					   {
						   new ProductStore()
						   {
						   StoreId = _db.Stores.SingleOrDefault(s => s.Name =="MediaMarkt").Id
						   }
					   }
					}
				}
			});

			_db.Categories.Add(new Category()
			{
				Name = "Home Theater System",
				Products = new List<Product>()
				{
					new Product()
					{
						Name = "Speaker",
						UnitPrice = 2500,
						StockAmount = 50,
						  ProductStores = new List<ProductStore>()
					   {
						   new ProductStore()
						   {
						   StoreId = _db.Stores.SingleOrDefault(s => s.Name =="Trendyol").Id
						   }
					   }
					},
					new Product()
					{
						Name = "Receiver",
						UnitPrice = 5000,
						StockAmount = 30,
						  ProductStores = new List<ProductStore>()
					   {
						   new ProductStore()
						   {
						   StoreId = _db.Stores.SingleOrDefault(s => s.Name =="MediaMarkt").Id
						   }
					   }
					},

					new Product()
					{
						Name = "Equalizer",
						UnitPrice = 1000,
						StockAmount = 40,
						  ProductStores = new List<ProductStore>()
					   {
						   new ProductStore()
						   {
						   StoreId = _db.Stores.SingleOrDefault(s => s.Name =="Trendyol").Id
						   }
					   }
					}
				}
			});

			_db.SaveChanges();

			return Content("<label style=\"color:red;\"><b>Database seed successful.</b></label>", "text/html", Encoding.UTF8);
		}
	}
}
