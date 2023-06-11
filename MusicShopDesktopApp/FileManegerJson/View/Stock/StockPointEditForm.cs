using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public partial class StockPointEditForm : Form
    {
        public StockPointEditForm()
        {
            InitializeComponent();

        }

        public StockPointEditForm(StoreHouse organization):this()
        {

            Organization = organization.CopyStock();
            OrganizationUpdate = organization.CopyStock();

        }

        StoreHouse organization = new StoreHouse();

        StoreHouse organizationUpdate = new StoreHouse();

        bool save = false;

        public bool Save
        {
            get => save;
            set => save = value;
        }

        public StoreHouse Organization
        {
            get => organization;
            set
            {
                organization = value;
                UpdateOrganization();
            }
        }

        public StoreHouse OrganizationUpdate
        {
            get => organizationUpdate;
            set
            {
                organizationUpdate = value;
            }
        }

        void UpdateOrganization()
        {
            textBoxName.Value = Organization.Name;
            textBoxWihSetAddress.Value = Organization.Address;
            textBoxWihSetPhone.Value = Organization.Telephone;
            textBoxWihSetEmail.Value = Organization.Email;
            textBoxSity.Value = Organization.Sity;
        }

        private void OrganizationForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public delegate void SaveOrganizationParameter(string paramter);
        public delegate void SaveOrganization(StoreHouse organization);

        public event SaveOrganizationParameter ChangeName;
        public event SaveOrganizationParameter ChangeAddress;
        public event SaveOrganizationParameter ChangePhone;
        public event SaveOrganizationParameter ChangeEmail;
        public event SaveOrganizationParameter ChangeSity;
        public event SaveOrganization ChangeOrganization;



        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save = true;

            if (checkBoxName.Checked)
            {
                OrganizationUpdate.Name = Organization.Name;
                ChangeName?.Invoke(organization.Name);
            }

            if (checkBoxAddress.Checked)
            {
                OrganizationUpdate.Address = Organization.Address;
                ChangeAddress?.Invoke(organization.Address);
            }

            if (checkBoxPhone.Checked)
            {
                OrganizationUpdate.Telephone = Organization.Telephone;
                ChangePhone?.Invoke(organization.Telephone);
            }

            if (checkBoxEmail.Checked)
            {
                OrganizationUpdate.Email = Organization.Email;
                ChangeEmail?.Invoke(organization.Email);
            }

            if (checkBoxSity.Checked)
            {
                OrganizationUpdate.Sity = Organization.Sity;
                ChangeSity?.Invoke(organization.Sity);
            }

            ChangeOrganization?.Invoke(OrganizationUpdate);
            buttonBack_Click(sender, e);
        }

        private void buttonRunWindowEdit_Click(object sender, EventArgs e)
        {
            TraidingPointEditForm form = new TraidingPointEditForm(organization);
            form.ChangeName += Form_ChangeName;
            form.ChangeAddress += Form_ChangeAddress;
            form.ChangePhone += Form_ChangePhone;
            form.ChangeEmail += Form_ChangeEmail;
            form.ChangeOrganization += Form_ChangeOrganization1; ;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeOrganization1(DistributingPoint organization)
        {
            UpdateOrganization();
        }

        private void Form_ChangeOrganization(StoreHouse organization)
        {
            UpdateOrganization();
        }

        private void Form_ChangeEmail(string paramter)
        {
            Organization.Email = paramter;
        }

        private void Form_ChangePhone(string paramter)
        {
            Organization.Telephone = paramter;
        }

        private void Form_ChangeAddress(string paramter)
        {
            Organization.Address = paramter;
        }

        private void Form_ChangeName(string paramter)
        {
            Organization.Name = paramter;
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            bool check = true;
            checkBoxName.Checked = check;
            checkBoxAddress.Checked = check;
            checkBoxPhone.Checked = check;
            checkBoxEmail.Checked = check;
            checkBoxSity.Checked = check;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bool check = false;
            checkBoxName.Checked = check;
            checkBoxAddress.Checked = check;
            checkBoxPhone.Checked = check;
            checkBoxEmail.Checked = check;
            checkBoxSity.Checked = check;
        }

        private void buttonByManager_Click(object sender, EventArgs e)
        {
            StockFile organization = new StockFile(Organization);
            bool yes = false;
            DiskForm disk = new DiskForm(organization, ref yes);
            Hide();
            disk.ShowDialog();
            Show();
            if(disk.Choosen)
            {
                try
                {
                    FileClass fileClass = disk.FileClass;
                    if (fileClass.IsStock)
                        Organization = fileClass.AsStock.Content;
                }
                catch
                {

                }
                UpdateOrganization();
            }
        }

        private void textBoxName_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Name = text;
        }

        private void textBoxWihSetAddress_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Address = text;
        }

        private void textBoxWihSetPhone_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Telephone = text;
        }

        private void textBoxWihSetEmail_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Email = text;
        }

        private void VieFewWindow_Click(object sender, EventArgs e)
        {
            StockPointEditForm form = new StockPointEditForm(organization);
            form.ChangeName += Form_ChangeName;
            form.ChangeAddress += Form_ChangeAddress;
            form.ChangePhone += Form_ChangePhone;
            form.ChangeEmail += Form_ChangeEmail;
            form.ChangeSity += Form_ChangeSity;
            form.ChangeOrganization += Form_ChangeOrganization;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeSity(string paramter)
        {
            Organization.Sity = paramter;
        }

        private void textBoxSity_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Sity = text;
        }

        private void buttonChangeSity_Click(object sender, EventArgs e)
        {
            SityEditForm form = new SityEditForm(Organization.Sity);
            Hide();
            form.ShowDialog();
            Show();
            if(form.Save)
            {
                Organization.Sity = form.Value;
                UpdateOrganization();
            }
        }
    }
}
