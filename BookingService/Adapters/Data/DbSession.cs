using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration
                .GetConnectionString("DefaultConnection"));

            Connection.Open();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
