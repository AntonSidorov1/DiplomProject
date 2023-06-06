using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class OrderWithOutNumber
    {

        double cost = 0;

        public double Cost
        {
            get => cost;
            set => cost = value;
        }

        double costWithDiscount = 0;

        public double CostWithDiscount
        {
            get => costWithDiscount;
            set => costWithDiscount = value;
        }

        public void SetOrder(OrderWithOutNumber order)
        {
            Cost = order.Cost;
            CostWithDiscount = order.CostWithDiscount;
        }
    }
}
