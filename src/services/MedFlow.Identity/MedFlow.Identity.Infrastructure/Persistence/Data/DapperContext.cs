using Microsoft.Extensions.Configuration;

namespace MedFlow.Identity.Infrastructure.Persistence.Data
{
    public class DapperContext
    {
        private readonly string _conString;
        public DapperContext(IConfiguration config) { }
    }
}
