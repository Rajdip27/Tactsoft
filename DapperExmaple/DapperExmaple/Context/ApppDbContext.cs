using Dapper.ORM;
using System.Collections;

namespace DapperExmaple.Context
{
    public class ApppDbContext : DapperContext
    {
        public ApppDbContext(IConfiguration configuration) : base(configuration.GetConnectionString("DapperDB"), DatabaseServer.MsSQL)
        {
            
        }
    }
}
