using AppCore.Records.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppCore.Business.DataAccess.EntityFramework.Bases
{
    // Veritabanında entity üzerinden CRUD (create, read, update, delete) işlemleri gerçekleştirmek
    // için Repository Pattern uygulanan base hizmet sınıfı, Service class'ına Repository ismi de verilebilir
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Record, new()
    {
        const string ERRORMESSAGE = "Changes not saved!";
        const string ADDEDMESSAGE = "Added successfully.";
        const string UPDATEDMESSAGE = "Updated successfully.";
        const string DELETEDMESSAGE = "Deleted successfully.";

        protected readonly DbContext _db;

        protected Service(DbContext db)
        {
            _db = db;
        }

        public virtual IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            foreach (var entityToInclude in entitiesToInclude)
            {
                query = query.Include(entityToInclude);
            }
            return query;
        }

        // var productList = _productService.GetList();
        public virtual List<TEntity> GetList()
        {
            return Query().ToList();
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).ToList();
        }

        // var productItem = _productService.GetItem(7);
        public virtual TEntity GetItem(int id)
        {
            return Query().SingleOrDefault(e => e.Id == id);
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Query().Any(predicate);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = Query(entitiesToInclude);
            query = query.Where(predicate);
            return query;
        }

        public IQueryable<TEntity> QueryAsNoTracking(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return Query(entitiesToInclude).AsNoTracking();
        }

        public IQueryable<TEntity> QueryAsNoTracking(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return QueryAsNoTracking(entitiesToInclude).Where(predicate);
        }

        // eğer istenirse yukarıdaki Query methodları üzerinden entity listesi dönen methodlar ile
        // tek bir entity dönen methodlar da kullanım kolaylığı için oluşturulabilir

        public virtual Result Add(TEntity entity, bool save = true)
        {
            entity.Guid = Guid.NewGuid().ToString();
            _db.Set<TEntity>().Add(entity);
            if (save)
            {
                Save();
                return new SuccessResult(ADDEDMESSAGE);
            }
            return new ErrorResult(ERRORMESSAGE);
        }

        public virtual Result Update(TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Update(entity);
            if (save)
            {
                Save();
                return new SuccessResult(UPDATEDMESSAGE);
            }
            return new ErrorResult(ERRORMESSAGE);
        }

        public virtual Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true)
        {
            var entities = _db.Set<TEntity>().Where(predicate).ToList();
            _db.Set<TEntity>().RemoveRange(entities);
            if (save)
            {
                Save();
                return new SuccessResult(DELETEDMESSAGE);
            }
            return new ErrorResult(ERRORMESSAGE);
        }

        // eğer istenirse id üzerinden silme işlemi gerçekleştiren Delete methodu da eklenebilir

        public virtual int Save()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception exc)
            {
                // exc.Message üzerinden veritabanındaki log tablosunda veya log dosyasında loglama kodları
                // ile beklenmedik hata kayıtları tutulabilir,
                // NLog veya Log4Net gibi kütüphaneler üzerinden loglama yönetimi yapılması en uygunudur
                throw exc;
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}