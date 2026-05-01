using Microsoft.Extensions.Configuration;
using Npgsql;
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

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_conString);

        public async Task<IDbConnection> CreateOpenConnection()
        {
            var con = new NpgsqlConnection();
            await con.OpenAsync();
            return con;
        }
    }
}
