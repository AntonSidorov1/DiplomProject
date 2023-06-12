using FileManegerJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public partial class ProductEditForm : Form
    {
        public ProductEditForm() : this(new Product())
        {
            
        }

        Product product = new Product();
        string text = "";

        public ProductEditForm(Product product) 
        {
            InitializeComponent();

            this.product = product;

            if (product.ID < 1)
            {
                product.ID = 0;
            }

            text = Text;

            Text = text + $" {product.ID}";
            labelTitle.Text = text + $" {product.ID}";
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            if(product.ID < 1)
            {
                textInputArticul.ReadOnly = false;
                UpdateParts();
                return;
            }

            UpdateProduct();


            timerUpdate.Stop();

            setPoints();

            timerUpdate.Start();
        }

        void setPoints()
        {

            try
            {
                try
                {
                    comboBoxWithNameSity.SelectedIndex = sities.IndexOfByID(Helper.TraidHelper.Sity);
                    if (comboBoxWithNameSity.SelectedIndex < 0)
                        throw new Exception();
                }
                catch
                {
                    comboBoxWithNameSity.SelectedIndex = 0;
                }
            }
            catch
            {

            }

            try
            {
                try
                {
                    comboBoxWithNameOrganization.SelectedIndex = organizations.IndexOfByID(Helper.TraidHelper.Organization);
                    if (comboBoxWithNameOrganization.SelectedIndex < 0)
                        throw new Exception();
                }
                catch
                {
                    comboBoxWithNameOrganization.SelectedIndex = 0;
                }
            }
            catch
            {

            }

            try
            {
                try
                {
                    comboBoxWithNameStock.SelectedIndex = stocks.IndexOfByID(Helper.TraidHelper.Stock);
                    if (comboBoxWithNameStock.SelectedIndex < 0)
                        throw new Exception();
                }
                catch
                {
                    comboBoxWithNameStock.SelectedIndex = 0;
                }
            }
            catch
            {

            }

            try
            {
                try
                {
                    comboBoxWithNameShops.SelectedIndex = shops.IndexOfByID(Helper.TraidHelper.TradingPoint);
                    if (comboBoxWithNameShops.SelectedIndex < 0)
                        throw new Exception();
                }
                catch
                {
                    comboBoxWithNameShops.SelectedIndex = 0;
                }
            }
            catch
            {

            }

            try
            {
                try
                {
                    comboBoxWithNamePointOfIssue.SelectedIndex = pointsOfissue.IndexOfByID(Helper.TraidHelper.TradingPoint);
                    if (comboBoxWithNamePointOfIssue.SelectedIndex < 0)
                        throw new Exception();
                }
                catch
                {
                    comboBoxWithNamePointOfIssue.SelectedIndex = 0;
                }
            }
            catch
            {

            }

        }

        bool updatePart = false;

        public new void Show()
        {
            base.Show();
            if (!updatePart && product.ID > 0)
            {
                UpdateProduct();
                timerUpdate.Start();

            }
            else
            {
                timerUpdateParts.Start();
                UpdateParts();
            }
        }

        public new void Hide()
        {
            timerUpdate.Stop();
            timerUpdateParts.Stop();
            base.Hide();
        }

        public new void Close()
        {
            Hide();
            base.Close();
        }

        bool SetProduct()
        {
            try
            {
                try
                {
                    product = ProductsController.GetController().GetProduct(Helper.GetSession(), product.ID);
                    return product.ID >= 0;
                }
                catch (NullReferenceException e)
                {
                    throw e;
                }
                catch (ArgumentException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;

                }
            }
            catch
            {
                return false;
            }
        }


        bool updatingPart => timerUpdateParts.Enabled;

        CategoriesList categories = new CategoriesList();
        SuppliersList suppliers = new SuppliersList();
        ManufacturesList manufactures = new ManufacturesList();
        void UpdateProduct()
        {
            menuStripDescription.Visible = false;
            updatePart = false;
            timerUpdate.Stop();
            buttonEdit.Visible = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            textInputArticul.ReadOnly = true;
            SetReadOnly(true);

            if(!SetProduct())
            {
                MessageBox.Show("Данного товара больше не существует", "Просмтотр товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            SetSities();
            SetOrganizations();

            Text = text + $" {product.ID}";
            labelTitle.Text = text + $" {product.ID}";
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;


            menuStripParts.Visible = Helper.GetAccount().IsStockManager();
            menuStripEdit.Visible = Helper.GetAccount().IsStockManager();

            textInputArticul.Text = product.Articul;

            try
            {
                pictureBoxImage.Image = product.Image;
            }
            catch
            {
                pictureBoxImage.Image = Properties.Resources.Logotip1;
            }

            textInputName.Text = product.Name;
            textInputPriceWithOutDiscount.Value = Convert.ToDecimal(product.PriceWithOutDiscount);
            textInputDiscount.Value = Convert.ToDecimal(product.Discount);

            textInputPriceWithDiscount.Text = product.PriceWithDiscount.ToString("C2");
            textInputDescription.Text = product.Description;

            try
            {
                categories.GetFromBD();
                comboBoxWithNameCategories.Items.Clear();
                categories.RemoveAllByID(0);
                for(int i = 0; i < categories.Count; i++)
                {
                    comboBoxWithNameCategories.Items.Add(categories[i].Name);
                }
                comboBoxWithNameCategories.SelectedIndex = categories.IndexOfByID(product.Category.ID);
            }
            catch
            {

            }

            try
            {
                suppliers.GetFromBD();
                comboBoxWithNameSupplier.Items.Clear();
                suppliers.RemoveAllByID(0);
                for (int i = 0; i < suppliers.Count; i++)
                {
                    comboBoxWithNameSupplier.Items.Add(suppliers[i].Name);
                }
                comboBoxWithNameSupplier.SelectedIndex = suppliers.IndexOfByID(product.Supplier);
            }
            catch
            {

            }

            try
            {
                manufactures.GetFromBD();
                comboBoxManufacture.Items.Clear();
                manufactures.RemoveAllByID(0);
                for (int i = 0; i < manufactures.Count; i++)
                {
                    comboBoxManufacture.Items.Add(manufactures[i].Name);
                }
                comboBoxManufacture.SelectedIndex = manufactures.IndexOfByID(product.Manufacture);
            }
            catch
            {

            }

            if(!Helper.ShoppingCarts.ContainsByID(product))
            {
                numericControlWithNameCart.Value = 0;
            }
            else
            {
                numericControlWithNameCart.Value = Helper.ShoppingCarts.GetByID(product).Quantity;
            }

            timerUpdate.Start();
        }

        SitiesList sities = new SitiesList();
        void SetSities()
        {
            try
            {
                int index = 0;
                try
                {
                    index = comboBoxWithNameSity.SelectedIndex;
                    if (index < 0)
                        index = 0;
                }
                catch
                {
                    index = 0;
                }
                int id = 0;
                try
                {
                    id = sities[index].ID;
                }
                catch
                {
                    id = 0;
                }

                sities = SitiesController.GetController().GetSities(Helper.GetSession());
                

                comboBoxWithNameSity.Items.Clear();
                comboBoxWithNameSity.Enabled = comboBoxWithNameSity.Items.Count > 0;
                for (int i = 0; i < sities.Count; i++)
                {
                    comboBoxWithNameSity.Items.Add(sities[i].Name);
                }

                comboBoxWithNameSity.Enabled = comboBoxWithNameSity.Items.Count > 0;
                index = 0;
                try
                {
                    index = sities.IndexOfByID(id);
                    if (index < 0)
                        index = 0;
                }
                catch
                {
                    index = 0;
                }

                try
                {
                    comboBoxWithNameSity.SelectedIndex = index;
                }
                catch
                {
                    comboBoxWithNameSity.SelectedIndex = 0;
                }

            }
            catch
            {

            }
            comboBoxWithNameSity.Enabled = comboBoxWithNameSity.Items.Count > 0;
        }

        OrganizationsList organizations = new OrganizationsList();
        void SetOrganizations()
        {
            try
            {
                int index = 0;
                try
                {
                    index = comboBoxWithNameOrganization.SelectedIndex;
                    if (index < 0)
                        index = 0;
                }
                catch
                {
                    index = 0;
                }
                int id = 0;
                try
                {
                    id = organizations[index].ID;
                }
                catch
                {
                    id = 0;
                }

                organizations = OrganizationsController.GetController().GetOrganizations(Helper.GetSession());


                comboBoxWithNameOrganization.Items.Clear();
                comboBoxWithNameOrganization.Enabled = comboBoxWithNameOrganization.Items.Count > 0;
                for (int i = 0; i < organizations.Count; i++)
                {
                    comboBoxWithNameOrganization.Items.Add(organizations[i].Name);
                }
                comboBoxWithNameOrganization.Enabled = comboBoxWithNameOrganization.Items.Count > 0;

                index = 0;
                try
                {
                    index = organizations.IndexOfByID(id);
                    if (index < 0)
                        index = 0;
                }
                catch
                {
                    index = 0;
                }

                try
                {
                    comboBoxWithNameOrganization.SelectedIndex = index;
                }
                catch
                {
                    comboBoxWithNameOrganization.SelectedIndex = 0;
                }

            }
            catch
            {

            }
            comboBoxWithNameOrganization.Enabled = comboBoxWithNameOrganization.Items.Count > 0;
        }

        StocksList stocks = new StocksList();
        void SetStocks()
        {
            try
            {
                int sity = 0;
                try
                {
                    sity = comboBoxWithNameSity.SelectedIndex;
                    if (sity < 0)
                        sity = 0;
                }
                catch
                {
                    sity = 0;
                }
                try
                {
                    sity = sities[sity].ID;
                }
                catch
                {
                    sity = 0;
                }

                if(sity < 1)
                {
                    comboBoxWithNameStock.Items.Clear();
                    throw new Exception();
                }

                int index = 0;
                try
                {
                    index = comboBoxWithNameStock.SelectedIndex;
                    if (index < 0)
                        index = 0;
                }
                catch
                {
                    index = 0;
                }
                int id = 0;
                try
                {
                    id = stocks[index].ID;
                }
                catch
                {
                    id = 0;
                }

                stocks = StocksController.GetController().GetStocks(Helper.GetSession(), sity);


                comboBoxWithNameStock.Items.Clear();
                comboBoxWithNameStock.Enabled = comboBoxWithNameStock.Items.Count > 0;
                for (int i = 0; i < stocks.Count; i++)
                {
                    comboBoxWithNameStock.Items.Add(stocks[i].ItemData);
                }
                comboBoxWithNameStock.Enabled = comboBoxWithNameStock.Items.Count > 0;

                index = 0;
                try
                {
                    index = stocks.IndexOfByID(id);
                    if (index < 0)
                        index = 0;
                }
                catch
                {
                    index = 0;
                }

                try
                {
                    comboBoxWithNameStock.SelectedIndex = index;
                }
                catch
                {
                    comboBoxWithNameStock.SelectedIndex = 0;
                }

            }
            catch
            {

            }
            comboBoxWithNameStock.Enabled = comboBoxWithNameStock.Items.Count > 0;
            menuStripQuantity.Visible = comboBoxWithNameStock.Enabled && Helper.GetAccount().IsStockManager();
        }

        TradingPointsList shops = new TradingPointsList();
        TradingPointsList pointsOfissue = new TradingPointsList();
        void SetPoints()
        {
            try
            {
                int sity = 0;
                try
                {
                    sity = comboBoxWithNameSity.SelectedIndex;
                    if (sity < 0)
                        sity = 0;
                }
                catch
                {
                    sity = 0;
                }
                try
                {
                    sity = sities[sity].ID;
                }
                catch
                {
                    sity = 0;
                }

                if (sity < 1)
                {
                    comboBoxWithNameShops.Items.Clear();
                    comboBoxWithNamePointOfIssue.Items.Clear();
                    throw new Exception();
                }
                int stock = 0;
                try
                {
                    stock = comboBoxWithNameStock.SelectedIndex;
                    if (stock < 0)
                        stock = 0;
                }
                catch
                {
                    stock = 0;
                }
                try
                {
                    stock = stocks[stock].ID;
                }
                catch
                {
                    stock = 0;
                }

                if (stock < 1)
                {
                    comboBoxWithNameShops.Items.Clear();
                    comboBoxWithNamePointOfIssue.Items.Clear();
                    throw new Exception();
                }
                int org = 0;
                try
                {
                    org = comboBoxWithNameOrganization.SelectedIndex;
                    if (org < 0)
                        org = 0;
                }
                catch
                {
                    org = 0;
                }
                try
                {
                    org = organizations[org].ID;
                }
                catch
                {
                    org = 0;
                }

                if (org < 1)
                {
                    comboBoxWithNameShops.Items.Clear();
                    comboBoxWithNamePointOfIssue.Items.Clear();
                    throw new Exception();
                }


                int shop = 0;
                try
                {
                    shop = comboBoxWithNameShops.SelectedIndex;
                    if (shop < 0)
                        shop = 0;
                }
                catch
                {
                    shop = 0;
                }
                try
                {
                    shop = shops[shop].ID;
                }
                catch
                {
                    shop = 0;
                }

                int pointOfIssue = 0;
                try
                {
                    pointOfIssue = comboBoxWithNamePointOfIssue.SelectedIndex;
                    if (pointOfIssue < 0)
                        pointOfIssue = 0;
                }
                catch
                {
                    pointOfIssue = 0;
                }
                try
                {
                    pointOfIssue = pointsOfissue[pointOfIssue].ID;
                }
                catch
                {
                    pointOfIssue = 0;
                }
                comboBoxWithNameShops.Items.Clear();
                comboBoxWithNamePointOfIssue.Items.Clear();

                TradingPointsList points = TradingPointsController.GetController()
                    .GetTradingPoints(Helper.GetSession(), sity, stock, org);

                try
                {
                    shops = points.GetShops();
                    for (int i = 0; i < shops.Count; i++)
                    {
                        comboBoxWithNameShops.Items.Add(shops[i].ItemData);
                    }
                }
                catch
                {

                }

                try
                {
                    pointsOfissue = points.GetPounktsOfIssue();
                    for (int i = 0; i < pointsOfissue.Count; i++)
                    {
                        comboBoxWithNamePointOfIssue.Items.Add(pointsOfissue[i].ItemData);
                    }
                }
                catch
                {

                }

                try
                {
                    try
                    {
                        shop = shops.IndexOfByID(shop);
                        if (shop < 0)
                            shop = 0;
                    }
                    catch
                    {
                        shop = 0;
                    }

                    try
                    {
                        comboBoxWithNameShops.SelectedIndex = shop;
                    }
                    catch
                    {
                        comboBoxWithNameShops.SelectedIndex = 0;
                    }
                }
                catch
                {

                }

                try
                {
                    try
                    {
                        pointOfIssue = pointsOfissue.IndexOfByID(pointOfIssue);
                        if (pointOfIssue < 0)
                            pointOfIssue = 0;
                    }
                    catch
                    {
                        pointOfIssue = 0;
                    }

                    try
                    {
                        comboBoxWithNamePointOfIssue.SelectedIndex = pointOfIssue;
                    }
                    catch
                    {
                        comboBoxWithNamePointOfIssue.SelectedIndex = 0;
                    }
                }
                catch
                {

                }

            }
            catch(Exception e)
            {
                
            }
            comboBoxWithNameShops.Enabled = comboBoxWithNameShops.Items.Count > 0;
            comboBoxWithNamePointOfIssue.Enabled = comboBoxWithNamePointOfIssue.Items.Count > 0;
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            menuStripDescription.Visible = updatePart && Helper.GetAccount().IsStockManager();
            if (!updatePart && product.ID > 0)
                UpdateProduct();
            else
                UpdateParts();
            timerEditVieFewWindow_Tick(sender, e);
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            buttonUpdate_Click(sender, e);
        }

        private void comboBoxWithNameSity_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            try
            {
                SetStocks();
            }
            catch
            {

            }

            try
            {
                SetPoints();
            }
            catch
            {

            }
        }

        private void comboBoxWithNameShops_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            setQuantityInShop();
            setQuantityInStock();
        }

        void setQuantityInShop()
        {
            try
            {
                if (comboBoxWithNameShops.Items.Count < 1)
                    throw new Exception();
                int index = comboBoxWithNameShops.SelectedIndex;
                int id = shops[index].ID;

                ProductInPounkt productInShop = ProductsInShopsController.GetController().GetProduct(Helper.GetSession(), product.ID, id);
                numericControlWithNameShop.Value = Convert.ToDecimal(productInShop.Quantity);
                textBoxShop.Text = productInShop.QuantityText;
            }
            catch(Exception e)
            {
                numericControlWithNameShop.Value = 0;
                textBoxShop.Text = "";

            }
        }

        private void comboBoxWithNamePointOfIssue_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            
        }

        private void comboBoxWithNameStock_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            try
            {
                SetPoints();
            }
            catch
            {

            }

            setQuantityInStock();
            setQuantityInShop();
        }

        void setQuantityInStock()
        {

            try
            {
                if (comboBoxWithNameStock.Items.Count < 1)
                    throw new Exception();
                int index = comboBoxWithNameStock.SelectedIndex;
                int id = stocks[index].ID;

                ProductInPounkt productInStock = ProductsInStocksController.GetController().GetProduct(Helper.GetSession(), product.ID, id);
                numericControlWithNameStock.Value = Convert.ToDecimal(productInStock.Quantity);
                textBoxStock.Text = productInStock.QuantityText;
            }
            catch (Exception e)
            {
                numericControlWithNameStock.Value = 0;
                textBoxStock.Text = "";

            }
        }

        private void comboBoxWithNameOrganization_SelectedIndexChanged(object arg1, EventArgs arg2)
        {

            try
            {
                SetPoints();
            }
            catch
            {

            }
        }

        private void numericControlWithNameStock_ValueChanged(object arg1, EventArgs arg2)
        {

        }

        private void resizePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonGetPoints_Click(object sender, EventArgs e)
        {
            TraidingPounktsForm form = new TraidingPounktsForm();
            Hide();
            form.ShowDialog();
            Show();
            setPoints();
        }

        private void buttonSetShop_Click(object sender, EventArgs e)
        {
            clear();
            SetDataPoint();

            try
            {
                Helper.TraidHelper.PounktType = PounktType.Stock;
                if (comboBoxWithNameShops.SelectedIndex >= 0)
                {
                    try
                    {
                        TradingPoint point = shops[comboBoxWithNameShops.SelectedIndex];
                        if (point.ExistenceShop)
                            Helper.TraidHelper.TradingPoint = point;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
            MessageOutput();

        }

        private void buttonSetPointOfIsssue_Click(object sender, EventArgs e)
        {
            clear();
            SetDataPoint();

            try
            {
                Helper.TraidHelper.PounktType = PounktType.Stock;
                if (comboBoxWithNamePointOfIssue.SelectedIndex >= 0)
                {
                    try
                    {
                        TradingPoint point = pointsOfissue[comboBoxWithNamePointOfIssue.SelectedIndex];
                        if (point.ExistencePounktOfIssue)
                            Helper.TraidHelper.TradingPoint = point;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
            MessageOutput();
        }


        void clear()
        {
            Helper.TraidHelper.Clear();
        }


        void MessageOutput()
        {
            MessageBox.Show("Торговый пункт успешно установлен", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);

            timerUpdate.Start();
        }

        void SetDataPoint()
        {
            timerUpdate.Stop();

            Helper.TraidHelper.Checked = true;

            if (comboBoxWithNameSity.SelectedIndex >= 0)
            {
                try
                {
                    Helper.TraidHelper.Sity = sities[comboBoxWithNameSity.SelectedIndex];
                }
                catch
                {

                }
            }

            if (comboBoxWithNameOrganization.SelectedIndex >= 0)
            {
                try
                {
                    Helper.TraidHelper.Organization = organizations[comboBoxWithNameOrganization.SelectedIndex];
                }
                catch
                {

                }
            }

            try
            {
                if (comboBoxWithNameStock.SelectedIndex >= 0)
                {
                    try
                    {
                        Helper.TraidHelper.Stock = stocks[comboBoxWithNameStock.SelectedIndex];
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.ShoppingCarts.AddProduct(product);

                MessageBox.Show("Товар успешно добавлен в корзину", "Добавление товара в корзину", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonUpdate_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Не удалось добавить товар в корзину", "Добавление товара в корзину", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void numericControlWithNameCart_ValueChanged(object arg1, EventArgs arg2)
        {
            timerUpdate.Stop();

            try
            {
                int quantity = Convert.ToInt32(numericControlWithNameCart.Value);
                if (!Helper.ShoppingCarts.ContainsByID(product))
                    Helper.ShoppingCarts.AddProduct(product);
                Helper.ShoppingCarts.SetProductCount(product, quantity);
            }
            catch
            {

            }

            timerUpdate.Start();
        }

        private void comboBoxWithNameCategories_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            Category category = new Category();
            try
            {
                category = categories.Get(comboBoxWithNameCategories.SelectedIndex);
            }
            catch
            {

            }
            textInputCategory.Text = category.Name;
            if (updatingPart)
                product.Category = category;
            textInputName_InputText_Changed(arg1, arg2);
        }

        public Category GetCategory()
        {
            Category category = new Category();
            try
            {
                category = categories.Get(comboBoxWithNameCategories.SelectedIndex);
            }
            catch
            {

            }
            return category;
        }

        private void comboBoxWithNameSupplier_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            Supplier supplier = new Supplier();
            try
            {
                supplier = suppliers.Get(comboBoxWithNameSupplier.SelectedIndex);
            }
            catch
            {

            }
            textInputSupplier.Text = supplier.Name;
            if (updatingPart)
                product.Supplier = supplier;
            textInputName_InputText_Changed(arg1, arg2);
        }

        public Supplier GetSupplier()
        {
            Supplier category = new Supplier();
            try
            {
                category = suppliers.Get(comboBoxWithNameSupplier.SelectedIndex);
            }
            catch
            {

            }
            return category;
        }

        private void comboBoxManufacture_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            Manufacture manufacture = new Manufacture();
            try
            {
                manufacture = manufactures.Get(comboBoxManufacture.SelectedIndex);
            }
            catch
            {

            }
            textInputManufacture.Text = manufacture.Name;
            if (updatingPart)
                product.Manufacture = manufacture;
            textInputName_InputText_Changed(arg1, arg2);
        }

        public Manufacture GetManufacture()
        {
            Manufacture category = new Manufacture();
            try
            {
                category = manufactures.Get(comboBoxManufacture.SelectedIndex);
            }
            catch
            {

            }
            return category;
        }

        private void textInputPriceWithOutDiscount_ValueChanged(object arg1, EventArgs arg2)
        {
            double price = 0;
            try
            {
                price = Convert.ToDouble(textInputPriceWithOutDiscount.Value);
            }
            catch
            {
                
            }
            textInputPrice.Text = price.ToString("C2");
            textInputName_InputText_Changed(arg1, arg2);
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            CategoriesEditForm categories = new CategoriesEditForm();
            Hide();
            categories.ShowDialog();
            Show();
        }

        private void buttonSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersEditForm categories = new SuppliersEditForm();
            Hide();
            categories.ShowDialog();
            Show();
        }

        private void производителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManufacturesEditForm categories = new ManufacturesEditForm();
            Hide();
            categories.ShowDialog();
            Show();
        }

        private void timerUpdateParts_Tick(object sender, EventArgs e)
        {
            UpdateParts();
        }

        void UpdateParts()
        {
            menuStripDescription.Visible = Helper.GetAccount().IsStockManager();
            timerUpdateParts.Stop();
            updatePart = true;
            buttonEdit.Visible = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            SetReadOnly(false);

            Text = text + $" {product.ID}";
            labelTitle.Text = text + $" {product.ID}";
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;


            textInputArticul.NoReadOnly = product.ID < 1;

            try
            {
                pictureBoxImage.Image = product.Image;
            }
            catch
            {
                pictureBoxImage.Image = Properties.Resources.Logotip1;
            }

            if (Helper.UserIsGoest())
            {
                MessageBox.Show("Вы больше не авторизированы", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                timerUpdate.Start();
                return;
            }
            if (!Helper.GetAccount().IsOrdersManager())
            {
                MessageBox.Show("Необходима роль менеджера по складу или администратора",
                    "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timerUpdate.Start();
                return;
            }


            try
            {
                int categoryID = 0;
                try
                {
                    categoryID = categories.Get(comboBoxWithNameCategories.SelectedIndex).ID;
                }
                catch
                {

                }
                categories.GetFromBD();
                comboBoxWithNameCategories.Items.Clear();
                categories.RemoveAllByID(0);
                for (int i = 0; i < categories.Count; i++)
                {
                    comboBoxWithNameCategories.Items.Add(categories[i].Name);
                }
                try
                {
                    categoryID = categories.IndexOfByID(categoryID);
                    if (categoryID > 0)
                        comboBoxWithNameCategories.SelectedIndex = categoryID;
                    else
                        throw new Exception();
                }
                catch
                {
                    try
                    {
                        comboBoxWithNameCategories.SelectedIndex = 0;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }

            try
            {
                int categoryID = 0;
                try
                {
                    categoryID = suppliers.Get(comboBoxWithNameSupplier.SelectedIndex).ID;
                }
                catch
                {

                }
                suppliers.GetFromBD();
                comboBoxWithNameSupplier.Items.Clear();
                suppliers.RemoveAllByID(0);
                for (int i = 0; i < suppliers.Count; i++)
                {
                    comboBoxWithNameSupplier.Items.Add(suppliers[i].Name);
                }
                try
                {
                    categoryID = suppliers.IndexOfByID(categoryID);
                    if (categoryID > 0)
                        comboBoxWithNameSupplier.SelectedIndex = categoryID;
                    else
                        throw new Exception();
                }
                catch
                {
                    try
                    {
                        comboBoxWithNameSupplier.SelectedIndex = 0;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }

            try
            {
                int categoryID = 0;
                try
                {
                    categoryID = manufactures.Get(comboBoxManufacture.SelectedIndex).ID;
                }
                catch
                {

                }
                manufactures.GetFromBD();
                comboBoxManufacture.Items.Clear();
                manufactures.RemoveAllByID(0);
                for (int i = 0; i < manufactures.Count; i++)
                {
                    comboBoxManufacture.Items.Add(manufactures[i].Name);
                }
                try
                {
                    categoryID = manufactures.IndexOfByID(categoryID);
                    if (categoryID > 0)
                        comboBoxManufacture.SelectedIndex = categoryID;
                    else
                        throw new Exception();
                }
                catch
                {
                    try
                    {
                        comboBoxManufacture.SelectedIndex = 0;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }

            timerUpdateParts.Start();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            timerUpdateParts.Start();
            UpdateParts();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            timerUpdateParts.Stop();
            timerUpdate.Start();
            UpdateProduct();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            comboBoxManufacture_SelectedIndexChanged(sender, e);
            comboBoxWithNameCategories_SelectedIndexChanged(sender, e);
            comboBoxWithNameSupplier_SelectedIndexChanged(sender, e);
            if (product.ID > 0)
            {
                if (product.UpdateInDB())
                {
                    MessageBox.Show("Товар успешно изменён", "Изменение товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось изменить товар", "Изменение товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ProductsList products = ProductsList.GetListFromDB();
                if(product.Articul.Length < 1)
                {
                    MessageBox.Show("Введите артикуль", "Добавление товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(products.ContainsByArticul(product))
                {
                    MessageBox.Show("Товар с данным артиклем уже существует", "Добавление товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (product.AddToDB())
                {
                    MessageBox.Show("Товар успешно добавлен", "Добавление товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    products = ProductsList.GetListFromDB();
                    product = products.GetByArticul(product);
                }
                else
                {
                    MessageBox.Show("Не удалось добавить товар", "Добавление товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            buttonCancel_Click(sender, e);
        }

        void SetReadOnly(bool readOnly)
        {
            textInputName.ReadOnly = readOnly;
            textInputDescription.ReadOnly = readOnly;
            textInputPriceWithOutDiscount.SetReadOnly(readOnly, 1);
            textInputDiscount.SetReadOnly(readOnly, 1);
            numericControlWithNameCart.Visible = readOnly;
            buttonAdd.Visible = readOnly;
            buttonUpdate.Visible = true;
            comboBoxManufacture.ReadOnly = readOnly;
            comboBoxWithNameCategories.ReadOnly = readOnly;
            comboBoxWithNameSupplier.ReadOnly = readOnly;
            comboBoxManufacture.ReadOnly = readOnly;
            tableLayoutPanelShop.Visible = readOnly;
            buttonDelete.Visible = readOnly && Helper.GetAccount().IsStockManager();
            menuStripPhotoEdit.Visible = !readOnly;

            bool set = false;
            try
            {
                set = product.HaveImage;
            }
            catch
            {

            }
            buttonImageSet.Visible = !set;
            buttonImageChange.Visible = set;
            buttonImageDrop.Visible = set;

            menuStripQuantity.Visible = Helper.GetAccount().IsStockManager();
        }

        private void textInputName_InputText_Changed(object arg1, EventArgs arg2)
        {
            if (!updatingPart)
                return;
            product.Name = textInputName.Text;
            product.Description = textInputDescription.Text;
            product.PriceWithOutDiscount = Convert.ToDouble(textInputPriceWithOutDiscount.Value);
            product.Discount = Convert.ToInt32(textInputDiscount.Value);
            product.Articul = textInputArticul.Text;
            textInputPriceWithDiscount.Text = product.PriceWithDiscount.ToString("C2");



        }

        private void buttonImageDrop_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить изображение товара", "Редактирование товара",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
            {
                buttonUpdate_Click(sender, e);
                return;
            }
            product.Photo = "";
            buttonUpdate_Click(sender, e);

        }

        private void buttonImageSet_Click(object sender, EventArgs e)
        {
            ImageFile image = new ImageFile();
            if(product.HaveImage)
            {
                image.Image = product.Image;
            }
            else
            {
                image.Bitmap = new Bitmap(100, 100);
            }

            bool yes = false;
            DiskForm disk = new DiskForm(image, ref yes, this);
            Hide();
            disk.ShowDialog();
            Show();
            try
            {
                if (disk.YesChoose)
                {
                    if (image.Image != null && !(image.Image is null))
                        product.Image = image.Image;
                }
            }
            catch
            {

            }
            try
            {

                image.Dispose();
            }
            catch
            {

            }
            try
            {
                disk.Dispose();
            }
            catch
            {

            }
            buttonUpdate_Click(sender, e);
        }

        private void buttonImageChange_Click(object sender, EventArgs e)
        {
            buttonImageSet_Click(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить товар?", "Удаление товара", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.No)
            {
                return;
            }

            if(product.DeleteFromDB())
            {
                MessageBox.Show("Товар успешно удалён", "Удаление товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Не удалось удалить товар", "Удаление товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonQuantityEdit_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            try
            {
                if (comboBoxWithNameStock.Items.Count < 1)
                    throw new Exception();
                int index = comboBoxWithNameStock.SelectedIndex;
                stock = stocks[index].CopyStock();
            }
            catch (Exception ex)
            {
                

            }

            TradingPoint shop = new TradingPoint();
            try
            {
                if (comboBoxWithNameShops.Items.Count < 1)
                    throw new Exception();
                int index = comboBoxWithNameShops.SelectedIndex;
                shop = shops[index].CopyPoint();

            }
            catch (Exception ex)
            {

            }

            ProductInTraidingPoint editForm = new ProductInTraidingPoint(product, stock, shop);
            Hide();
            editForm.ShowDialog();
            Show();
        }

        private void menuStripQuantity_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonCreateDescription_Click(object sender, EventArgs e)
        {
            TextFile textFile = new TextFile
            {
                Text = textInputDescription.Text
            };

            bool yes = false;
            TextForm disk = new TextForm(textFile.Text);
            Hide();
            disk.ShowDialog();
            Show();

            try
            {
                if (disk.Save)
                {

                    textInputDescription.Text = disk.EditText.Text;
                }
            }
            catch
            {

            }
            disk.Dispose();
            buttonUpdate_Click(sender, e);


        }

        private void dropDescription_Click(object sender, EventArgs e)
        {
            textInputDescription.Text = "";
        }

        private void EditVieFewWindow_Click(object sender, EventArgs e)
        {
            product.Articul = textInputArticul.Text;
            product.Name = textInputName.Text;
            product.PriceWithOutDiscount = Convert.ToDouble(textInputPriceWithOutDiscount.Value);
            product.Discount = Convert.ToInt32(textInputDiscount.Value);
            product.Description = textInputDescription.Text;
            product.Category = GetCategory();
            product.Supplier = GetSupplier();
            product.Manufacture = GetManufacture();

            ProductEditorForm form = new ProductEditorForm(product.CopyEdit());

            form.ChangeArticul += Form_ChangeArticul;
            form.ChangeName += Form_ChangeName;
            form.ChangeDescripion += Form_ChangeDescripion;
            form.ChangePrice += Form_ChangePrice;
            form.ChangeDiscount += Form_ChangeDiscount;
            form.SetPhoto += Form_SetPhoto;
            form.DropPhoto += Form_DropPhoto;
            form.ChangeCategory += Form_ChangeCategory;
            form.ChangeSupplier += Form_ChangeSupplier;
            form.ChangeManufacture += Form_ChangeManufacture;

            Hide();
            form.ShowDialog();
            Show();
            timerEditVieFewWindow_Tick(sender, e);
            buttonUpdate_Click(sender, e);
        }

        private void Form_ChangeManufacture(string paramter)
        {
            try
            {
                Manufacture category = new Manufacture() { Name = paramter };
                ManufacturesList categories = ManufacturesList.GetListFromDB();
                manufactures = categories;
                categories.RemoveAllByID(0);
                if (!categories.ContainsByIdInLower(category))
                {
                    DialogResult result = MessageBox.Show("Введённого поставщика не существует. Вы хотите его добавить?", "Редактирование товара", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        throw new Exception();
                    }
                    if (!categories.AddToDB(category))
                    {
                        throw new Exception();
                    }
                    MessageBox.Show("Прозводителя успешно добавлен", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    categories.GetFromBD();
                    comboBoxManufacture.Items.Clear();
                    for (int i = 0; i < categories.Count; i++)
                    {
                        comboBoxManufacture.Items.Add(categories[i].Name);
                    }
                    Form_ChangeManufacture(paramter);
                    return;
                }
                product.Supplier = category;
                comboBoxManufacture.SelectedIndex = categories.IndexByIdInLower(category);
                category = categories.GetByIdInLower(category);
                product.Supplier = category;
                if (product.ID < 1 || updatePart)
                {
                    return;
                }

                if (!product.UpdateManufactureAtDB())
                    throw new Exception();

                MessageBox.Show("Прозводитель товара успешно изменён", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось изменить производителя товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_ChangeSupplier(string paramter)
        {
            try
            {
                Supplier category = new Supplier() { Name = paramter };
                SuppliersList categories = SuppliersList.GetListFromDB();
                suppliers = categories;
                categories.RemoveAllByID(0);
                if (!categories.ContainsByIdInLower(category))
                {
                    DialogResult result = MessageBox.Show("Введённого поставщика не существует. Вы хотите его добавить?", "Редактирование товара", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        throw new Exception();
                    }
                    if (!categories.AddToDB(category))
                    {
                        throw new Exception();
                    }
                    MessageBox.Show("Поставщик успешно добавлен", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    categories.GetFromBD();
                    comboBoxWithNameSupplier.Items.Clear();
                    for (int i = 0; i < categories.Count; i++)
                    {
                        comboBoxWithNameSupplier.Items.Add(categories[i].Name);
                    }
                    Form_ChangeSupplier(paramter);
                    return;
                }
                product.Supplier = category;
                comboBoxWithNameSupplier.SelectedIndex = categories.IndexByIdInLower(category);
                category = categories.GetByIdInLower(category);
                product.Supplier = category;
                if (product.ID < 1 || updatePart)
                {
                    return;
                }

                if (!product.UpdateSupplierAtDB())
                    throw new Exception();

                MessageBox.Show("Поставщик товара успешно изменён", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось изменить поставщика товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_ChangeCategory(string paramter)
        {
            try
            {
                Category category = new Category() { Name = paramter };
                categories = CategoriesList.GetListFromDB();
                categories.RemoveAllByID(0);
                if(!categories.ContainsByIdInLower(category))
                {
                    category.Filter.ID = 1;
                    DialogResult result = MessageBox.Show("Введённой категории не существует. Вы хотите её добавить?", "Редактирование товара", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(result == DialogResult.No)
                    {
                        throw new Exception();
                    }
                    if(!categories.AddCategoryToDB(category))
                    {
                        throw new Exception();
                    }
                    MessageBox.Show("Категория успешно добавлена", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    categories.GetFromBD();
                    comboBoxWithNameCategories.Items.Clear();
                    for (int i = 0; i < categories.Count; i++)
                    {
                        comboBoxWithNameCategories.Items.Add(categories[i].Name);
                    }
                    Form_ChangeCategory(paramter);
                    return;
                }

                category = categories.GetByIdInLower(category);
                product.Category = category.CopyCategory();
                comboBoxWithNameCategories.SelectedIndex = categories.IndexOfByID(category);
                product.Category = category.CopyCategory();
                if (product.ID < 1 || updatePart)
                {
                    return;
                }

                if (!product.UpdateCategoryAtDB())
                    throw new Exception();

                MessageBox.Show("Категория товара успешно изменена", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception e)
            {
                MessageBox.Show("Не удалось изменить категорию товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_DropPhoto()
        {
            product.Photo = "";
            if (product.ID > 0 && !updatePart)
            {
                if (product.DropPhotoAtDB())
                {
                    MessageBox.Show("Изображение товара успешно удалено", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить изображение товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_SetPhoto(byte[] paramter)
        {
            product.BytesPhoto = paramter;
            if(product.ID > 0 && !updatePart)
            {
                if (product.SetPhotoAtDB())
                {
                    MessageBox.Show("Изображение товара успешно изменено", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось изменить изображение товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_ChangeDiscount(int number)
        {
            product.Discount = number;
            if (product.ID < 1 || updatePart)
            {
                textInputDiscount.Value = Convert.ToDecimal(product.Discount);
            }
            else
            {

                if (product.UpdateDiscountAtDB())
                {
                    MessageBox.Show("Скидка на товар успешно изменена", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось изменить скидку на товар", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_ChangePrice(double number)
        {
            product.PriceWithOutDiscount = number;
            if (product.ID < 1 || updatePart)
            {
                textInputPriceWithOutDiscount.Value = Convert.ToDecimal(product.PriceWithOutDiscount);
            }
            else
            {

                if (product.UpdatePriceAtDB())
                {
                    MessageBox.Show("Цена товара успешно изменена", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось изменить цену товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_ChangeDescripion(string paramter)
        {
            product.Description = paramter;
            if (product.ID < 1 || updatePart)
            {
                textInputDescription.Text = product.Description;
            }
            else
            {

                if (product.UpdateDescriptionAtDB())
                {
                    MessageBox.Show("Описание товара успешно изменено", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось изменить описание товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_ChangeName(string paramter)
        {
            product.Name = paramter;
            if (product.ID < 1 || updatePart)
            {
                textInputName.Text = product.Name;
            }
            else
            {

                if (product.UpdateNameAtDB())
                {
                    MessageBox.Show("Название товара успешно изменено", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось изменить название товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_ChangeArticul(string paramter)
        {
            string articul = product.Articul;
            product.Articul = paramter;
            if (product.Articul.Trim() == articul)
                return;
            if(product.ID < 1)
            {
                textInputArticul.Text = product.Articul;
            }
            else
            {
                DialogResult result = MessageBox.Show("Измнени артикля у товара может нарушить вывод информации о нём. \n " +
                    "Вы хотите действительно изменить артикуль товара?", "редактирование товара", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    result = MessageBox.Show("В избежании сбов работы системы, лучше артикуль не изменять, а добавить товар с новым артиклем. \n " +
                    "Вы хотите хотите добавить товар вместо изменения его?", "редактирование товара", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(result == DialogResult.Yes)
                    {
                        product.ID = 0;
                        Form_ChangeArticul(paramter);
                        return;
                    }
                    if(product.UpdateArticulAtDB())
                    {
                        MessageBox.Show("Артикуль товара успешно изменён", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось изменить артикуль товара", "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void timerEditVieFewWindow_Tick(object sender, EventArgs e)
        {

            try
            {
                if (product.ID < 1)
                {
                    updatePart = true;
                }
            }
            catch
            {

            }
            AccountWithRoles account = Helper.GetAccount();
            menuStripDescription.Visible = updatePart && account.IsStockManager();
            menuStripEdit.Visible = account.IsStockManager();


            try
            {
                pictureBoxImage.Image = product.Image;
            }
            catch
            {
                pictureBoxImage.Image = Properties.Resources.Logotip1;
            }

        }
    }
}
