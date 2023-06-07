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
    public partial class StorePointEditForm : Form
    {
        public StorePointEditForm()
        {
            InitializeComponent();

        }

        public StorePointEditForm(Store organization):this()
        {

            Organization = organization.CopyStore();
            OrganizationUpdate = organization.CopyStore();

        }

        Store organization = new Store();

        Store organizationUpdate = new Store();

        bool save = false;

        public bool Save
        {
            get => save;
            set => save = value;
        }

        public Store Organization
        {
            get => organization;
            set
            {
                organization = value;
                UpdateOrganization();
            }
        }

        public Store OrganizationUpdate
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
            textBoxWihSetShedule.Value = Organization.Schedule;
            textBoxWihSetSitePath.Value = Organization.SitePath;
            textBoxWihSetShop.Value = Organization.Shop;
            textBoxWihSetPickupPoint.Value = Organization.PounktOfIssue;
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
        public delegate void SaveOrganization(Store organization);

        public event SaveOrganizationParameter ChangeName;
        public event SaveOrganizationParameter ChangeAddress;
        public event SaveOrganizationParameter ChangePhone;
        public event SaveOrganizationParameter ChangeEmail;
        public event SaveOrganizationParameter ChangeScedule;
        public event SaveOrganizationParameter ChangeSitePath;
        public event SaveOrganizationParameter ChangeShop;
        public event SaveOrganizationParameter ChangePickupPoint;
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

            if (checkBoxShedule.Checked)
            {
                OrganizationUpdate.Schedule = Organization.Schedule;
                ChangeScedule?.Invoke(organization.Schedule);
            }

            if (checkBoxSitePath.Checked)
            {
                OrganizationUpdate.SitePath = Organization.SitePath;
                ChangeSitePath?.Invoke(organization.SitePath);
            }

            if (checkBoxShop.Checked)
            {
                OrganizationUpdate.Shop = Organization.Shop;
                ChangeShop?.Invoke(organization.Shop);
            }

            if (checkBoxPickupPoint.Checked)
            {
                OrganizationUpdate.PickupPoint = Organization.PickupPoint;
                ChangePickupPoint?.Invoke(organization.Shop);
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

        private void Form_ChangeOrganization(Store organization)
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
            checkBoxShedule.Checked = check;
            checkBoxSitePath.Checked = check;
            checkBoxShop.Checked = check;
            checkBoxPickupPoint.Checked = check;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bool check = false;
            checkBoxName.Checked = check;
            checkBoxAddress.Checked = check;
            checkBoxPhone.Checked = check;
            checkBoxEmail.Checked = check;
            checkBoxShedule.Checked = check;
            checkBoxSitePath.Checked = check;
            checkBoxShop.Checked = check;
            checkBoxPickupPoint.Checked = check;
        }

        private void buttonByManager_Click(object sender, EventArgs e)
        {
            StoreFile organization = new StoreFile(Organization);
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
                    if (fileClass.IsStore)
                        Organization = fileClass.AsStore.Content;
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
            StorePointEditForm form = new StorePointEditForm(organization);
            form.ChangeName += Form_ChangeName;
            form.ChangeAddress += Form_ChangeAddress;
            form.ChangePhone += Form_ChangePhone;
            form.ChangeEmail += Form_ChangeEmail;
            form.ChangeScedule += Form_ChangeScedule;
            form.ChangeSitePath += Form_ChangeSitePath;
            form.ChangeShop += Form_ChangeShop;
            form.ChangePickupPoint += Form_ChangePickupPoint;
            form.ChangeOrganization += Form_ChangeOrganization;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangePickupPoint(string paramter)
        {
            Organization.PounktOfIssue = paramter;
        }

        private void Form_ChangeShop(string paramter)
        {
            Organization.Shop = paramter;
        }

        private void Form_ChangeSitePath(string paramter)
        {
            Organization.SitePath = paramter;
        }

        private void Form_ChangeScedule(string paramter)
        {
            Organization.Schedule = paramter;
        }

        private void textBoxWihSetShedule_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Schedule = text;
        }

        private void textBoxWihSetSitePath_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.SitePath = text;
        }

        private void textBoxWihSetShop_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Shop = text;
        }

        private void textBoxWihSetPickupPoint_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.PounktOfIssue = text;
        }
    }
}
