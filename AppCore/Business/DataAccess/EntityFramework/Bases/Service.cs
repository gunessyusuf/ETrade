using AppCore.Records.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.Business.DataAccess.EntityFramework.Bases
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Record, new()
    {
        const string ERRORMESSAGE = "Changes not saved";
        const string ADDEDMESSAGE = "Added successfully";
        const string UPDATEDMESSAGE = "Updated successfully";
        const string DELETEDMESSAGE = "Deleted successfully";

        protected readonly DbContext _db;

        protected Service(DbContext db)
        {
            _db = db;
        }

        public virtual Result Add(TEntity entity, bool save = true)
        {
            entity.Guid = Guid.NewGuid().ToString();
            _db.Set<TEntity>().Add(entity); // db nin TEntity setine add ile eklenecek olarak işlenecek.
            if (save)
            {
                Save();
                return new SuccessResult(ADDEDMESSAGE);
            }

            return new ErrorResult(ERRORMESSAGE);

        }

        public virtual Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true)
        {
            var entities = _db.Set<TEntity>().Where(predicate).ToList();

            //foreach (var entity in entities)
            //{
            //    _db.Set<TEntity>().Remove(entity); // varlıkları tek tek siler
            //}

            _db.Set<TEntity>().RemoveRange(entities); // Koleksiyondaki varlıkları siler.

            if (save)
            {
                Save();
                return new SuccessResult(DELETEDMESSAGE);
            }
            return new ErrorResult(ERRORMESSAGE);
        }

        public virtual IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = _db.Set<TEntity>().AsQueryable();

            foreach (var entity in entitiesToInclude)
            {
                query = query.Include(entity);
            }

            return query;
        }

        public  IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = Query(entitiesToInclude);
            query = query.Where(predicate);
            return query;
        }

        public  IQueryable<TEntity> QueryAsNoTracking(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return Query(entitiesToInclude).AsNoTracking();
        }
        public  IQueryable<TEntity> QueryAsNoTracking(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return QueryAsNoTracking(entitiesToInclude).Where(predicate).AsNoTracking();
        }


        public virtual Result Update(TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Update(entity);
            if (save)
            {
                Save();
                return new SuccessResult("Added successfully.");
            }

            return new ErrorResult(ERRORMESSAGE);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public int Save() // Etkilenen satır sayısını verir.
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

    }
}
