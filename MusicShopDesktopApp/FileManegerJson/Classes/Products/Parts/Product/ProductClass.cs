using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Производитель товара
    /// </summary>
    [DataContract]
    public class ProductClass : ProductParameter
    {
        public ProductClass()
        {
        }

        public ProductClass(string name) : base(name)
        {
        }

        public ProductClass(ProductParameter parameter) : base(parameter)
        {
        }

        public override void SetParameter(ProductParameter parameter)
        {
            base.SetParameter(parameter);
            if(parameter is ProductClass)
            {
                ProductClass product = parameter as ProductClass;
                Articul = product.Articul;
                Description = product.Description;
                Category = product.Category;
                Manufacture = product.Manufacture;
                Supplier = product.Supplier;
                Photo = product.Photo;
                Discount = product.Discount;
                Price = product.Price;
            }

        }

        public static ProductClass LoadJsonFile(string jsonName)
        {
            ProductClass category = new ProductClass();
            category.LoadJson(jsonName);
            return category;
        }

        int discount = 0;

        /// <summary>
        /// Скидка
        /// </summary>
        [DataMember]
        public int Discount
        {
            get => discount;
            set => discount = value;
        }

        double price = 0;

        /// <summary>
        /// Цена без скидки
        /// </summary>
        [DataMember]
        public double Price
        {
            get => price;
            set => price = value;
        }

        /// <summary>
        /// Вещественная скидка
        /// </summary>
        public double DiscountReal
        {
            get => Discount / 100.0;
            set => Discount = (int)(value * 100);
        }

        /// <summary>
        /// Сумма скидки
        /// </summary>
        public double DiscountSum
        {
            get => Price * DiscountReal;
            set => DiscountReal = value / Price;
        }

        /// <summary>
        /// Цена со скидкой
        /// </summary>
        public double PriceWithDiscount
        {
            get => Price - DiscountSum;
            set => Price = value + DiscountSum;
        }

        string articul = "";

        /// <summary>
        /// Артикул
        /// </summary>
        [DataMember]
        public string Articul
        {
            get => articul;
            set => articul = value;
        }

        string description = "";

        /// <summary>
        /// Описание
        /// </summary>
        [DataMember]
        public string Description
        {
            get => description;
            set => description = value;
        }

        string category = "";

        /// <summary>
        /// Категория
        /// </summary>
        [DataMember]
        public string Category
        {
            get => category;
            set => category = value;
        }

        string manufacture = "";

        /// <summary>
        /// Производитель
        /// </summary>
        [DataMember]
        public string Manufacture
        {
            get => manufacture;
            set => manufacture = value;
        }

        string supplier = "";

        /// <summary>
        /// Поставщик
        /// </summary>
        [DataMember]
        public string Supplier
        {
            get => supplier;
            set => supplier = value;
        }


        string photo = "";

        /// <summary>
        /// Изображение товара
        /// </summary>
        [DataMember]
        public string Photo
        {
            get => photo;
            set => photo = value;
        }

        public void SetPhoto(byte[] photo)
        {
            Photo = Convert.ToBase64String(photo);
        }

        public byte[] BytesPhoto
        {
            get => Convert.FromBase64String(Photo);
            set => SetPhoto(value);
        }

        public Bitmap Bitmap
        {
            get
            {
                MemoryStream memory = new MemoryStream(BytesPhoto);
                Bitmap bitmap = new Bitmap(memory);
                memory.Close();
                return bitmap;
            }
            set
            {
                MemoryStream memory = new MemoryStream();
                value.Save(memory, ImageFormat.Jpeg);
                BytesPhoto = memory.ToArray();
                memory.Close();
            }
        }

        public Image Image
        {
            get => Bitmap;
            set => Bitmap = new Bitmap(value);
        }

        public Image ImageOutput
        {
            get
            {
                if (HaveImage)
                    return Image;
                else
                    return new Bitmap(100, 100);
            }
        }


        public bool HaveImage
        {
            get
            {
                try
                {
                    Bitmap bitmap = new Bitmap(Image);
                    return true;
                }
                catch (ArgumentNullException e)
                {
                    return false;
                }
                catch (NullReferenceException e)
                {
                    return false;
                }
                catch (ArgumentException e)
                {
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool NoHaveImage => !HaveImage;


    }
}
