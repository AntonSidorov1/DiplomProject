using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MusicShopDesktopApp
{
    public partial class ProductInTraidingPoint : Form
    {

        Product product = new Product();
        Stock stock = new Stock();
        TradingPoint shop = new TradingPoint();
        public new void Show()
        {
            base.Show();
            timerUpdate.Start();
        }

        public new void Hide()
        {
            timerUpdate.Stop();
            base.Hide();
        }

        public new void Close()
        {
            Hide();
            base.Close();
        }

        public ProductInTraidingPoint()
        {
            InitializeComponent();
        }

        public ProductInTraidingPoint(Product product, Stock stock, TradingPoint shop) : this()
        {
            this.product = product;
            this.shop = shop;
            this.stock = stock;
        }



        string text = "";

        string textID => text + " " + product.ID + " " + product.Articul.Trim();

        private void Model_Load(object sender, EventArgs e)
        {
            text = Text;
            this.Text = textID+ " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            UpdateView();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string date = now.ToLongDateString();
            string time = now.ToLongTimeString();
            toolStripStatusLabelDate.Text = date;
            toolStripStatusLabelTime.Text = time;
        }

        bool UpdateView()
        {
            timerUpdate.Stop();

            if (!UpdateForm())
                return false;

            timerUpdate.Start();
            return true;
        }

        bool UpdateForm()
        {
            try
            {
                product = ProductsList.GetListFromDB().GetByID(product);
                labelNameInfo.Text = product.NameInfo;
            }
            catch
            {
                MessageBox.Show("Данного товара больше не существует", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            this.Text = textID + " - " + Application.ProductName + " - " + Application.ProductVersion;
            notifyIconApp.Text = Text;
            labelTitle.Text = textID;


            if (Helper.UserIsGoest())
            {
                MessageBox.Show("Вы больше не авторизированы", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            if (!Helper.GetAccount().IsOrdersManager())
            {
                MessageBox.Show("Необходима роль менеджера по складу или администратора",
                    "Редактирование  позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            StocksList stocks = StocksList.GetList();
            try
            {
                stocks.GetFromBD();
                stock = stocks.GetByID(stock).CopyStock();
            }
            catch
            {

            }
            if(!stocks.ContainsByID(stock))
            {
                MessageBox.Show("Склада или магазина больше не существует",
                    "Редактирование  позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            TradingPointsList shops = new TradingPointsList();
            try
            {
                shops.GetFromBD();
                shop = shops.GetByID(shop).CopyPoint();
            }
            catch
            {

            }
            bool visible = shops.ContainsByID(shop);
            panelShop.Visible = visible;
            buttonToShop.Visible = visible;

            labelStock.Text = "Склад: " + stock.Name;
            try
            {
                textInputStockNow.Text = product.GetCountInStock(stockID).ToString();
            }
            catch
            {
                textInputStockNow.Text = "";
            }

            labelShop.Text = "Магазин: " + shop.Name;
            try
            {
                textInputShopNow.Text = product.GetCountInShop(shopID).ToString();
            }
            catch
            {
                textInputShopNow.Text = "";
            }



            return true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        int shopID => shop.ID;
        int stockID => stock.ID;

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            MessageBox.Show(stock.Data, "Склад", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timerUpdate.Start();
        }

        private void buttonStockAdd_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                product.AddToStock(stockID);
            }
            catch
            {

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonStocSub_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                product.SubToStock(stockID);
            }
            catch
            {

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                product.SetProductToStock(stockID, 0);
            }
            catch
            {

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Редактирование позиции товара", textInputStockNow.Text);
                if(!product.SetProductToStock(stockID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Количество товара успешно изменено", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно задать введённое количество товара", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonShop_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            MessageBox.Show(shop.Data, "Магазин", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timerUpdate.Start();
        }

        private void buttonShopAdd_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                product.AddToShop(shopID);
            }
            catch
            {

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonShopSub_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                product.SubToShop(shopID);
            }
            catch
            {

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonShopClear_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                product.SetProductToShop(shopID, 0);
            }
            catch
            {

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonShopSet_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Редактирование позиции товара", textInputShopNow.Text);
                if (!product.SetProductToShop(shopID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Количество товара успешно изменено", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно задать введённое количество товара", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonToStock_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Перенаправление товара", "0");
                if (!product.RunFromShopToStock(shopID, stockID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Товар успешно перенаправлен", "Перенаправление товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно перенаправить товар", "Перенаправление товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonToShop_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Перенаправление товара", "0");
                if (!product.RunFromStockToShop(stockID, shopID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Товар успешно перенаправлен", "Перенаправление товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно перенаправить товар", "Перенаправление товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonAddToStock_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Редактирование позиции товара", "0");
                if (!product.AddToStock(stockID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Количество товара успешно изменено", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно добавить введённое количество товара", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonAddToDB_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Редактирование позиции товара", "0");
                if (!product.AddToShop(shopID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Количество товара успешно изменено", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно добавить введённое количество товара", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonDropFromStock_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Редактирование позиции товара", "0");
                if (!product.SubToStock(stockID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Количество товара успешно изменено", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно убрать введённое количество товара", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonDropFromShop_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                string quantity = Interaction.InputBox("Введите количество товара", "Редактирование позиции товара", "0");
                if (!product.SubToShop(shopID, Convert.ToInt32(quantity)))
                {
                    throw new Exception();
                }
                MessageBox.Show("Количество товара успешно изменено", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Невозможно убрать введённое количество товара", "Редактирование позиции товара", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }
    }
}
