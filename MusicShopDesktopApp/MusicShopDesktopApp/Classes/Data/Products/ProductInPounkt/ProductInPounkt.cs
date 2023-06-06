using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Товар в торговом пункте
    /// </summary>
    public class ProductInPounkt : ProductWithCount
    {

        PounktType pounktType = PounktType.Shop;

        /// <summary>
        /// Задать тип торгового пункта
        /// </summary>
        /// <param name="pounktType"></param>
        public void SetPounktType(PounktType pounktType)
        {
            this.pounktType = pounktType;
        }

        /// <summary>
        /// Получить тип торгового пункта
        /// </summary>
        /// <returns></returns>
        public PounktType GetPounktType() => pounktType;


        public override string GetData()
        {
            return base.GetData() + "\n" +
                 QuantityText;
        }

        public override string QuantityText => (pounktType != PounktType.All ? (Quantity > 0 ? $"Количество {(pounktType == PounktType.Shop ? "в магазине" : "на складе")}" +
                $" - {Quantity}" : "Нет в наличии") : "");

        public ProductInPounkt CopyProductInPounkt() => CopyProductInPounkt(GetPounktType());

        public override Product CopyProduct()
        {
            return CopyProductInPounkt();
        }
    }

    /// <summary>
    /// Тип торгового пункта
    /// </summary>
    public enum PounktType
    {
        /// <summary>
        /// Магазин
        /// </summary>
        Shop,
        /// <summary>
        /// Склад
        /// </summary>
        Stock,
        /// <summary>
        /// Все торговые пункты
        /// </summary>
        All
    }
}
