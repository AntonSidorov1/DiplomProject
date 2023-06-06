using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product : Part
    {

        public virtual string GetNameInfo()
            => $"«{ID}»" + " - " + $"«{Articul.Trim()}»" + " - " + $"«{Name}»" + " - " +
            $"«{PriceWithDiscount.ToString("c2")}»" + $" («{PriceWithOutDiscount.ToString("C2")}»)";

        public string NameIfon => GetNameInfo();


        string articul = "";

        /// <summary>
        /// Артикул
        /// </summary>
        public string Articul
        {
            get => articul;
            set => articul = value;
        }

        string description = "";

        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get => description;
            set => description = value;
        }

        Part category = new Part();

        /// <summary>
        /// Категория
        /// </summary>
        public Part Category
        {
            get => category;
            set => category = value;
        }

        Part supplier = new Part();

        /// <summary>
        /// Поставщик
        /// </summary>
        public Part Supplier
        {
            get => supplier;
            set => supplier = value;
        }

        Part manufacture = new Part();

        /// <summary>
        /// Производитель
        /// </summary>
        public Part Manufacture
        {
            get => manufacture;
            set => manufacture = value;
        }

        double priceWithOutDiscount = 0;

        /// <summary>
        /// Цена без скидки
        /// </summary>
        public double PriceWithOutDiscount
        {
            get => priceWithOutDiscount;
            set => priceWithOutDiscount = value;
        }

        int discount = 0;

        /// <summary>
        /// Скидка
        /// </summary>
        public int Discount
        {
            get => discount;
            set => discount = value;
        }

        /// <summary>
        /// Цена со скидкой
        /// </summary>
        public double PriceWithDiscount
        {
            get => Math.Round(PriceWithOutDiscount - PriceWithOutDiscount * (Discount / 100.0), 2);
            set => PriceWithOutDiscount = value / ((100 - Discount) / 100.0);
        }

        string photo = "";

        public string Photo
        {
            get => photo;
            set => photo = value;
        }

        public void SetPhoto(byte[] photo)
        {
            Photo = Convert.ToBase64String(photo);
        }

        /// <summary>
        /// Информация о товаре
        /// </summary>
        public string Information => ToString();

        public override string ToString() => GetData();


        public virtual string GetData()
        {
            string result = $"Название - {Name} \n";
            if (Description.Length > 30)
            {
                result += $"Описание - {Description.Substring(0, 30)}... \n";
            }
            else
            {
                result += $"Описание - {Description} \n";
            }
            result += $"Цена без скидки - {PriceWithOutDiscount.ToString("C2")}\n";
            result += $"Скидка - {(Discount / 100.0).ToString("0%")}\n";
            result += $"Цена со скидкой - {PriceWithDiscount.ToString("C2")}";

            return result;
        }

        public virtual Product CopyProduct()
        {
            Product product = new Product();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }

        public void SetProduct(Product product)
        {
            
            ID = product.ID;
            Articul = product.Articul;
            Category = product.Category.CopyPart();
            Manufacture = product.Manufacture.CopyPart();
            Supplier = product.Supplier.CopyPart();
            PriceWithOutDiscount = product.PriceWithOutDiscount;
            Discount = product.Discount;
            Description = product.Description;
            Photo = product.Photo;
            Name = product.Name;
        }

        public void SetProductByList(IEnumerable<Product> products)
        {
            ProductsList result = new ProductsList(products);
            if (result.ContainsByID(this))
            {
                SetProduct(result.GetByID(this));
            }
        }

        public virtual ProductInPounkt CopyProductInPounkt(PounktType pounktType = PounktType.Shop)
        {
            ProductInPounkt product = new ProductInPounkt();
            product.ID = this.ID;
            product.Name = this.Name;
            product.Articul = this.Articul;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;
            product.SetPounktType(pounktType);

            return product;
        }

        public virtual ProductInShoppingCart CopyProductInShoppingCart()
        {
            ProductInShoppingCart product = new ProductInShoppingCart();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Name = this.Name;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }


        public virtual ProductWithCount CopyProductWithCount()
        {
            ProductWithCount product = new ProductWithCount();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Name = this.Name;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }

        public virtual ProductInOrder CopyProductToOrder()
        {
            ProductInOrder product = new ProductInOrder();
            product.ID = this.ID;
            product.Articul = this.Articul;
            product.Name = this.Name;
            product.Category = this.Category.CopyPart();
            product.Manufacture = this.Manufacture.CopyPart();
            product.Supplier = this.Supplier.CopyPart();
            product.PriceWithOutDiscount = this.PriceWithOutDiscount;
            product.Discount = this.Discount;
            product.Description = this.Description;
            product.Photo = this.Photo;

            return product;
        }

        public virtual ProductInOrder CopyProductToOrder(int quantity)
        {
            ProductInOrder product = CopyProductToOrder();
            product.Quantity = quantity;
            return product;
        }




        public virtual ProductWithCount CopyProductWithCount(int quantity)
        {
            ProductWithCount product = CopyProductWithCount();
            product.Quantity = quantity;
            return product;
        }

        public virtual ProductInShoppingCart CopyProductInShoppingCart(int quantity)
        {
            ProductInShoppingCart product = CopyProductInShoppingCart();
            product.Quantity = quantity;
            return product;
        }

        public bool IsInPounkt() => this is ProductInPounkt;
        public ProductInPounkt AsInPounkt() => this as ProductInPounkt;

        public bool IsWithCounkt() => this is ProductWithCount;
        public ProductWithCount AsWithCounkt() => this as ProductWithCount;

        public bool IsInOrder() => this is ProductInOrder;
        public ProductInOrder AsInOrder() => this as ProductInOrder;

        public ProductInPounkt CopyProductInPounkt(int quantity, PounktType pounktType = PounktType.Shop)
        {
            ProductInPounkt product = CopyProductInPounkt(pounktType);
            product.Quantity = quantity;
            return product;
        }

        public ProductInPounkt CopyProductInPounkt(ProductWithCount product, PounktType pounktType = PounktType.Shop)
        {
            return CopyProductInPounkt(product.Quantity, pounktType);
        }

        public ProductInPounkt CopyProductInPounkt(ProductInPounkt product)
            => CopyProductInPounkt(product, product.GetPounktType());

        public ProductInPounkt CopyProductInPounkt(IEnumerable<ProductInPounkt> products, PounktType pounktType = PounktType.Shop)
        {
            ProductsInPounktList pounkts = new ProductsInPounktList(products);
            try
            {
                return CopyProductInPounkt(pounkts.GetByID(this));
            }
            catch
            {
                return CopyProductInPounkt(pounktType);
            }

        }



    }
}
