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
    public partial class TraidingPointEditForm : Form
    {
        public TraidingPointEditForm()
        {
            InitializeComponent();

        }

        public TraidingPointEditForm(DistributingPoint organization):this()
        {

            Organization = organization.CopyTraidingPoint();
            OrganizationUpdate = organization.CopyTraidingPoint();

        }

        DistributingPoint organization = new DistributingPoint();

        DistributingPoint organizationUpdate = new DistributingPoint();

        bool save = false;

        public bool Save
        {
            get => save;
            set => save = value;
        }

        public DistributingPoint Organization
        {
            get => organization;
            set
            {
                organization = value;
                UpdateOrganization();
            }
        }

        public DistributingPoint OrganizationUpdate
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
        public delegate void SaveOrganization(DistributingPoint organization);

        public event SaveOrganizationParameter ChangeName;
        public event SaveOrganizationParameter ChangeAddress;
        public event SaveOrganizationParameter ChangePhone;
        public event SaveOrganizationParameter ChangeEmail;
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
            form.ChangeOrganization += Form_ChangeOrganization;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeOrganization(DistributingPoint organization)
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
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bool check = false;
            checkBoxName.Checked = check;
            checkBoxAddress.Checked = check;
            checkBoxPhone.Checked = check;
            checkBoxEmail.Checked = check;
        }

        private void buttonByManager_Click(object sender, EventArgs e)
        {
            TraidingPointFile organization = new TraidingPointFile(Organization);
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
                    if (fileClass.IsTraidingPoint)
                        Organization = fileClass.AsTraidingPoint.Content;
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

    }
}
