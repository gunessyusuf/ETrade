using AppCore.Records.Bases;
using AppCore.Results.Bases;
using System.Linq.Expressions;

namespace AppCore.Business.DataAccess.EntityFramework.Bases
{
    public interface IService<TEntity> : IDisposable where TEntity : Record, new()
    {
        // product => product.Category, product => product.ProductStores
        // Query().ToList(), Query().SingleOrDefault(product => product.Id == 19),
        // Query().Where(product => product.CategoryId == 1),
        // Query().OrderBy(product
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToInclude); // Result kullanmaya gerek yok. Çünkü bu bir sorgu.  ((Read))

        Result Add(TEntity entity, bool save = true);

        Result Update(TEntity entity, bool save = true);

        Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true); // Delete(product => product.Id == 1) 
    }
}
