using Dapper.ORM;

namespace Dapper_Store_Sqlprocedure.DbContext
{
    public class AppDbContext : DapperContext
    {
        public AppDbContext(IConfiguration configuration) : base(configuration.GetConnectionString("DapperDB"),DatabaseServer.MsSQL)
        {

        }
    }
}
