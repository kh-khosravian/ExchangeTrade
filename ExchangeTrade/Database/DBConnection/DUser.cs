using Dapper;
using ExchangeTrade.Database.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeTrade.Database.DBConnection
{
    public class DUser : BaseDBConnection
    {
        public DUser(IConfiguration connectionString) : base(connectionString.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection"))
        {

        }
        public async Task<User> User(string username)
        {
            string sql = "SELECT * FROM [dbo].[User] WHERE Email = @username";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(sql, new { username = username });
                return user;
            }
        }
    }
}
