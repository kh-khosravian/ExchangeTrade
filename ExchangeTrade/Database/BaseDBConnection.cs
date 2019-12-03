using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeTrade.Database
{
    public class BaseDBConnection
    {
        protected string ConnectionString { get; set; }
        public BaseDBConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
