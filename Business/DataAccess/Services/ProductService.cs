using AppCore.Business.DataAccess.EntityFramework.Bases;
using Business.DataAccess.Context;
using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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
    }
}
