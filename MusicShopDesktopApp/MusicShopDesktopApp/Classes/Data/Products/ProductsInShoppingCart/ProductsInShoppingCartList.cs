using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class ProductsInShoppingCartList : AbstractProductsList<ProductInShoppingCart>
    {
        public ProductsInShoppingCartList()
        {
        }

        public ProductsInShoppingCartList(IEnumerable<ProductInShoppingCart> collection) : base(collection)
        {
        }

        public ProductsInShoppingCartList(int capacity) : base(capacity)
        {
        }

        public bool AddProduct(Product product)
        {
            try
            {
                if (ContainsByID(product))
                {
                    int index = GetByID(product).Index;
                    return AddProduct(index);
                }
                ProductInShoppingCart withCount = product.CopyProductInShoppingCart(1);
                withCount.SetNullChange = (index) =>
                    {
                        try
                        {
                            RemoveAt(index);
                        }
                        catch
                        {

                        }
                    };
                withCount.SetProductsCheck(Products);
                withCount.SetProducts(this);
                Add(withCount);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetProductCount(int index, int count)
        {
            try
            {
                Get(index).Quantity = count;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddProductWithCount(Product product, int count)
        {
            try
            {
                bool result = true;
                result = result && AddProduct(product);
                return result && SetProductCount(product, count);
            }
            catch
            {
                return false;
            }
        }

        public bool AddProductWithCount(ProductWithCount product)
            => AddProductWithCount(product, product.Quantity);

        public bool AddAproductsWithCountRange(IEnumerable<ProductWithCount> products)
        {
            bool result = true;
            List<ProductWithCount> withCounts = new List<ProductWithCount>(products);
            for(int i = 0; i < withCounts.Count; i++)
            {
                result = result && AddProductWithCount(withCounts[i]);
            }
            return result;
        }

        public bool SetProductsWithCountRange(IEnumerable<ProductQuantity> products)
        {
            try
            {
                Clear();
                return AddProductsWithCountRange(products);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddProductsWithCountRange(IEnumerable<ProductQuantity> products)
        {
            try
            {
                List<ProductQuantity> quantities = new List<ProductQuantity>(products);
                for (int i = 0; i < quantities.Count; i++)
                {
                    AddProductWithCount(quantities[i]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddProductWithCount(ProductQuantity product)
        {
            try
            {
                return AddProductWithCount(product.ID, product.Quantity);
            }
            catch
            {
                return false;
            }
        }

        public bool AddProductWithCount(int id, int count)
        {
            try
            {
                return AddProductWithCount(id, count, ProductsList.GetListFromDB());
            }
            catch
            {
                return false;
            }
        }

        public bool AddProductWithCount(int id, int count, ProductsList products)
        {
            try
            {
                return AddProductWithCount(products.GetByID(id), count);
            }
            catch
            {
                return false;
            }
        }

        public bool SetProductsWithCountRange(SessionWithTraidingPoint products)
        {
            try
            {
                SetListChange(products.PointID, products.GetPounktType());
            }
            catch
            {

            }
            try
            {

                return SetProductsWithCountRange(products.Products);
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool SetProductCount(Product product, int count)
        {
            try
            {
                Get(IndexOfByID(product)).Quantity = count;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddProduct(int index)
        {
            try
            {
                int count = Get(index).Quantity;
                return SetProductCount(index, count + 1);
            }
            catch
            {
                return false;
            }
        }

        public bool SubstractProduct(int index)
        {
            try
            {
                int count = Get(index).Quantity;
                return SetProductCount(index, count - 1);
            }
            catch
            {
                return false;
            }
        }

        public bool SubstractProduct(Product index)
        {
            try
            {
                int count = GetByID(index).Quantity;
                return SetProductCount(index, count - 1);
            }
            catch
            {
                return false;
            }
        }

        Session session = new Session();

        public Session Session
        {
            get => session;
            set => session = value;
        }

        ShoppingCartSession orderSession = new ShoppingCartSession();

        public ShoppingCartSession OrderSession
        {
            get => orderSession;
            set => orderSession = value;
        }

        public bool ContainsByIndex(int index) => GetAbstractThis().Any(p => p.Index == index);

        public bool ContainsByIndex(ProductInShoppingCart product) => ContainsByIndex(product.Index);

        public ProductInShoppingCart GetByIndex(int index) => Find(p => p.Index == index);
        public ProductInShoppingCart GetByIndex(ProductInShoppingCart product) => GetByIndex(product.Index);

        ProductsList products = new ProductsList();

        public ProductsList Products
        {
            get => products;
            set => products = value;
        }

        PounktType pounktType = PounktType.All;

        public PounktType PounktType
        {
            get => pounktType;
            set => pounktType = value;
        }

        TradingPoint tradingPoint = new TradingPoint();

        public TradingPoint TradingPoint
        {
            get => tradingPoint;
            set => tradingPoint = value;
        }

        int pounktID = 0;

        public int PounktID
        {
            get => TradingPoint.ID;
            set => TradingPoint.ID = value;
        }

        public Stock GetStock()
        {
            return TradingPoint.Stock;
        }


        public void SetListChange(int pounktID, PounktType pounktType = PounktType.All)
        {
            if(pounktID == 0)
            {
                TradingPoint = new TradingPoint();
                PounktType = PounktType.All;
            }
            else
            {
                try
                {
                    TradingPoint = TradingPointsController.GetController().GetTradingPoints().GetByID(pounktID);
                    PounktType = pounktType;
                    pounktID = TradingPoint.ID;
                }
                catch
                {
                    SetListChange(0);
                }
            }
            
            SetListChange();
        }

        public void SetListChange()
        {
            if (PounktID < 1)
                PounktType = PounktType.All;
            if (PounktType == PounktType.All)
                try
                {
                    Products.GetFromBD();
                }
                catch
                {
                    Products = ProductsList.GetListFromDB();
                }
            try
            {
                if (PounktType == PounktType.Shop)
                    Products.SetList(ProductsInPounktList.GetListFromDB(pounktType: PounktType, pounktID: PounktID));
                else
                {
                    Products.SetList(ProductsInPounktList.GetListFromDB(pounktType: PounktType, pounktID: GetStock().ID));
                }
            }
            catch
            {
                SetListChange(0);
            }
        }

        public void SetList()
        {
            ProductsList products = ProductsList.GetListFromDB();
            for (int i = 0; i < Count; i++)
            {
                ProductInShoppingCart product = this[i];
                product.SetProductByList(products);
            }
        }

        public void SetChange(int pounktID, PounktType pounktType = PounktType.All)
        {
            SetListChange(pounktID, pounktType);
            SetList();
        }



        public void SetChange()
        {
            SetListChange();
            SetList();
        }

        public int PositionCount => Count;

        public int Quantity
        {
            get
            {
                int quantity = 0;
                for(int i = 0; i < Count; i++)
                {
                    quantity += this[i].Quantity;
                }
                return quantity;
            }
        }

        public Part GetInfo()
        {
            return TradingPoint;

        }

        public bool Existence
        {
            get
            {
                if (PounktID < 1)
                    return false;
                if (PounktType == PounktType.All)
                    return false;
                if (PounktType == PounktType.Shop && !TradingPoint.ExistenceShop)
                    return false;
                if (PounktType == PounktType.Stock && !TradingPoint.ExistencePounktOfIssue)
                    return false;
                return true;
            }
        }

        public string ExistenceText
            => Existence ? "Допустим" : "Не допустим";


        public bool Mayby
        {
            get
            {
                try
                {
                    if (Count < 1)
                        return false;
                    if (!Existence)
                        return false;
                    if (!TradingPointsController.GetController().GetTradingPoints().ContainsByID(PounktID))
                        return false;
                    try
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            if (!this[i].Mayby)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }

            }
        }

        public double Coest
        {
            get
            {
                double coest = 0;

                for(int i =0; i < Count; i++)
                {
                    coest += Get(i).CoestWithOutDiscount;
                }

                return Math.Round(coest, 2);
            }
        }

        public double CoestWithDiscount
        {
            get
            {
                double coest = 0;

                for (int i = 0; i < Count; i++)
                {
                    coest += Get(i).CoestWithDiscount;
                }

                return Math.Round(coest, 2);
            }
        }

        public OrderCart GetOrderData()
        {
            OrderCart orderCart = new OrderCart();
            orderCart.MayBe = Mayby;
            orderCart.TraidingPointInfo = GetInfo();
            orderCart.TraidingPointID = PounktID;
            orderCart.Coest = Coest;
            orderCart.CoestWithDiscount = CoestWithDiscount;
            orderCart.Quantity = Quantity;
            orderCart.PositionsCount = PositionCount;
            orderCart.TraidingPoint = TraidingPointInfo();
            return orderCart;
        }

        public string TraidingPointInfo()
        {
            if (PounktType == PounktType.All || PounktID < 1) 
                return "Нет пункта для получения";
            else
            {
                if (PounktType == PounktType.Shop)
                {
                    return "Пункт получения: \n" +
                        "Магазин - \"" + TradingPoint.RegistrateData + $"\" ({ExistenceText})";
                }
                else
                {
                    return "Пункт получения: \n" +
                       "Пункт выдачи - \"" + TradingPoint.RegistrateData + $"\" ({ExistenceText})"; ;
                }
            }

        }

        public OrderWithOutNumber GetOrder()
            => new OrderWithOutNumber
            {
                Cost = this.Coest,
                CostWithDiscount = CoestWithDiscount
            };

        public ProductsInShoppingCartList GetThisWithChange()
        {
            SetChange();
            return this;
        }
    }
}
