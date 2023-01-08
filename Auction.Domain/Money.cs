using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain
{
    public record Money
    {
        public Money(double box, Currency currency)
        {
            Currency = currency;
            Box = box;
        }

        public double Box { get; private set; }

        public Currency Currency { get; private set; }
    }
}
