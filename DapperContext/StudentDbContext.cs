using System.Data;
using System.Data.SqlClient;

namespace Assignment.DapperContext
{
    public class StudentDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public StudentDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
