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

        public Auctions() { }
        public Auctions(int id, string product, int fee)
        {
            if (string.IsNullOrWhiteSpace(product)) throw new Exception("");
            Id = id;
            //Product = product;
            //Fee = fee;
            IsOpen= true;
        }

        public int Id { get; set; }

        public string Good { get; set; }

        public GoodType GoodType { get; set; }

        public Money Price { get; set; }

        public bool IsOpen { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastBidTime { get; set; }

        public Auctions Update(int id, string product, int fee)
        {
            //....
            return this;
        }
    }
}
