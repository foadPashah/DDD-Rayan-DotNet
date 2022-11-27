using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain
{
    public class Auctions
    {
        public Auctions(int id, string product, int fee)
        {
            if (string.IsNullOrWhiteSpace(product)) throw new Exception("");
            Id = id;
            Product = product;
            Fee = fee;
        }

        public int Id { get; private set; }

        public string Product { get; private set; }

        public int Fee { get; private set; }



        public Auctions Update(int id, string product, int fee)
        {
            //....
            return this;
        }
    }
}
