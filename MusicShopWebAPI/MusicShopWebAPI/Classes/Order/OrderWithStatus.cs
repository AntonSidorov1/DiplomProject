using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Заказ со статусом
    /// </summary>
    public class OrderWithStatus : OrderValue
    {
        public OrderWithStatus() : base()
        {
        }

        string status = "";

        /// <summary>
        /// Статус
        /// </summary>
        public string Status
        {
            get => status;
            set => status = value;
        }

        int positionsCount = 0;

        /// <summary>
        /// Количество позиций в заказе
        /// </summary>
        public int PositionsCount
        {
            get => positionsCount;
            set => positionsCount = value;
        }

        int productsQuantity = 0;

        /// <summary>
        /// Общее количество товаров в заказе
        /// </summary>
        public int ProductsQuantity
        {
            get => productsQuantity;
            set => productsQuantity = value;
        }

        /// <summary>
        /// Информация о заказе
        /// </summary>
        public string Information
        {
            get
            {
                string result = "";
                result += $"Номер заказа - {Number} \n";
                result += $"Статус заказа - {Status} \n";
                result += $"Дата оформления заказа - {DateCreate} \n";
                result += $"Дата изменения статуса заказа - {DateStatusChange} \n";
                result += $"Стоимость без скидки - {Cost.ToString("C2")} \n";
                result += $"Стоимость со скидкой - {CostWithDiscount.ToString("C2")} \n";
                result += $"Количество позиций в заказе - {PositionsCount} \n";
                result += $"Общее количество товаров в заказе - {ProductsQuantity} \n";

                return result;
            }
        }

        public override string ToString()
        {
            return Information;
        }

        string pickupPoint = "";

        /// <summary>
        /// Пункт получения
        /// </summary>
        public string PickupPoint
        {
            get => pickupPoint;
            set => pickupPoint = value;
        }

        public void SetPickupPoint(TradingPointsList tradings)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            int id = 0;
            string type = "";
            try
            {
                connection.Open();
                try
                {
                    try
                    {
                        SqlCommand command = new SqlCommand($"Select [OrderShopID] From [OrderInShop] " +
                            $"where [OrderID]={ID}", connection);
                        id = Convert.ToInt32(command.ExecuteScalar());
                        if (id < 1)
                            throw new Exception();
                        type = "Магазин для получения";
                    }
                    catch
                    {
                        SqlCommand command = new SqlCommand($"Select [PounktOfIssoeID] From [OrderInPounktOfIssue] " +
                            $"where [OrderID]={ID}", connection);
                        id = Convert.ToInt32(command.ExecuteScalar());
                        if (id < 1)
                            throw new Exception();
                        type = "Пункт выдачи для получения";
                    }

                    PickupPoint = $"{type}: \n"+
                        tradings.GetByID(id).Data;
                }
                catch
                {
                    connection.Close();
                }
                connection.Close();
            }
            catch
            {

            }
        }
    }
}
