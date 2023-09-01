using AppCore.Business.DataAccess.EntityFramework.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Business.DataAccess.Context;
using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;

namespace Business.DataAccess.Services
{
    public abstract class ProductServiceBase : Service<Product>
    {
        protected ProductServiceBase(Db db) : base(db)  // DbContext değil Db olmasına dikkat et
        {
        }
    }

    public class ProductService : ProductServiceBase
    {
        public ProductService(Db db) : base(db)
        {

        }

        public override IQueryable<Product> Query(params Expression<Func<Product, object>>[] entitiesToInclude)
        {
            return base.Query(entitiesToInclude).Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                StockAmount = p.StockAmount,
                Category = p.Category,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId,
                Description = p.Description,
                ExpirationDate = p.ExpirationDate,
                Guid = p.Guid,
                IsContinued = p.IsContinued,
                ProductStores = p.ProductStores,

                StoreIds = p.ProductStores.Select(ps => ps.StoreId).ToList(),

               

                UnitPriceDisplay = p.UnitPrice.HasValue ? p.UnitPrice.Value.ToString("C2", new CultureInfo("en-US")) : "",
                ExpirationDateDisplay = p.ExpirationDate.HasValue ? p.ExpirationDate.Value.ToString("MM/dd/yyyy", new CultureInfo("en-US")) : "",
                IsContinuedDisplay = p.IsContinued ? "Yes" : "No"
            }) ;
        }

		public override Result Add(Product entity, bool save = true)
		{
            //if(_db.Set<Product>().Any(p => p.Name.ToLower() == entity.Name.ToLower().Trim()))
            if(Query().Any(p => p.Name.ToLower() == entity.Name.ToLower().Trim()))

            {
                return new ErrorResult("Product with the same name exists!");
               
			}
			entity.Name = entity.Name.Trim();
			entity.Description = entity.Description?.Trim();
            entity.IsContinued = true;

			return base.Add(entity, save);

		}

		public override Result Update(Product entity, bool save = true)
		{
			if (Query().Any(p => p.Name.ToLower() == entity.Name.ToLower().Trim() && p.Id != entity.Id))
				return new ErrorResult("Product with the same name exists!");

			entity.Name = entity.Name.Trim();
			entity.Description = entity.Description?.Trim();
			entity.IsContinued = true;
			return base.Update(entity, save);
		}
	}
}
