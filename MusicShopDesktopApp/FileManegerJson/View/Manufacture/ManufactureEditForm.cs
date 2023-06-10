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
    public partial class ManufactureEditForm : Form
    {
        public ManufactureEditForm()
        {
            InitializeComponent();

        }

        public ManufactureEditForm(ProductParameter organization):this()
        {

            Organization = organization.CopyCategory();
            OrganizationUpdate = organization.CopyCategory();

        }

        ProductParameter organization = new ProductParameter();

        ProductParameter organizationUpdate = new ProductParameter();

        bool save = false;

        public bool Save
        {
            get => save;
            set => save = value;
        }

        public ProductParameter Organization
        {
            get => organization;
            set
            {
                organization = value;
                UpdateOrganization();
            }
        }

        public ProductParameter OrganizationUpdate
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
        public delegate void SaveOrganization(ProductParameter organization);

        public event SaveOrganizationParameter ChangeName;
        public event SaveOrganizationParameter ChangeFilter;
        public event SaveOrganization ChangeOrganization;



        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save = true;

            if (checkBoxName.Checked)
            {
                OrganizationUpdate.Name = Organization.Name;
                ChangeName?.Invoke(organization.Name);
            }

            ChangeOrganization?.Invoke(OrganizationUpdate);
            buttonBack_Click(sender, e);
        }

        private void buttonRunWindowEdit_Click(object sender, EventArgs e)
        {
            ManufactureEditForm form = new ManufactureEditForm(organization);
            form.ChangeName += Form_ChangeName;
            form.ChangeOrganization += Form_ChangeOrganization;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeOrganization(ProductParameter organization)
        {
            UpdateOrganization();
        }

        private void Form_ChangeName(string paramter)
        {
            Organization.Name = paramter;
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            bool check = true;
            checkBoxName.Checked = check;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bool check = false;
            checkBoxName.Checked = check;
        }

        private void buttonByManager_Click(object sender, EventArgs e)
        {
            ManufactureFile organization = new ManufactureFile(Organization);
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
                    if (fileClass.IsManufacture)
                        Organization = fileClass.AsManufacture.Content;
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

    }
}
