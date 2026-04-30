using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MedFlow.Identity.Infrastructure.Persistence.Data
{
    public class DapperContext
    {
        private readonly string _conString;
        public DapperContext(IConfiguration config) 
        {
            _conString = config.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(config));
        }

        public  IDbConnection Createconnection() 
            => new SqlConnection(_conString);
    }
}
