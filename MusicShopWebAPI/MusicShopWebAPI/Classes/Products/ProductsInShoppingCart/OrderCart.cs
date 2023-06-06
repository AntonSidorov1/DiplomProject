using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class OrderCart
    {
        int traidingPointID = 0;

        public int TraidingPointID
        {
            get => traidingPointID;
            set => traidingPointID = value;
        }

        Part info = new Part();

        public Part TraidingPointInfo
        {
            get => info;
            set => info = value;
        }

        bool mayBe = false;

        public bool MayBe
        {
            get => mayBe;
            set => mayBe = value;
        }

        public string MayBeText =>
            MayBe ? "Можно оформить заказ" : "Невозможно оформить заказ";

        double coest = 0;

        public double Coest
        {
            get => coest;
            set => coest = value;
        }

        double coestWithDiscount = 0;

        public double CoestWithDiscount
        {
            get => coestWithDiscount;
            set => coestWithDiscount = value;
        }

        int positionsCount = 0;
        public int PositionsCount
        {
            get => positionsCount;
            set => positionsCount = value;
        }


        int quantity = 0;
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public string GetInformation()
        {
            string information = MayBeText + "\n";
            information += $"Количество позиций в заказе: {PositionsCount} \n";
            information += $"Общее количество товаров в заказе: {Quantity} \n";
            information += $"Стоимость заказа без скидки: {Coest.ToString("C2")} \n";
            information += $"Стоимость заказа со скидкой: {CoestWithDiscount.ToString("C2")} \n";
            information += TraidingPoint + "\n";

            return information;
        }

        public string Information => GetInformation();
        public override string ToString() => Information;

        string traidingPoint = "";

        public string TraidingPoint
        {
            get => traidingPoint;
            set => traidingPoint = value;
        }
    }
}
