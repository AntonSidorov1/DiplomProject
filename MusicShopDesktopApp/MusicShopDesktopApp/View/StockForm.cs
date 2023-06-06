using FileManegerJson;
using Microsoft.VisualBasic;
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
    public partial class StockForm : Form
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

        public StockForm()
        {
            InitializeComponent();
        }

        Stock stock = new Stock();
        public StockForm(Stock stock):this()
        {
            this.stock = stock;
        }

        string text = "";

        string textID => text + "" +stock.ID;

        private void Model_Load(object sender, EventArgs e)
        {
            text = Text;
            this.Text = textID + " - " + Application.ProductName + " - " + Application.ProductVersion;

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

            timerUpdateSities_Tick(timerUpdateSities, new EventArgs());
            timerUpdate.Start();
            return true;
        }

        bool UpdateForm()
        {
            this.Text = textID+ " - " + Application.ProductName + " - " + Application.ProductVersion;
            notifyIconApp.Text = Text;
            labelTitle.Text = textID;

            try
            {
                SitiesList sities = SitiesList.GetListFromDB();
                if (!sities.ContainsByID(stock.Sity))
                    throw new Exception();
                stock.Sity = sities.GetByID(stock.Sity);
            }
            catch
            {
                MessageBox.Show("Города больше не существует", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            buttonSave.Visible = stock.Saving() && stock.ID < 1;
            labelSity.Text = stock.Sity.Name;

            if(stock.ID > 0)
            {
                return UpdateStock();
            }
            return true;
        }

        bool UpdateStock()
        {

            try
            {
                StocksList sities = StocksList.GetListFromDB();
                if (!sities.ContainsByID(stock))
                    throw new Exception();
                stock = sities.GetByID(stock);
            }
            catch
            {
                MessageBox.Show("Данного склада больше не существует", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            textInputName.Text = stock.Name;
            textInputName.ReadOnly = true;
            textInputAddress.Text = stock.Address;
            textInputAddress.ReadOnly = true;
            textInputEmail.Text = stock.Contact.Email;
            textInputEmail.ReadOnly = true;
            textInputPhone.Text = stock.Contact.Telephone;
            textInputPhone.ReadOnly = true;

            return true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void textInputName_InputText_Changed(object arg1, EventArgs arg2)
        {
            stock.Name = textInputName.Text;
        }

        private void textInputAddress_InputText_Changed(object arg1, EventArgs arg2)
        {
            stock.Address = textInputAddress.Text;
        }

        private void textInputPhone_InputText_Changed(object arg1, EventArgs arg2)
        {
            stock.Contact.Telephone = textInputPhone.Text;
        }

        private void textInputEmail_InputText_Changed(object arg1, EventArgs arg2)
        {
            stock.Contact.Email = textInputEmail.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            textInputName_InputText_Changed(sender, e);
            textInputEmail_InputText_Changed(sender, e);
            textInputAddress_InputText_Changed(sender, e);
            textInputPhone_InputText_Changed(sender, e);
            if (!UpdateForm())
                return;
            if(stock.AddToDB())
            {
                MessageBox.Show("Склад успешно добавлен", "Добавление склада", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Не удалось добавить склад", "Добавление склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerSaveShow_Tick(object sender, EventArgs e)
        {
            buttonSave.Visible = stock.Saving() && stock.ID < 1;
        }

        private void textInputName_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonNameSet.Visible = textInputName.ReadOnly;
        }

        private void textInputPhone_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonPhoneSet.Visible = textInputPhone.ReadOnly;
        }

        private void textInputAddress_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonAddressSet.Visible = textInputAddress.ReadOnly;
        }

        private void textInputEmail_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonEmailSet.Visible = textInputEmail.ReadOnly;
        }

        private void buttonNameSet_Click(object sender, EventArgs e)
        {
            if (stock.ID > 0)
                if (!UpdateForm())
                    return;
            timerUpdate.Stop();
            string name = stock.Name;
            //stock.Name = Interaction.InputBox("Введите новое название", "Редактирование склада", stock.Name);

            if(!UpdateValue(ref name))
            {
                if (stock.ID > 0)
                    if (!UpdateForm())
                        return;
                return;
            }
            SetName(name);

            if (stock.ID < 1)
                return;
            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        void SetName(string name)
        {
            stock.Name = name;

            if (stock.ID < 1)
            {
                textInputName.Text = name;
                return;
            }

            if (stock.UpdateNameAtDB())
            {
                MessageBox.Show("Название склада успешно изменено", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить название склада", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonAddressSet_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            //stock.Address = Interaction.InputBox("Введите новый адрес", "Редактирование склада", stock.Address);

            string address = stock.Address;
            if(!UpdateValue(ref address))
            {
                if (stock.ID > 0)
                    if (!UpdateForm())
                        return;
                return;
            }


            SetAddress(address);

            if (stock.ID < 1)
                return;

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        void SetAddress(string address)
        {
            string name = address;
            stock.Address = name;

            if (stock.ID < 1)
            {
                textInputAddress.Text = name;
                return;
            }

            if (stock.UpdateAddressAtDB())
            {
                MessageBox.Show("Адрес склада успешно изменён", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить адрес склада", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonPhoneSet_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            //stock.Contact.Telephone = Interaction.InputBox("Введите новый телефон", "Редактирование склада", stock.Contact.Telephone);

            string address = stock.Contact.Telephone;
            if (!UpdateValue(ref address))
            {
                if (stock.ID > 0)
                    if (!UpdateForm())
                        return;
                return;
            }


            SetPhone(address);

            if (stock.ID < 1)
                return;


            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        void SetPhone(string phone)
        {
            string name = phone;
            stock.Contact.Telephone = phone;

            if (stock.ID < 1)
            {
                textInputPhone.Text = name;
                return;
            }

            if (stock.UpdatePhoneAtDB())
            {
                MessageBox.Show("Телефон склада успешно изменён", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить телефон склада", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonEmailSet_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            //stock.Contact.Email = Interaction.InputBox("Введите новый E-mail", "Редактирование склада", stock.Contact.Email);


            string address = stock.Contact.Email;
            if (!UpdateValue(ref address))
            {
                if (stock.ID > 0)
                    if (!UpdateForm())
                        return;
                return;
            }


            SetEmail(address);

            if (stock.ID < 1)
                return;


            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        void SetEmail(string email)
        {
            string name = email;
            stock.Contact.Email = name;

            if (stock.ID < 1)
            {
                textInputEmail.Text = name;
                return;
            }

            if (stock.UpdateEmailAtDB())
            {
                MessageBox.Show("E-mail склада успешно изменён", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить E-mail склада", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSitySet_Click(object sender, EventArgs e)
        {
            SityEditForm sityForm = new SityEditForm(textInputSity.Text);
            Hide();
            sityForm.ShowDialog();
            Show();
            if(sityForm.Save)
            {
                textInputSity.Text = sityForm.Value;
            }
        }


        bool UpdateValue(ref string value)
        {
            FormNoteEdit form = new FormNoteEdit(value);
            Hide();
            form.ShowDialog();
            Show();
            if (!form.Save)
            {
                if (stock.ID > 0)
                    UpdateForm();
                return false;
            }
            value = form.Value;
            return true;
        }

        private void buttonCopySity_Click(object sender, EventArgs e)
        {
            textInputSity.Text = stock.Sity.Name;
        }

        private void buttonUpdateTextSity_Click(object sender, EventArgs e)
        {
            if(textInputSity.Text.Length < 1)
            {
                MessageBox.Show("Введите название города в строке поиска", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(stock.ID > 0)
            {
                if(!UpdateForm())
                {
                    return;
                }
                timerUpdate.Stop();
            }

            try
            {
                SitiesList sities = SitiesList.GetListFromDB();
                string sity = textInputSity.Text;
                if (sities.ContainsOfName(sity))
                {
                    stock.Sity = sities.GetOfName(sity);
                }
                else
                {
                    if(MessageBox.Show("Введённый город не существует. Вы хотите его добавить?", "Изменение города", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.No)
                    {
                        if (stock.ID > 0)
                        {
                            if (!UpdateForm())
                            {
                                return;
                            }
                        }
                        return;
                    }
                    Sity sity1 = new Sity()
                    {
                        Name = sity
                    };
                    if(!sity1.AddToDB())
                    {
                        MessageBox.Show("Не удалось добавить город", "Добавлеение города", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception();
                    }
                    MessageBox.Show("Город успешно добавлен", "Добавлеение города", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sities.GetFromBD();
                    stock.Sity = sities.GetOfName(sity);
                }
            }
            catch
            {
                if (stock.ID > 0)
                {
                    if (!UpdateForm())
                    {
                        return;
                    }
                }
            }



            if (stock.ID > 0)
            {
                if(stock.UpdateSityAtDB())
                {
                    MessageBox.Show("Город успешно изменён", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Не удалось изменить город", "Редактирование склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!UpdateForm())
                {
                    return;
                }

            }
            timerUpdateSities_Tick(sender, e);
        }

        private void timerUpdateSity_Tick(object sender, EventArgs e)
        {
            labelSity.Text = stock.Sity.Name;

            
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (stock.ID > 0)
            {
                if (!UpdateForm())
                {
                    return;
                }
            }
            timerUpdate.Stop();

            try
            {
                textInputSity.Text = GetSity().Name;
            }
            catch
            {
                MessageBox.Show("Не удалость скопировать город", "Выбор города", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (stock.ID > 0)
            {
                if (!UpdateForm())
                {
                    return;
                }
            }
        }


        SitiesList Sities = new SitiesList();

        Sity GetSity()
        {
            Sity sity = Sities.Get(comboBoxWithNameSities.SelectedIndex);
            sity = Sities.GetByID(sity);
            return sity;
        }

        private void buttonDropSity_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить город?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
                return;

            if(stock.ID > 0)
            {
                if(!UpdateForm())
                {
                    return;
                }
            }
            timerUpdate.Stop();

            try
            {
                if (!GetSity().DeleteFromDB())
                    throw new Exception();
                MessageBox.Show("Город успешно удалён", "Удалние города", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("Не удалось удалить город", "Удалние города", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            timerUpdateSities_Tick(sender, e);
            timerUpdateSities_Tick(sender, e);

            if (stock.ID > 0)
            {
                if (!UpdateForm())
                {
                    return;
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            
                timerUpdate_Tick(sender, e);
            
            timerUpdateSities_Tick(sender, e);
        }

        private void timerUpdateSities_Tick(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = GetSity().ID;
            }
            catch
            {

            }

            try
            {
                Sities.GetFromBD();
            }
            catch
            {

            }

            try
            {
                comboBoxWithNameSities.Items.Clear();
                for (int i = 0; i < Sities.Count; i++)
                {
                    comboBoxWithNameSities.Items.Add(Sities[i].Name);
                }
            }
            catch
            {

            }

            try
            {
                int index = Sities.IndexOfByID(id);
                if (index < 0)
                    throw new Exception();
                comboBoxWithNameSities.SelectedIndex = index;
            }
            catch
            {
                try
                {
                    comboBoxWithNameSities.SelectedIndex = 0;
                }
                catch
                {

                }
            }

        }
    }
}
