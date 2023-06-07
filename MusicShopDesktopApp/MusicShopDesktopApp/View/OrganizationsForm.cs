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
    public partial class OrganizationsForm : Form
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

        public OrganizationsForm()
        {
            InitializeComponent();
        }

        public OrganizationsForm(Organization organization):this()
        {
            this.organization = organization;
        }

        Organization organization = new Organization();
        string text = "";

        string textID => text + " " + organization.ID;

        private void Model_Load(object sender, EventArgs e)
        {
            text = Text;

            this.Text = textID + " - " + Application.ProductName + " - " + Application.ProductVersion;
            notifyIconApp.Text = Text;
            labelTitle.Text = textID;

            if (organization.ID > 0)
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
            this.Text = textID+ " - " + Application.ProductName + " - " + Application.ProductVersion;
            notifyIconApp.Text = Text;
            labelTitle.Text = textID;

            try
            {
                organization = OrganizationsList.GetListFromDB().GetByID(organization).CopyOrganization();
            }
            catch
            {
                MessageBox.Show("данной организации больше не существует", "Редактирование организации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            textInputName.ReadOnly = true;
            textInputName.Text = organization.Name;
            textInputAddress.ReadOnly = true;
            textInputAddress.Text = organization.Address;
            textInputSite.ReadOnly = true;
            textInputSite.Text = organization.Site;
            textInputEmail.ReadOnly = true;
            textInputEmail.Text = organization.Contact.Email;
            textInputPhone.ReadOnly = true;
            textInputPhone.Text = organization.Contact.Telephone;

            return true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void timerUpdateOrganization_Tick(object sender, EventArgs e)
        {
            buttonSave.Visible = organization.Saving() && organization.ID < 1;
            buttonUpdate.Visible = organization.ID > 0;
        }

        private void textInputName_InputText_Changed(object arg1, EventArgs arg2)
        {
            organization.Name = textInputName.Text;
        }

        private void textInputName_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonNameSet.Visible = textInputName.ReadOnly;
        }

        private void textInputAddress_InputText_Changed(object arg1, EventArgs arg2)
        {
            organization.Address = textInputAddress.Text;
        }

        private void textInputAddress_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonAddressSet.Visible = textInputAddress.ReadOnly;
        }

        private void buttonNameSet_Click(object sender, EventArgs e)
        {
            if (organization.ID > 0)
                if (!UpdateForm())
                    return;
            timerUpdate.Stop();
            //organization.Name = Interaction.InputBox("Введите новое название", "Редактирование организации", organization.Name);

            FormNoteEdit form = new FormNoteEdit(organization.Name);
            Hide();
            form.ShowDialog();
            Show();
            if(!form.Save)
            {
                if(organization.ID < 1)
                {
                    return;
                }
                UpdateForm();
                return;
            }
            SetName(form.Value);

            if (organization.ID < 1)
            {
                return;
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        void SetName(string name)
        {
            organization.Name = name;
            if (organization.ID < 1)
            {
                textInputName.Text = organization.Name;
                return;
            }

            if (organization.UpdateNameAtDB())
            {
                MessageBox.Show("Название организации успешно изменено", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить название организации", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (organization.ID > 0)
                    UpdateForm();
                return false;
            }
            value = form.Value;
            return true;
        }

        private void buttonAddressSet_Click(object sender, EventArgs e)
        {
            if (organization.ID > 0)
                if (!UpdateForm())
                    return;
            timerUpdate.Stop();

            //organization.Address = Interaction.InputBox("Введите новый адрес", "Редактирование организации", organization.Address);

            string address = organization.Address;
            if(!UpdateValue(ref address))
            {
                return;
            }

            SetAddress(address);

            if (organization.ID < 1)
            {
                return;
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        void SetAddress(string address)
        {
            organization.Address = address;
            if (organization.ID < 1)
            {
                textInputAddress.Text = organization.Address;
                return;
            }

            if (organization.UpdateAddressAtDB())
            {
                MessageBox.Show("Адрес организации успешно изменён", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить адрес организации", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            textInputAddress_InputText_Changed(sender, e);
            textInputName_InputText_Changed(sender, e);
            textInputSite_InputText_Changed(sender, e);
            textInputPhone_InputText_Changed(sender, e);
            textInputEmail_InputText_Changed(sender, e);

            if (organization.AddToDB())
            {
                MessageBox.Show("Организация успешно добавлена", "Добавление организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (organization.ID < 1)
                    Close();
                else
                    timerUpdate_Tick(sender, e);
            }
            else
            {

                MessageBox.Show("Не удалось добавить организацию", "Добавление организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textInputSite_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonSiteSet.Visible = textInputSite.ReadOnly;
        }

        private void textInputSite_InputText_Changed(object arg1, EventArgs arg2)
        {
            organization.Site = textInputSite.Text;
        }

        private void buttonSiteSet_Click(object sender, EventArgs e)
        {
            if (organization.ID > 0)
                if (!UpdateForm())
                    return;
            timerUpdate.Stop();

            //organization.Site = Interaction.InputBox("Введите новый адрес сайта", "Редактирование организации", organization.Site);

            string address = organization.Site;
            if (!UpdateValue(ref address))
            {
                return;
            }

            SetSite(address);

            if (organization.ID < 1)
            {
                return;
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        public void SetSite(string site)
        {
            string address = site;
            organization.Site = address;
            if (organization.ID < 1)
            {
                textInputSite.Text = organization.Site;
                return;
            }

            if (organization.UpdateSiteAtDB())
            {
                MessageBox.Show("Адрес сайта организации успешно изменён", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить адрес сайта организации", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textInputPhone_InputText_Changed(object arg1, EventArgs arg2)
        {
            organization.Contact.Telephone = textInputPhone.Text;
        }

        private void textInputEmail_InputText_Changed(object arg1, EventArgs arg2)
        {
            organization.Contact.Email = textInputEmail.Text;
        }

        private void textInputPhone_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonPhoneSet.Visible = textInputPhone.ReadOnly;
        }

        private void textInputEmail_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            //buttonEmailSet.Visible = textInputEmail.ReadOnly;
        }

        private void buttonPhoneSet_Click(object sender, EventArgs e)
        {
            if (organization.ID > 0)
                if (!UpdateForm())
                    return;
            timerUpdate.Stop();

            //organization.Contact.Telephone = Interaction.InputBox("Введите новый телефон", "Редактирование организации", organization.Contact.Telephone);

            string address = organization.Contact.Telephone;
            if (!UpdateValue(ref address))
            {
                return;
            }

            SetPhone(address);

            if (organization.ID < 1)
            {
                return;
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        void SetPhone(string phone)
        {
            string address = phone;

            organization.Contact.Telephone = address;

            if (organization.ID < 1)
            {
                textInputPhone.Text = organization.Contact.Telephone;
                return;
            }

            if (organization.UpdatePhoneAtDB())
            {
                MessageBox.Show("Телефон организации успешно изменён", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить телефон организации", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void SetEmail(string phone)
        {
            string address = phone;


            organization.Contact.Email = address;

            if (organization.ID < 1)
            {
                textInputEmail.Text = organization.Contact.Email;
                return;
            }

            if (organization.UpdateEmailAtDB())
            {
                MessageBox.Show("E-mail организации успешно изменён", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить E-mail организации", "Редактирование организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonEmailSet_Click(object sender, EventArgs e)
        {
            if (organization.ID > 0)
                if (!UpdateForm())
                    return;
            timerUpdate.Stop();

            //organization.Contact.Email = Interaction.InputBox("Введите новый E-mail", "Редактирование организации", organization.Contact.Email);

            string address = organization.Contact.Email;
            if (!UpdateValue(ref address))
            {
                return;
            }

            SetEmail(address);

            if (organization.ID < 1)
            {
                return;
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        private void timerImage_Tick(object sender, EventArgs e)
        {

            try
            {
                if (organization.HaveImage)
                    pictureBoxImage.Image = organization.LogotipImage;
                else
                    pictureBoxImage.Image = null;
            }
            catch
            {
                pictureBoxImage.Image = new Bitmap(100, 100);
            }
            bool visible = organization.HaveImage;
            buttonImageSet.Visible = !visible;
            buttonImageChange.Visible = visible;
            buttonImageDrop.Visible = visible;

        }

        private void buttonImageSet_Click(object sender, EventArgs e)
        {
            ImageFile image = new ImageFile();
            if (organization.HaveImage)
            {
                image.Image = organization.LogotipImage;
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

            if (disk.YesChoose)
            {

                try
                {
                    organization.LogotipImage = new Bitmap(image.Image);
                }
                catch
                {

                }
            }
            image.Dispose();
            disk.Dispose();


            if (organization.ID > 0)
            {
                organization.UpdateLogotipAtDB();
                timerDateTime_Tick(sender, e);
            }
        }

        private void buttonImageDrop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить логотип организации", "Редактирование организации",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
            {
                if (organization.ID > 0)
                    timerDateTime_Tick(sender, e);
                return;
            }

            LogotipDrop();
            timerDateTime_Tick(timerUpdate, new EventArgs());
        }

        void LogotipDrop()
        {
            organization.Logotip = "";

            if (organization.ID > 0)
            {
                if(organization.UpdateLogotipAtDB())
                {
                    MessageBox.Show("Логотип успешно удалён", "Удаление логотипа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить логотип", "Удаление логотипа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if(organization.ID > 0)
            {
                if(!UpdateView())
                {
                    return;
                }
            }
            OrganizationEditForm form = new OrganizationEditForm(organization.CopyOrganizationEdit());
            form.ChangeName += SetName;
            form.ChangeAddress += SetAddress;
            form.ChangeSite += SetSite;
            form.ChangePhone += SetPhone;
            form.ChangeEmail += SetEmail;
            form.DropLogoip += LogotipDrop;
            form.SetLogotip += Form_SetLogotip;
            Hide();
            form.ShowDialog();
            Show();


            if (organization.ID > 0)
            {
                if (!UpdateView())
                {
                    return;
                }
            }
        }

        private void Form_SetLogotip(byte[] paramter)
        {
            organization.LogotipBytes = paramter;
            if(organization.ID > 0)
            {
                if (organization.UpdateLogotipAtDB())
                {
                    MessageBox.Show("Логотип успешно обновлён", "Обновление логотипа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось обновить логотип", "Обновление логотипа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
