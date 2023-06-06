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
    public partial class OrganizationEditForm : Form
    {
        public OrganizationEditForm()
        {
            InitializeComponent();

        }

        public OrganizationEditForm(DisributingFacilities organization):this()
        {

            Organization = organization.CopyOrganization();
            OrganizationUpdate = organization.CopyOrganization();

        }

        DisributingFacilities organization = new DisributingFacilities();

        DisributingFacilities organizationUpdate = new DisributingFacilities();

        bool save = false;

        public bool Save
        {
            get => save;
            set => save = value;
        }

        public DisributingFacilities Organization
        {
            get => organization;
            set
            {
                organization = value;
                UpdateOrganization();
            }
        }

        public DisributingFacilities OrganizationUpdate
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
            textBoxWihSite.Value = Organization.Site;
            textBoxWihSetPhone.Value = Organization.Telephone;
            textBoxWihSetEmail.Value = Organization.Email;
            linkLabelSite.Text = Organization.Site;
            pictureBoxLogotip.Image = Organization.ImageLogoip;
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
        public delegate void SaveOrganizationSetLogotip(byte[] paramter);
        public delegate void SaveOrganizationNoLogotip();
        public delegate void SaveOrganization(DisributingFacilities organization);

        public event SaveOrganizationParameter ChangeName;
        public event SaveOrganizationParameter ChangeAddress;
        public event SaveOrganizationParameter ChangeSite;
        public event SaveOrganizationParameter ChangePhone;
        public event SaveOrganizationParameter ChangeEmail;
        public event SaveOrganizationSetLogotip SetLogotip;
        public event SaveOrganizationNoLogotip DropLogoip;
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

            if (checkBoxSite.Checked)
            {
                OrganizationUpdate.Site = Organization.Site;
                ChangeSite?.Invoke(organization.Site);
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

            if(checkBoxLogotip.Checked)
            {
                if(organization.HaveLogotip)
                {
                    OrganizationUpdate.Logotip = Organization.Logotip;
                    SetLogotip?.Invoke(organization.LogotipBytes);
                }
                else
                {
                    OrganizationUpdate.Logotip = "";
                    DropLogoip?.Invoke();
                }
            }

            ChangeOrganization?.Invoke(OrganizationUpdate);
            buttonBack_Click(sender, e);
        }

        private void buttonRunWindowEdit_Click(object sender, EventArgs e)
        {
            OrganizationEditForm form = new OrganizationEditForm(organization);
            form.ChangeName += Form_ChangeName;
            form.ChangeAddress += Form_ChangeAddress;
            form.ChangeSite += Form_ChangeSite;
            form.ChangePhone += Form_ChangePhone;
            form.ChangeEmail += Form_ChangeEmail;
            form.SetLogotip += Form_SetLogotip;
            form.DropLogoip += Form_DropLogoip;
            form.ChangeOrganization += Form_ChangeOrganization;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeOrganization(DisributingFacilities organization)
        {
            UpdateOrganization();
        }

        private void Form_DropLogoip()
        {
            Organization.Logotip = "";
        }

        private void Form_SetLogotip(byte[] paramter)
        {
            Organization.LogotipBytes = paramter;
        }

        private void Form_ChangeEmail(string paramter)
        {
            Organization.Email = paramter;
        }

        private void Form_ChangePhone(string paramter)
        {
            Organization.Telephone = paramter;
        }

        private void Form_ChangeSite(string paramter)
        {
            Organization.Site = paramter;
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
            checkBoxSite.Checked = check;
            checkBoxPhone.Checked = check;
            checkBoxEmail.Checked = check;
            checkBoxLogotip.Checked = check;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bool check = false;
            checkBoxName.Checked = check;
            checkBoxAddress.Checked = check;
            checkBoxSite.Checked = check;
            checkBoxPhone.Checked = check;
            checkBoxEmail.Checked = check;
            checkBoxLogotip.Checked = check;
        }

        private void buttonByManager_Click(object sender, EventArgs e)
        {
            OrganizaionFile organization = new OrganizaionFile(Organization);
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
                    if (fileClass.IsOrganizaion)
                        Organization = fileClass.AsOrganizaion.Content;
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

        private void textBoxWihSite_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Site = text;
            linkLabelSite.Text = text;
        }

        private void textBoxWihSetPhone_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Telephone = text;
        }

        private void textBoxWihSetEmail_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Email = text;
        }

        private void linkLabelSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = (sender as LinkLabel).Text;
                process.Start();
            }
            catch
            {

            }
        }

        private void buttonDrop_Click(object sender, EventArgs e)
        {
            Organization.Logotip = "";
            UpdateOrganization();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            ImageFile image = new ImageFile();
            if (organization.HaveLogotip)
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

            UpdateOrganization();

        }

        private void buttonTraidingPoint_Click(object sender, EventArgs e)
        {
            TraidingPointEditForm form = new TraidingPointEditForm(organization);
            form.ChangeName += Form_ChangeName;
            form.ChangeAddress += Form_ChangeAddress;
            form.ChangePhone += Form_ChangePhone;
            form.ChangeEmail += Form_ChangeEmail;
            form.ChangeOrganization += Form_ChangeOrganization1;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeOrganization1(DistributingPoint organization)
        {
            UpdateOrganization();
        }
    }
}
