using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public partial class OrderViewForm : Form
    {

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

        public OrderViewForm()
        {
            InitializeComponent();
        }

        OrderWithStatus order = new OrderWithStatus();

        public OrderViewForm(OrderWithStatus order) : this()
        {
            this.order = order;
        }

        OrderFullInfo fullInfo = new OrderFullInfo();
        ProductsInOrderList products => fullInfo.Products;

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

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

        void UpdateView()
        {
            timerUpdate.Stop();

            if (!UpdateForm())
                return;

            timerUpdate.Start();
        }

        bool UpdateForm()
        {
            try
            {
                 
                fullInfo = OrdersController.GetController().GetProducts(Helper.GetSession(), order.ID);
                textInputNumber.Text = fullInfo.Order.Number;
                textInputInfo.Text = fullInfo.Order.Information.Replace("\n", Environment.NewLine);
                textInputPickupPoint.Text = fullInfo.Order.PickupPoint.Replace("\n", Environment.NewLine);

                dataGridViewProducts.Rows.Clear();
                for(int i = 0; i < products.Count; i++)
                {
                    int index = dataGridViewProducts.Rows.Add();
                    DataGridViewRow row = dataGridViewProducts.Rows[index];
                    row.Cells[0].Value = "Просмотреть";
                    row.Cells[1].Value = products[i].NameInfo;
                }

                AccountWithRoles account = Helper.GetAccount();
                buttonRepeart.Visible = account.IsClient();
                buttonCancel.Visible = account.IsOrderCanceler() && fullInfo.Order.StatusID != 6 && fullInfo.Order.StatusID != 5;
                buttonGive.Visible = account.IsOrderGive() && fullInfo.Order.StatusID != 6 && fullInfo.Order.StatusID != 5;
                menuStripStatusCange.Visible = account.IsOrderGive() && fullInfo.Order.StatusID != 6 && fullInfo.Order.StatusID != 5;
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Информация о заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return false;
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if(e.ColumnIndex == 0)
            {
                int index = e.RowIndex;
                Product product = products[index];
                ProductEditForm productEditForm = new ProductEditForm(product);
                Hide();
                productEditForm.ShowDialog();
                Show();
            }
        }

        private void dataGridViewProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellEventArgs a = new DataGridViewCellEventArgs(0, e.RowIndex);
            dataGridViewProducts_CellContentClick(sender, a);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            try
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите отменить заказ?", "Отмена заказа", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialog == DialogResult.No)
                {
                    timerUpdate.Start();
                    return;
                }
                if (!OrdersList.CancelOrder(fullInfo.Order.ID))
                    throw new Exception();

                MessageBox.Show("Заказ успешно отменён", "Отмена заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось отменить заказ", "Отмена заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonRepeart_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();

            try
            {
                ShoppingCartSession session = OrdersController.GetController().Reapeart(Helper.GetSession(), fullInfo.Order.ID);
                Helper.ShoppingCarts.Clear();
                Helper.ShoppingCarts.AddAproductsWithCountRange(ShoppingCartController.GetController().GetOrder(session));

                MessageBox.Show("Товары из заказа перенесены в корзину", "Повтор заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось повторить заказ", "Повтор заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate_Tick(sender, e);
            timerUpdate.Start();
        }

        private void buttonGive_Click(object sender, EventArgs e)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("Update [Order]" +
                        $"Set [OrderStatusID]=5, [OrderDateStatusChange]=@now " +
                        $"where [OrderID]={fullInfo.Order.ID}", connection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@now", DateTime.Now);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
                connection.Close();
                MessageBox.Show("Заказ успешно выдан", "Выдача заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timerUpdate_Tick(sender, e);
            }
            catch
            {
                MessageBox.Show("Не удалось выдать заказ", "Выдача заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOrderCreate_Click(object sender, EventArgs e)
        {
            StatusChange(sender, e, 1);
        }

        public void StatusChange(object sender, EventArgs e, int statusID)
        {
            SqlConnection connection = DataBaseConfiguration.GetSqlConnection();
            try
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("Update [Order]" +
                        $"Set [OrderStatusID]={statusID}, [OrderDateStatusChange]=@now " +
                        $"where [OrderID]={fullInfo.Order.ID}", connection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@now", DateTime.Now);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
                connection.Close();
                MessageBox.Show("Статус заказа успешно сменён", "Смена статуса заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timerUpdate_Tick(sender, e);
            }
            catch
            {
                MessageBox.Show("Не удалось сменить стутус заказа", "Смена статуса заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOrderRun_Click(object sender, EventArgs e)
        {
            StatusChange(sender, e, 3);
        }

        private void buttonTakeOrder_Click(object sender, EventArgs e)
        {
            StatusChange(sender, e, 2);
        }

        private void buttonOrderExpectRecipient_Click(object sender, EventArgs e)
        {
            StatusChange(sender, e, 4);
        }

        private void buttonNoOrder_Click(object sender, EventArgs e)
        {
            StatusChange(sender, e, 7);
        }

        private void buttonWaitForGoods_Click(object sender, EventArgs e)
        {
            StatusChange(sender, e, 8);
        }

        private void buttonSetOrder_Click(object sender, EventArgs e)
        {
            StatusChange(sender, e, 9);
        }
    }
}
