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
    public partial class ManufacturesEditForm : Form
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

        public ManufacturesEditForm()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            labelManufacture.Text = "";
            labelmanufactureEditName.Text = "";

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

        ManufacturesList suppliers = new ManufacturesList();
        bool UpdateForm()
        {
            if (Helper.UserIsGoest())
            {
                MessageBox.Show("Вы больше не авторизированы", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            if (!Helper.GetAccount().IsOrdersManager())
            {
                MessageBox.Show("Необходима роль менеджера по складу или администратора",
                    "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }


            UpdateSuppliers();

            return true;
        }

        void UpdateSuppliers()
        {
            labelmanufactureEditName.Text = supplierEdit.Name;
            int supplierID = 0;
            try
            {
                supplierID = suppliers.Get(listBoxmanufactures.SelectedIndex).ID;
            }
            catch
            {

            }

            try
            {
                suppliers.GetFromBD();
                listBoxmanufactures.Items.Clear();
                for (int i = 0; i < suppliers.Count; i++)
                {
                    listBoxmanufactures.Items.Add(suppliers[i].Name);
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

                        listBoxmanufactures.SelectedIndex = supplierID;
                    }
                    catch
                    {
                        listBoxmanufactures.SelectedIndex = 0;
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

                    listBoxmanufactures.SelectedIndex = 0;
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

        Manufacture supplierEdit = new Manufacture();

        private void listBoxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelManufacture.Text = suppliers.Get(listBoxmanufactures.SelectedIndex).Name;
            }
            catch
            {
                labelManufacture.Text = "";
            }
        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;

            if(suppliers.AddToDB(textInputManufactureName.Text))
            {
                MessageBox.Show("Производитель успешно добавлен", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось добавить производителя", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            supplierEdit = new Manufacture();
            textInputManufactureName.Text = supplierEdit.Name;
            if (!UpdateForm())
                return;
        }

        private void buttonDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить производителя", "Удаление производителя", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
            {
                UpdateForm();
                return;
            }
            if (!UpdateForm())
                return;
            try
            {
                Manufacture category = suppliers.Get(listBoxmanufactures.SelectedIndex);
                int categoryID = category.ID;
                if (suppliers.DeleteFromDB(categoryID))
                {
                    MessageBox.Show("Производитель успешно удалён", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось удалить производителя", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            UpdateForm();
        }

        private void buttonSupplierCopyEdit_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            try
            {
                Manufacture category = suppliers.Get(listBoxmanufactures.SelectedIndex);
                supplierEdit = category.CopyManufacture();
                textInputManufactureName.Text = supplierEdit.Name;

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
                MessageBox.Show("Данной производитель больше не существует \n" +
                    "Попробуйте добавить данного производителя", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (suppliers.UpdateToDB(supplierEdit))
            {
                MessageBox.Show("Производитель успешно изменён", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить производителя", "Редактирование производителей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            supplierEdit = new Manufacture();
            textInputManufactureName.Text = supplierEdit.Name;

            UpdateForm();
        }

        private void textInputSupplierName_InputText_Changed(object arg1, EventArgs arg2)
        {
            supplierEdit.Name = textInputManufactureName.Text;
        }
    }
}
