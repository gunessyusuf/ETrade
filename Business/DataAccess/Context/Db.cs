using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.DataAccess.Context
{
    public class Db : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<ProductStore> ProductStores { get; set; }



        // options parametresinde veritabanı ile ilgili bilgiler var, örneğin connection string
        public Db(DbContextOptions options) : base(options) // dependency injenciton var. Dependency injection olan her yer, program.cs de yönetilir.
        {

        }

        // OnConfiguring methodunda connection string kullanılması yerine yukarıdaki parametreli constructor üzerinden kullanılan yazılan DbContextOptions tipindeki parametre ile connection string kullanılmalıdır. 
        // Bu connection string uygulama veya restful servis projesindeki appsettings.json veya appsettings.Development.json dosyalarında tanımlanan connection string'dir.

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Windows Authentication
        //    //string connectionString = "server=.\\SQLEXPRESS;database=ETradeDB;trusted_connection=true;multipleactiveresultsets=true;trustservercertificate=true";

        //    // SQL Server Authentication
        //    string connectionString = "server=.\\SQLEXPRESS;database=ETradeDB;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true";
        //    optionsBuilder.UseSqlServer(connectionString); // bu metot sayesinde adam biliyor veritabanını
        //}
    }
}
