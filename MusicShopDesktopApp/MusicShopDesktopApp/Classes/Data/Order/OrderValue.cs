using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderValue : GeographyPoint
    {
        /// <summary>
        /// Номер заказа
        /// </summary>
        public string Number
        {
            get => Name;
            set => Name = value;
        }

        OrderWithOutNumber valueOrder = new OrderWithOutNumber();

        public OrderWithOutNumber Value
        {
            get => valueOrder;
            set => valueOrder = value;
        }

        /// <summary>
        /// Стоимость заказа без скидки
        /// </summary>
        public double Cost
        {
            get => Value.Cost;
            set => Value.Cost = value;
        }

        /// <summary>
        /// Стоимость заказа со скидкой
        /// </summary>
        public double CostWithDiscount
        {
            get => Value.CostWithDiscount;
            set => Value.CostWithDiscount = value;
        }

        int statusID = 0;

        /// <summary>
        /// ID статуса
        /// </summary>
        public int StatusID
        {
            get => statusID;
            set => statusID = value;
        }

        DateTime dateCreate;

        /// <summary>
        /// Дата оформления заказа
        /// </summary>
        public DateTime DateCreate
        {
            get => dateCreate;
            set => dateCreate = value;
        }

        DateTime dateStatusChange;

        /// <summary>
        /// Дата смены статуса заказа
        /// </summary>
        public DateTime DateStatusChange
        {
            get => dateStatusChange;
            set => dateStatusChange = value;
        }


        public OrderValue()
        {
            dateCreate = DateTime.Now;
            dateStatusChange = DateTime.Now;
        }

        public void SetOrder(OrderValue order)
        {
            Number = order.Number;
            DateCreate = order.DateCreate;
            DateStatusChange = order.DateStatusChange;
            ID = order.ID;
            StatusID = order.StatusID;
            Value.SetOrder(order.Value);
        }


    }
}
