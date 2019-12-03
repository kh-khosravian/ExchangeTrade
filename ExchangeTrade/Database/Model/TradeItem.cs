using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeTrade.Database.Model
{
    public class TradeItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Item { get; set; }
        public double ExchangeFee { get; set; }
        public string ExchangeItem { get; set; }
        public long UserId { get; set; }
    }
}
