using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Business.DataAccess.Context
{
    //Db objesini oluşturup kullanılmasını sağlayan fabrika class'ı , sca
    public class DbFactory : IDesignTimeDbContextFactory<Db>
    {
        public Db CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=ETradeDB;trusted_connection=true;multipleactiveresultsets=true;trustservercertificate=true");
            return new Db(optionsBuilder.Options);
        }
    }
}



