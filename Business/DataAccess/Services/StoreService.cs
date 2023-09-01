using AppCore.Business.DataAccess.EntityFramework.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Business.DataAccess.Context;
using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.DataAccess.Services
{

	public abstract class StoreServiceBase : Service<Store>
	{
		protected StoreServiceBase(Db db) : base(db)
		{
		}
	}

	public class StoreService : StoreServiceBase
	{
		public StoreService(Db db) : base(db)
		{
		}

		public override IQueryable<Store> Query(params Expression<Func<Store, object>>[] entitiesToInclude)
		{
			return base.Query(entitiesToInclude).Select(s => new Store()
			{
				Id = s.Id,
				Name = s.Name,
				IsVirtual = s.IsVirtual,
				Guid = s.Guid,
				ProductStores = s.ProductStores,
				
			});
		}

		public override Result Add(Store entity, bool save = true)
		{
			if (Query().Any(p => p.Name.ToLower() == entity.Name.ToLower().Trim()))

			{
				return new ErrorResult("Product with the same name exists!");

			}
			entity.Name = entity.Name.ToLower();
			entity.IsVirtual = entity.IsVirtual;
			entity.ProductStores = entity.ProductStores;
			entity.Guid = entity.Guid;
			

			return base.Add(entity, save);
		}

		public override Result Update(Store entity, bool save = true)
		{
			if (Query().Any(p => p.Name.ToLower() == entity.Name.ToLower().Trim() && p.Id != entity.Id))
				return new ErrorResult("Product with the same name exists!");

			entity.Name = entity.Name.ToLower();
			entity.IsVirtual = entity.IsVirtual;
			entity.ProductStores = entity.ProductStores;
			entity.Guid = entity.Guid;

			return base.Update(entity, save);
		}

		
	}
}
