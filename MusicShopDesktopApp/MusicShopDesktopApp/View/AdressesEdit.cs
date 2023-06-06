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
    public partial class AdressesEdit : Form
    {
        AddressType type;

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

        public AddressType Type
        {
            get => type;
            set => type = value;
        }

        public AdressesEdit(AddressType type = AddressType.Telefon)
        {
            Type = type;
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            labelTitle.Text = Helper.GetAddressEditType(Type);
            Text = labelTitle.Text;
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            comboBoxWithNameAddress.Title = Helper.GetAddressType(Type, false);
            textInputAddress.Title = Helper.GetAddressType(Type, true);

            comboBoxWithNameAddress.ReadOnlyChanged += comboBoxWithNameAddress_EnabledChanged;

            buttonUpdate_Click(sender, e);
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

        private void comboBoxWithNameAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBoxAddresses.SelectedIndex = (sender as ComboBoxWithName).SelectedIndex;
            }
            catch
            {

            }

            try
            {
                int index = (sender as ComboBoxWithName).SelectedIndex;
                Address address = addresses[index];
                textInputAddress.Text = address.Value;
            }
            catch
            {
                textInputAddress.Text = "";
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            buttonUpdate_Click(sender, e);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate_Click(sender, e, 20);
        }

        AddressesList addresses = new AddressesList();

        void buttonUpdate_Click(object sender, EventArgs e, int count)
        {
            timerUpdate.Stop();
            int index = 0;
            if (comboBoxWithNameAddress.Items.Count < 1)
            {
                comboBoxWithNameAddress.ReadOnly = true;
            }
            else
            {
                index = comboBoxWithNameAddress.SelectedIndex;
            }

            comboBoxWithNameAddress.Items.Clear();
            if (!DataBaseConfiguration.Check())
            {
                if(count > 0)
                {
                    buttonUpdate_Click(sender, e, count - 1);
                }
                else
                {
                    MessageBox.Show("Невозможно подключиться к базе данных", "Подключение к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                return;
            }

            if(Helper.UserIsGoest())
            {
                MessageBox.Show("Вы больше не авторизированы", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            try
            {
                
                if(Type == AddressType.Telefon)
                {
                    addresses = TelefonsController.GetController().Get(Helper.GetSession()).GetAddresses();
                }
                else
                {
                    addresses = EmailsController.GetController().Get(Helper.GetSession()).GetAddresses();
                }
                comboBoxWithNameAddress.Items.Clear();
                listBoxAddresses.Items.Clear();
                comboBoxWithNameAddress.Items.AddRange(addresses.GetItems());
                listBoxAddresses.Items.AddRange(addresses.GetItems());
            }
            catch
            {
                if(count > 0)
                {
                    buttonUpdate_Click(sender, e, count - 1);
                    return;
                }
                MessageBox.Show($"Вы больше не авторизированы", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }


            timerUpdate.Start();
            string address = textInputAddress.Text;
            if(comboBoxWithNameAddress.Items.Count > 0)
            {
                try
                {
                    comboBoxWithNameAddress.ReadOnly = false;
                    comboBoxWithNameAddress.SelectedIndex = index;
                }
                catch
                {
                    try
                    {
                        comboBoxWithNameAddress.SelectedIndex = 0;
                    }
                    catch
                    {
                        
                    }

                }
            }
            else
            {

                comboBoxWithNameAddress.ReadOnly = true;
            }

            textInputAddress.Text = address;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();

            bool success = true;
            if(Type == AddressType.Telefon)
            {
                success = Helper.AddTelefon(textInputAddress.Text);
            }
            else
            {
                success = Helper.AddEmail(textInputAddress.Text);
            }

            if(!success)
            {
                MessageBox.Show($"Не удалось добавить {Helper.GetAddressType(Type)} \n" +
                    $"Возможно он уже существует", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"{Helper.GetAddressType(Type)} успешно добавлен", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            buttonUpdate_Click(sender, e);
            timerUpdate.Start();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            int id = 0;
            try
            {
                int index = comboBoxWithNameAddress.SelectedIndex;
                id = addresses[index].ID;
            }
            catch
            {
                MessageBox.Show($"Не удалось удалить {Helper.GetAddressType(Type)} \n" +
                    $"Возможно он больше ну существует", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                timerUpdate.Start();
                return;
            }

            bool success = true;
            if (Type == AddressType.Telefon)
            {
                success = Helper.DeleteTelefon(id);
            }
            else
            {
                success = Helper.DeleteEmail(id);
            }

            if (!success)
            {
                MessageBox.Show($"Не удалось удалить {Helper.GetAddressType(Type)}", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"{Helper.GetAddressType(Type)} успешно удалён", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            buttonUpdate_Click(sender, e);
            timerUpdate.Start();
        }

        private void comboBoxWithNameAddress_EnabledChanged(object sender, EventArgs e)
        {
            ComboBoxWithName comboBox = (sender as ComboBoxWithName);
            buttonDelete.Enabled = comboBox.Enabled && !comboBox.ReadOnly;
        }

        private void listBoxAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxWithNameAddress.SelectedIndex = (sender as ListBox).SelectedIndex;
            }
            catch
            {

            }
        }
    }
}
