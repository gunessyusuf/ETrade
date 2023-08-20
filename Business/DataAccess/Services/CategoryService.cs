using AppCore.Business.DataAccess.EntityFramework.Bases;
using Business.DataAccess.Context;
using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.DataAccess.Services
{
    public abstract class CategoryServiceBase : Service<Category>
    {
        protected CategoryServiceBase(Db db) : base(db)  // DbContext değil Db olmasına dikkat et // somut olmak zorunda, kendi db contextimiz
        {
        }
    }

    public class CategoryService : CategoryServiceBase
    {
        public CategoryService(Db db) : base(db)
        {

        }
    }
}
