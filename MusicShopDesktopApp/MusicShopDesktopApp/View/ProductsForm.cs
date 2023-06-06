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
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }


        public new void Show()
        {
            base.Show();
            UpdateProducts();
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

        private void Model_Load(object sender, EventArgs e)
        {
            titleChange(Text);
            mainChange();

            UpdateCategoriesFilters();

            tabControlMain_SelectedIndexChanged(tabControlMain, e);
        }

        void titleChange(string text)
        {
            this.Text = text + " - " + Application.ProductName + " - " + Application.ProductVersion;
            notifyIconApp.Text = Text;
        }

        void mainChange()
        {
            TabControl.TabPageCollection tabPages = tabControlMain.TabPages;
            TreeNodeCollection treeNodes = treeViewMain.Nodes;
            ComboBox.ObjectCollection items = comboBoxMain.Items;

            for (int i = 0; i < tabPages.Count; i++) 
            {
                string name = tabPages[i].Text;
                treeNodes.Add(name);
                items.Add(name);
            }
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
            UpdateCategoriesFilters();
        }

        void UpdateCategoriesFilters()
        {
            timerUpdate.Stop();

            int categoryFilterID = 0;
            try
            {
                categoryFilterID = categoriesFilters.Get(comboBoxWithNameCategoryFilters.SelectedIndex).ID;
            }
            catch
            {

            }

            try
            {
                categoriesFilters.SetList(CategoriesFiltersController.GetController()
                    .GetCategoriesFilters(Helper.GetSession()));
                comboBoxWithNameCategoryFilters.Items.Clear();
                for (int i = 0; i < categoriesFilters.Count; i++)
                {
                    comboBoxWithNameCategoryFilters.Items.Add(categoriesFilters[i].Name);
                }
            }
            catch
            {

            }


            try
            {
                categoryFilterID = categoriesFilters.IndexOfByID(categoryFilterID);
                if (categoryFilterID >= 0)
                {
                    try
                    {

                        comboBoxWithNameCategoryFilters.SelectedIndex = categoryFilterID;
                    }
                    catch
                    {
                        comboBoxWithNameCategoryFilters.SelectedIndex = 0;
                    }
                }
            }
            catch
            {

            }
            UpdateCategories();
        }

        void UpdateCategories()
        {
            timerUpdate.Stop();

            int categoryFilterID = 0;
            try
            {
                categoryFilterID = categoriesFilters.Get(comboBoxWithNameCategoryFilters.SelectedIndex).ID;
            }
            catch
            {

            }
            int categoryID = 0;

            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                categoryID = category.ID;
                labelCategory.Text = category.RealName;
            }
            catch
            {
                labelCategory.Text = "";
                categoryID = 0;
            }

            try
            {
                categories.SetList(CategoriesController.GetController()
                    .GetCategoriesCheck(categoryFilterID, categoryID, radioButtonTree.Checked));
                listBoxCategories.Items.Clear();
                for (int i = 0; i < categories.Count; i++)
                {
                    listBoxCategories.Items.Add(categories[i].Name);
                }
            }
            catch
            {

            }


            listBoxCategories.SelectedIndexChanged -= listBoxCategories_SelectedIndexChanged;
            try
            {
                categoryID = categories.IndexOfByID(categoryID);
                
                if (categoryID >= 0)
                {
                    try
                    {
                        listBoxCategories.SelectedIndex = categoryID;

                    }
                    catch
                    {
                        listBoxCategories.SelectedIndex = 0;
                    }
                }
                labelCategory.Text = categories.Get(listBoxCategories.SelectedIndex).RealName;

            }
            catch
            {
                labelCategory.Text = "";
            }
            listBoxCategories.SelectedIndexChanged += listBoxCategories_SelectedIndexChanged;

            UpdateProducts(false);
        }

        CategoriesList categories = new CategoriesList();
        CategoriesFiltersList categoriesFilters = new CategoriesFiltersList();

        void UpdateProducts(bool updateCategories = true)
        {
            buttonAdd.Visible = Helper.GetAccount().IsStockManager();
            timerUpdate.Stop();
            try
            {
                AccountWithRoles roles = Helper.GetAccount();
                groupBoxRoles.Visible = roles.IsNoOnlyRole();
                buttonUserMenagement.Visible = roles.IsDirector();


                int indexRole = comboBoxRoles.SelectedIndex;
                comboBoxRoles.SelectedIndexChanged -= comboBoxRoles_SelectedIndexChanged;
                comboBoxRoles.Items.Clear();
                for (int i = 0; i < roles.Roles.Count; i++)
                {
                    comboBoxRoles.Items.Add(roles.Roles[i].RoleRus);
                }
                try
                {
                    if (indexRole < 0)
                        throw new Exception();
                    comboBoxRoles.SelectedIndex = indexRole;

                }
                catch
                {
                    try
                    {
                        comboBoxRoles.SelectedIndex = 0;
                    }
                    catch
                    {

                    }
                }
                comboBoxRoles.SelectedIndexChanged += comboBoxRoles_SelectedIndexChanged;

                indexRole = comboBoxRoles.SelectedIndex;
                try
                {
                    Helper.SetClient = false;
                    Helper.SetSalesMan = false;
                    Helper.SetOrdersManager = false;
                    Helper.SetOperator = false;
                    Helper.SetAdmin = false;
                    Helper.SetStockManager = false;
                    int id = roles.Roles[indexRole].ID;
                    if (id == 1)
                    {
                        Helper.SetClient = true;
                    }
                    else
                    {
                        Helper.SetClient = false;
                        if (id == 5)
                            Helper.SetOrdersManager = true;
                        else if (id == 7)
                            Helper.SetSalesMan = true;
                        else if (id == 3)
                            Helper.SetAdmin = true;
                        else if (id == 6)
                            Helper.SetOperator = true;
                        else if (id == 4)
                            Helper.SetStockManager = true;
                        else
                            throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    Helper.SetClient = false;
                    Helper.SetSalesMan = false;
                    Helper.SetOrdersManager = false;
                    Helper.SetOperator = false;
                    Helper.SetAdmin = false;
                    Helper.SetStockManager = false;
                }
            }
            catch
            {
                groupBoxRoles.Visible = false;
            }


            if (radioButtonLine.Checked)
            {
                updateCategories = false;
            }
            if(updateCategories)
            {
                UpdateCategories();
                return;
            }
            int categoryID = 0;

            Helper.ShoppingCarts.TradingPoint = Helper.TraidHelper.TradingPoint;
            Helper.ShoppingCarts.PounktType = Helper.TraidHelper.PounktType;
            Helper.ShoppingCarts.SetChange();

            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                categoryID = category.ID;
                labelCategory.Text = category.RealName;
            }
            catch(Exception e)
            {
                labelCategory.Text = "";
            }


            try
            {
                AccountWithRoles account = Helper.GetAccount();
                labelAccountName.Text = account.Login;
                labelFIO.Text = account.FIO.Initials;

                bool login = Helper.UserIsGoest();
                buttonLogIn.Visible = login;
                buttonRegistrate.Visible = login;
                buttonLogOut.Visible = !login;
                buttonUserEdit.Visible = !login;

                if(tabControlMain.SelectedIndex == 0)
                {
                    GetProducts(categoryID);
                }
                else if(tabControlMain.SelectedIndex == 1)
                {
                    GetOrder();
                }
                else if(tabControlMain.SelectedIndex > 1 && Helper.UserIsGoest())
                {
                    MessageBox.Show("Вы больше не авторизированы", "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControlMain.SelectedIndex = 0;
                    return;
                }
                if(tabControlMain.SelectedIndex == 2)
                {
                    labelOrderError.Visible = Helper.UserIsGoest() || !Helper.ShoppingCarts.Mayby;
                    panelOrder.Visible = !labelOrderError.Visible;
                        labelOrderPointTraid.Text = Helper.TraidHelper.GetTraidingPoint();
                        labelOrderInfo.Text = Helper.ShoppingCarts.GetOrderData().Information;
                        labelOrderTraidingPoint.Text = Helper.TraidHelper.TradingPoint.Data;
                    if(Helper.UserIsGoest())
                    {
                        MessageBox.Show("Вы больше не авторизированы", "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControlMain.SelectedIndex = 0;
                        return;
                    }
                }
                if(tabControlMain.SelectedIndex == 3)
                {
                    if (Helper.UserIsGoest())
                    {
                        MessageBox.Show("Вы больше не авторизированы", "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControlMain.SelectedIndex = 0;
                        return;
                    }
                    AccountWithRoles withRoles = Helper.GetAccount();
                    if (!withRoles.IsShowOrdersUser() && !withRoles.IsClient())
                    {
                        MessageBox.Show("Вы не являетесь " +
                        "ни клиентом," +
                        "ни продавцом," +
                        "ни менеджером по заказу" +
                        "ни директором," +
                        "ни администратором", "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControlMain.SelectedIndex = 0;
                        return;
                    }

                    orders = OrdersController.GetController().Get(Helper.GetSession(), textBoxNumber.Text);
                    if(Helper.TraidHelper.TradingPoint.ID > 0)
                    {
                        orders = new OrdersWithStatusesList(orders.FindAll(o => o.PointID == Helper.TraidHelper.TradingPoint.ID));
                    }
                    if (Helper.SetStockManager && !Helper.SetAdmin)
                        orders.Clear();
                    dataGridViewOrders.Rows.Clear();
                    for (int i = 0; i < orders.Count; i++) 
                    {
                        int index = dataGridViewOrders.Rows.Add();
                        DataGridViewRow row = dataGridViewOrders.Rows[index];
                        row.Cells[0].Value = "Перейти";
                        row.Cells[1].Value = orders[i].Number;
                        row.Cells[2].Value = orders[i].Information;
                    }
                }

            }
            catch
            {
                labelAccountName.Text = "";
                labelFIO.Text = "";

                buttonLogIn.Visible = false;
                buttonRegistrate.Visible = false;
                buttonLogOut.Visible = false;
                buttonUserEdit.Visible = false;
            }
            timerUpdate.Start();

        }

        OrdersWithStatusesList orders = new OrdersWithStatusesList();

        public void GetProducts(int categoryID)
        {
            try
            {
                dataGridViewProducts.Rows.Clear();


                if (comboBoxOrderName.SelectedIndex < 0)
                {
                    comboBoxOrderName.SelectedIndex = 0;
                    return;
                }
                if (comboBoxOrderPrice.SelectedIndex < 0)
                {
                    comboBoxOrderPrice.SelectedIndex = 0;
                    return;
                }

                int min = Convert.ToInt32(numericControlWithNameMin.Value);
                int max = Convert.ToInt32(numericControlWithNameMax.Value);


                int orderName = comboBoxOrderName.SelectedIndex;
                int orderPrice = comboBoxOrderPrice.SelectedIndex;
                string name = textBoxOrderName.Text;

                ProductsController controller = new ProductsController();
                Helper.ProductsController = controller;

                //CategoriesList categories = CategoriesController.GetController().GetCategories();

                ProductsList products = new ProductsList();

                if (!Helper.TraidHelper.Checked)
                    products = controller
                        .GetProducts(Helper.Session, (Order)orderName, (Order)orderPrice, nameFilter: name
                        , maxDiscount: max, minDiscount: min, category: categoryID);
                else
                {
                    if (Helper.TraidHelper.PounktType == PounktType.All)
                        products = controller
                            .GetProducts(Helper.Session, (Order)orderName, (Order)orderPrice, nameFilter: name
                            , maxDiscount: max, minDiscount: min, category: categoryID);
                    else
                    {
                        try
                        {
                            if (Helper.TraidHelper.PounktType == PounktType.Shop)
                                products = ProductsInShopsController.GetController()
                                    .GetProducts(Helper.Session,
                                    ((Order)orderName).ToString(), ((Order)orderPrice).ToString(),
                                    nameFilter: name, id: Helper.TraidHelper.ShopID()
                                    , maxDiscount: max, minDiscount: min, category: categoryID, listFull: !checkBoxFull.Checked)
                                    .GetProducts();
                            else
                                products = ProductsInStocksController.GetController()
                                    .GetProducts(Helper.Session,
                                    ((Order)orderName).ToString(), ((Order)orderPrice).ToString(),
                                    nameFilter: name, id: Helper.TraidHelper.StockID()
                                    , maxDiscount: max, minDiscount: min, category: categoryID, listFull: !checkBoxFull.Checked).
                                    GetProducts();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Вывод товаров (Ошибка!!!)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Helper.TraidHelper.Clear();
                            UpdateProducts();
                            return;
                        }

                    }
                }

                Helper.Products = products;
                for (int i = 0; i < products.Count; i++)
                {
                    int index = dataGridViewProducts.Rows.Add();
                    DataGridViewRow row = dataGridViewProducts.Rows[index];
                    row.Cells[0].Value = products[i].Articul;
                    Bitmap bitmap;
                    try
                    {
                        bitmap = products[i].Bitmap;
                    }
                    catch (Exception ex)
                    {
                        bitmap = new Bitmap(Properties.Resources.Logotip1, 50, 50);
                    }
                    row.Cells[1].Value = bitmap;
                    row.Cells[2].Value = "Подробнее";
                    row.Cells[3].Value = "В корзину";
                    row.Cells[4].Value = products[i].GetData();

                    if (products[i].Discount > 14)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(153, 255, 153);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    if (products[i].IsInPounkt())
                    {
                        ProductInPounkt inPounkt = products[i].AsInPounkt();
                        if (inPounkt.GetPounktType() != PounktType.All)
                        {
                            if (inPounkt.Quantity < 1)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }

                }
                try
                {

                    labelCount.Text = products.Count + " из " + controller.GetProducts(Helper.Session).Count;


                }
                catch
                {
                    labelCount.Text = "";
                }
            }
            catch
            {
                labelCount.Text = "";
                dataGridViewProducts.Rows.Clear();
            }
        }

        void GetOrder()
        {
            dataGridViewOrder.Rows.Clear();
            try
            {
                ProductsInShoppingCartList products = Helper.ShoppingCarts;
                products.PounktType = Helper.TraidHelper.PounktType;
                products.PounktID = Helper.TraidHelper.TradingPoint.ID;
                products.GetThisWithChange();
                for(int i = 0; i < Helper.ShoppingCarts.Count; i++)
                {
                    ProductInShoppingCart product = products[i];
                    int index = dataGridViewOrder.Rows.Add();
                    DataGridViewRow row = dataGridViewOrder.Rows[index];
                    row.Cells[0].Value = "C";
                    row.Cells[1].Value = "-";
                    row.Cells[2].Value = product.Quantity;
                    row.Cells[3].Value = "+";
                    row.Cells[4].Value = "!";
                    row.Cells[5].Value = product.GetNameInfo();
                    row.DefaultCellStyle.BackColor = product.Mayby ? Color.White : Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = product.Mayby ? Color.Blue : Color.Green;
                    row.Cells[2].Style.BackColor = Color.White;
                    row.Cells[2].Style.SelectionBackColor = Color.White;
                    row.Cells[2].Style.ForeColor = Color.Black;
                    row.Cells[2].Style.SelectionForeColor = Color.Black;

                }
                labelInfo.Text = products.GetOrderData().Information;
            }
            catch
            {
                labelInfo.Text = "";
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl main = (sender as TabControl);
            int index = main.SelectedIndex;
            textIndex.Text = $"{index}";
            string name = main.TabPages[index].Text;
                titleChange(name);

            comboBoxMain.SelectedIndex = index;
            treeViewMain.SelectedNode = treeViewMain.Nodes[index];

            orders.Clear();
            dataGridViewOrders.Rows.Clear();
            buttonUpdate_Click(sender, e);
        }

        private void comboBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = comboBoxMain.SelectedIndex;
        }

        private void comboBoxMain_Click(object sender, EventArgs e)
        {

        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tabControlMain.SelectedIndex = treeViewMain.SelectedNode.Index;
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            if(tabControlMain.SelectedIndex > 0)
            {
                tabControlMain.SelectedIndex--;
            }
            else
            {
                tabControlMain.SelectedIndex = 0;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex < tabControlMain.TabCount)
            {
                tabControlMain.SelectedIndex++;
            }
            else
            {
                tabControlMain.SelectedIndex = tabControlMain.TabCount - 1;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = 0;
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = tabControlMain.TabCount - 1;
        }

        private void textIndex_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as ToolStripTextBox).Text;
            
            try
            {
                int index = Convert.ToInt32(text);
                tabControlMain.SelectedIndex = index;
            }
            catch
            {

            }
        }

        private void buttonRunConnectionString_Click(object sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.PasswordEvents.LoadEdit = () => 
                {
                    DialogResult res = MessageBox.Show("Разрешить данной функцие вносить изменения в программе", 
                        "Редактирование строки подключения к базе данных", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Warning);
                    return res == DialogResult.Yes;
            };

            passwordForm.PasswordEvents.BeforeInput = () => DataBaseConfiguration.Password.Password == "";

            passwordForm.PasswordEvents.CheckPassword = (password) =>
            {
                try
                {
                    Helper.GetSessionConnection(password.Password);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Неверный пароль", "Редактирование строки подключения к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            };

            passwordForm.PasswordEvents.AfterEnteringCorrect = (password) =>
            {
                ConnectionSettingsForm connectionForm = new ConnectionSettingsForm();
                connectionForm.ShowDialog();
            };
            Hide();
            passwordForm.ShowDialog();
            Show();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            Authorize authorize = new Authorize();
            Hide();
            authorize.ShowDialog();
            Show();
        }

        private void buttonRegistrate_Click(object sender, EventArgs e)
        {
            Authorize authorize = new Authorize(true);
            Hide();
            authorize.ShowDialog();
            Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            SessionsController.GetController().
                SignOut(Helper.Session);
            UpdateProducts();
        }

        private void comboBoxOrderName_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProducts();
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int x = e.ColumnIndex;
                int y = e.RowIndex;
                if (y < 0)
                    return;
                Product product = Helper.Products[y];
                if (x == 2)
                {
                    
                    Helper.GetAccount();
                    Helper.Products = Helper.ProductsController.GetProducts(Helper.Session);
                    if (!Helper.Products.ContainsID(product))
                    {
                        MessageBox.Show("Такого товара больше не существует", "Просмотр товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateProducts();
                        return;
                    }
                    ProductEditForm productEdit = new ProductEditForm(product);
                    Hide();
                    productEdit.ShowDialog();
                    Show();
                }
                else if (x == 3)
                {
                    try
                    {
                        Helper.ShoppingCarts.AddProduct(product);

                        MessageBox.Show("Товар успешно добавлен в корзину", "Добавление товара в корзину", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить товар в корзину", "Добавление товара в корзину", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Такого товара больше не существует", "Просмотр товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateProducts();
                return;
            }
        }

        private void dataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewProducts_CellContentClick(sender, new DataGridViewCellEventArgs(2, e.RowIndex));
        }

        private void buttonUserEdit_Click(object sender, EventArgs e)
        {
            UpdateProducts();

            if (Helper.UserIsGoest())
                return;
            UserEditForm editForm = new UserEditForm();
            Hide();
            editForm.ShowDialog();
            Show();
        }

        private void textIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            e.Handled = true;
            if(number == 8 || number == 27)
            {
                (sender as ToolStripTextBox).Text = "";
                return;
            }

            if(number == '0' || number == '1' || number == '2' || number == '3')
            {
                (sender as ToolStripTextBox).Text = Convert.ToString(number);
                textIndex_TextChanged(sender, e);
                return;
            }

        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            buttonUpdate_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TraidingPounktsForm form = new TraidingPounktsForm();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void toolStripButtonPoint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Helper.TraidHelper.GetTraidingPointData(), "Данные о выбранном торговом пункте", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void numericControlWithNameMin_ValueChanged(object arg1, EventArgs arg2)
        {
            UpdateProducts();
        }

        private void numericControlWithNameMax_ValueChanged(object arg1, EventArgs arg2)
        {
            UpdateProducts();
        }

        private void radioButtonTree_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                listBoxCategories.SelectedIndex = 0;
            }
            catch
            {

            }
            UpdateCategories();
        }

        private void radioButtonLine_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxWithNameCategoryFilters_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            UpdateCategories();
        }

        private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProducts();
        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            int button = e.ColumnIndex;
            if(button == 0)
            {
                Helper.ShoppingCarts.RemoveAt(index);
            }
            else  if (button == 1)
            {
                Helper.ShoppingCarts.SubstractProduct(index);
            }
            else if(button == 3)
            {
                Helper.ShoppingCarts.AddProduct(index);
            }
            else if(button == 4)
            {
                try
                {
                    Hide();

                    Product product = Helper.ShoppingCarts.Get(index);
                    ProductEditForm editForm = new ProductEditForm(product);
                    editForm.ShowDialog();

                    Show();
                }
                catch
                {

                }
            }
            else
            {
                return;
            }
            buttonUpdate_Click(sender, e);
        }

        private void dataGridViewOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = (e.Control as TextBox);
            textBox.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                return;
            if (e.KeyChar == 8 || e.KeyChar == 13)
            {
                return;
            }
            e.Handled = true;
            if(e.KeyChar == 27)
            {
                (sender as TextBox).Text = "";
            }
        }

        private void dataGridViewOrder_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int index = e.RowIndex;
            if (index < 0)
                return;
            if (column != 2)
                return;
            try
            {
                Helper.ShoppingCarts.Get(index).Quantity = Convert.ToInt32(
                    dataGridViewOrder[2, index].Value
                    );
            }
            catch
            {

            }
            buttonUpdate_Click(sender, e);

        }

        private void buttonOrderCreate_Click(object sender, EventArgs e)
        {
            try
            {
                
                tabControlMain.SelectedIndex = 2;
            }
            catch
            {
                MessageBox.Show("Невозможно оформить заказ \n",
                       "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int index = e.TabPageIndex;
            int thisIndex = tabControlMain.SelectedIndex;
            if (index < 2)
                return;
            try
            {
                if(index == 2)
                {
                    if (!Helper.ShoppingCarts.Mayby)
                    {
                        MessageBox.Show("Невозможно оформить заказ \n" +
                            " - Проыерьте наличие пункта получения (магазина или пункта выдачи) \n" +
                            " - Проверьте наличие, хотя бы, одного товара в корзине \n" +
                            " - Проверьте возможность заказа каждого товара в корзине (Товары, которые невозможно заказать выделены красным цветов)," +
                            " и если есть товары, которые невозможно заказать: \n" +
                            "\t 1) Проверьте существование таких товаров \n" +
                            "\t 2) Проверьте наличие таких товаров " +
                            "в магазине (если пункт получения - магазин) или на складе (если пункт получения - пункт выдачи) \n" +
                            "\t 3) Проверьте, чтобы количество таких товаров в корзине не превышало количество " +
                            "в магазине (если пункт получения - магазин) или на складе (если пункт получения - пункт выдачи) \n" +
                            "Выполните выше перечисленные проверки, исправьте ошибки, и попробуйте оформить заказ снова",
                            "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        
                        return;
                    }
                }

                if (Helper.UserIsGoest())
                {
                    DialogResult result = MessageBox.Show("Для оформления заказа или просмотра заказов вам необходимо авторизироваться \n" +
                        "Вы хотите авторизироваться \n", "Оформление заказа или просмотр заказов",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.No)
                        throw new Exception();
                    Authorize authorize = new Authorize();
                    Hide();
                    authorize.ShowDialog();
                    Show();
                    if (Helper.UserIsGoest())
                        throw new Exception();
                }
            }
            catch
            {
                e.Cancel = true;
                if (thisIndex > 1)
                    tabControlMain.SelectedIndex = 0;
            }
            buttonUpdate_Click(sender, e);
        }

        private void labelOrderError_VisibleChanged(object sender, EventArgs e)
        {
            panelOrder.Visible = !(sender as Label).Visible;
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            Helper.ShoppingCarts.SetChange();
            if (!Helper.ShoppingCarts.Mayby)
            {

                MessageBox.Show("Невозможно оформить заказ \n" +
                    " - Проыерьте наличие пункта получения (магазина или пункта выдачи) \n" +
                    " - Проверьте наличие, хотя бы, одного товара в корзине \n" +
                    " - Проверьте возможность заказа каждого товара в корзине (Товары, которые невозможно заказать выделены красным цветов)," +
                    " и если есть товары, которые невозможно заказать: \n" +
                    "\t 1) Проверьте существование таких товаров \n" +
                    "\t 2) Проверьте наличие таких товаров " +
                    "в магазине (если пункт получения - магазин) или на складе (если пункт получения - пункт выдачи) \n" +
                    "\t 3) Проверьте, чтобы количество таких товаров в корзине не превышало количество " +
                    "в магазине (если пункт получения - магазин) или на складе (если пункт получения - пункт выдачи) \n" +
                    "Выполните выше перечисленные ошибки, исправьте ошибки, и попробуйте оформить заказ снова",
                    "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlMain.SelectedIndex = 1;
                return;
            }
            AccountWithRoles account = Helper.GetAccount();
            if (account.IsGoest())
            {

                MessageBox.Show("Вы больше не авторизированы", "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlMain.SelectedIndex = 1;
                return;
            }



            if (!account.IsOrder())
            {
                MessageBox.Show("Необходима роль менеджера по заказам, или клиента, или продавца, или оператора, или администратора ",
                    "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlMain.SelectedIndex = 1;
                return;
            }


            if (!Helper.IsOrderCreater)
            {
                MessageBox.Show("Вы не можете с выбранной ролью сделать заказ", "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlMain.SelectedIndex = 1;
                return;
            }

            bool setClient = Helper.SetClient;
            bool setOperator = Helper.SetOperator;
            bool setOrdersManager = Helper.SetOrdersManager;
            bool setSalesMan = Helper.SetSalesMan;


            if (setOrdersManager)
            {
                if (!Helper.TraidHelper.TradingPoint.ExistencePounktOfIssue
                    || Helper.TraidHelper.PounktType != PounktType.Stock)
                {
                    MessageBox.Show("с ролью менеджера по заказам вы можете делать заказ только на пункт выдачи",
                        "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControlMain.SelectedIndex = 1;
                    return;
                }
            }

            if (setSalesMan)
            {
                if (!Helper.TraidHelper.TradingPoint.ExistenceShop
                    || Helper.TraidHelper.PounktType != PounktType.Shop)
                {
                    MessageBox.Show("с ролью продавца вы можете делать заказ только в магазин",
                        "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControlMain.SelectedIndex = 1;
                    return;
                }
            }



            OrderValue order = new OrderValue();
            try
            {
                order.SetOrder(OrdersList.AddToDB(Helper.ShoppingCarts.GetOrder()));
                if (setClient && !OrdersList.AddClientDB(account.ID, order.ID))
                    throw new Exception();
                if (!OrdersList.AddProductsToOrderInDB(Helper.ShoppingCarts, order.ID))
                    throw new Exception();
                if (Helper.ShoppingCarts.PounktType == PounktType.Shop)
                {
                    if (!OrdersList.AddInShopInDB(Helper.ShoppingCarts.PounktID, order.ID))
                    {
                        throw new Exception();
                    }
                    try
                    {
                        OrdersList.ChangeProductsCountInShop(Helper.ShoppingCarts.PounktID, Helper.ShoppingCarts);
                    }
                    catch
                    {

                    }
                }
                else if (Helper.ShoppingCarts.PounktType == PounktType.Stock)
                {
                    if (!OrdersList.AddInPounktOfIssueInDB(Helper.ShoppingCarts.PounktID, order.ID))
                    {
                        throw new Exception();
                    }
                    try
                    {
                        OrdersList.ChangeProductsCountInStock(Helper.ShoppingCarts.TradingPoint.StockID, Helper.ShoppingCarts);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    throw new Exception();
                }      
                    

            }
            catch
            {
                OrdersList.DeleteFromDB(order.ID);
                MessageBox.Show("Не удалось оформить заказ", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show($"Номер сделанного заказа - {order.Number}", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tabControlMain.SelectedIndex = 1;
            buttonOrderClear_Click(sender, e);
        }

        private void buttonOrderClear_Click(object sender, EventArgs e)
        {
            Helper.ShoppingCarts.Clear();
            buttonUpdate_Click(sender, e);
        }

        private void checkBoxFull_CheckedChanged(object sender, EventArgs e)
        {

            buttonUpdate_Click(sender, e);
        }

        private void buttonSortNameClear_Click(object sender, EventArgs e)
        {
            comboBoxOrderName.SelectedIndex = 0;
        }

        private void buttonSortCostClear_Click(object sender, EventArgs e)
        {
            comboBoxOrderPrice.SelectedIndex = 0;
        }

        private void buttonNameClear_Click(object sender, EventArgs e)
        {
            textBoxOrderName.Text = "";
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
            buttonUpdate_Click(sender, e);
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && (sender as TextBox).Text.Length < 20)
                return;
            if (e.KeyChar == 8)
                return;
            e.Handled = true;
            if(e.KeyChar == 27)
            {
                (sender as TextBox).Text = "";
            }
        }

        private void buttonNumberClear_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "";
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if(e.ColumnIndex == 0)
            {
                int index = e.RowIndex;
                OrderWithStatus order = orders[index];

                OrderViewForm orderView = new OrderViewForm(order);
                Hide();
                orderView.ShowDialog();
                Show();
                
            }
        }

        private void dataGridViewOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellEventArgs a = new DataGridViewCellEventArgs(0, e.RowIndex);
            dataGridViewOrders_CellContentClick(sender, a);
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            
            buttonUpdate_Click(sender, e);
        }

        private void buttonEditByAdmin_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Разрешить данной функцие вносить изменения в программе",
                        "Редактирование строки подключения к базе данных",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
            if (res == DialogResult.No)
                return;
            if (!Helper.GetSessionConnection())
            {
                MessageBox.Show("Требуется сессия авторизированного пользователя и роль администратора",
                        "Редактирование строки подключения к базе данных",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return;
            }

            ConnectionSettingsForm connectionForm = new ConnectionSettingsForm();
            Hide();
            connectionForm.ShowDialog();
            Show();
        }

        private void buttonEditsUsers_Click(object sender, EventArgs e)
        {
            UsersEditForm editForm = new UsersEditForm();
            Hide();
            editForm.ShowDialog();
            Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            ProductEditForm editForm = new ProductEditForm(product);
            Hide();
            editForm.ShowDialog();
            Show();
            
        }
    }
}
