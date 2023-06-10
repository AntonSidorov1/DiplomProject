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
    public partial class SuppliersEditForm : Form
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

        public SuppliersEditForm()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            labelSupplier.Text = "";
            labelSupplierEditName.Text = "";

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

        SuppliersList suppliers = new SuppliersList();
        bool UpdateForm()
        {
            if (Helper.UserIsGoest())
            {
                MessageBox.Show("Вы больше не авторизированы", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            if (!Helper.GetAccount().IsOrdersManager())
            {
                MessageBox.Show("Необходима роль менеджера по складу или администратора",
                    "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }


            UpdateSuppliers();

            return true;
        }

        void UpdateSuppliers()
        {
            labelSupplierEditName.Text = supplierEdit.Name;
            int supplierID = 0;
            try
            {
                supplierID = suppliers.Get(listBoxSuppliers.SelectedIndex).ID;
            }
            catch
            {

            }

            try
            {
                suppliers.GetFromBD();
                listBoxSuppliers.Items.Clear();
                for (int i = 0; i < suppliers.Count; i++)
                {
                    listBoxSuppliers.Items.Add(suppliers[i].Name);
                }
            }
            catch
            {

            }


            try
            {
                supplierID = suppliers.IndexOfByID(supplierID);
                if (supplierID >= 0)
                {
                    try
                    {

                        listBoxSuppliers.SelectedIndex = supplierID;
                    }
                    catch
                    {
                        listBoxSuppliers.SelectedIndex = 0;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                try
                {

                    listBoxSuppliers.SelectedIndex = 0;
                }
                catch
                {
                    
                }
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        Supplier supplierEdit = new Supplier();

        private void listBoxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelSupplier.Text = suppliers.Get(listBoxSuppliers.SelectedIndex).Name;
            }
            catch
            {
                labelSupplier.Text = "";
            }
        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;

            if(suppliers.AddToDB(textInputSupplierName.Text))
            {
                MessageBox.Show("Поставщик успешно добавлен", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось добавить поставщика", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            supplierEdit = new Supplier();
            textInputSupplierName.Text = supplierEdit.Name;
            if (!UpdateForm())
                return;
        }

        private void buttonDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить поставщика", "Удаление поставщика", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
            {
                UpdateForm();
                return;
            }

            if (!UpdateForm())
                return;
            try
            {
                Supplier category = suppliers.Get(listBoxSuppliers.SelectedIndex);
                int categoryID = category.ID;
                if (suppliers.DeleteFromDB(categoryID))
                {
                    MessageBox.Show("Поставщик успешно удалён", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось удалить поставщика", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            UpdateForm();
        }

        private void buttonSupplierCopyEdit_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            try
            {
                Supplier category = suppliers.Get(listBoxSuppliers.SelectedIndex);
                supplierEdit = category.CopySupplier();
                textInputSupplierName.Text = supplierEdit.Name;

            }
            catch (Exception ex)
            {

            }
            if (!UpdateForm())
                return;
        }

        private void buttonSupplierEdit_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;

            if (!suppliers.ContainsByID(supplierEdit))
            {
                MessageBox.Show("Данной поставщика больше не существует \n" +
                    "Попробуйте добавить данного поставщика", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (suppliers.UpdateToDB(supplierEdit))
            {
                MessageBox.Show("Поставщик успешно изменён", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить поставщика", "Редактирование поставщиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            supplierEdit = new Supplier();
            textInputSupplierName.Text = supplierEdit.Name;

            UpdateForm();
        }

        private void textInputSupplierName_InputText_Changed(object arg1, EventArgs arg2)
        {
            supplierEdit.Name = textInputSupplierName.Text;
        }

        private void buttonEditVieWindow_Click(object sender, EventArgs e)
        {
            SupplierEditForm form = new SupplierEditForm(supplierEdit.CopyEdit());
            form.ChangeName += Form_ChangeName;
            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeName(string paramter)
        {
            supplierEdit.Name = paramter;
            textInputSupplierName.Text = paramter;
        }
    }
}
