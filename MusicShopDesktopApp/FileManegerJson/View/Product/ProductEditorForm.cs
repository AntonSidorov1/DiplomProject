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
    public partial class ProductEditorForm : Form
    {
        public ProductEditorForm()
        {
            InitializeComponent();

        }

        public ProductEditorForm(ProductClass organization):this()
        {

            Organization = organization.CopyProduct();
            OrganizationUpdate = organization.CopyProduct();

        }

        ProductClass organization = new ProductClass();

        ProductClass organizationUpdate = new ProductClass();

        bool save = false;

        public bool Save
        {
            get => save;
            set => save = value;
        }

        public ProductClass Organization
        {
            get => organization;
            set
            {
                organization = value;
                UpdateOrganization();
            }
        }

        public ProductClass Product
        {
            get => Organization;
            set
            {
                Organization = value;
            }
        }



        public ProductClass OrganizationUpdate
        {
            get => organizationUpdate;
            set
            {
                organizationUpdate = value;
            }
        }

        public ProductClass ProductUpdate
        {
            get => OrganizationUpdate;
            set
            {
                OrganizationUpdate = value;
            }
        }

        void UpdateOrganization()
        {
            textBoxName.Value = Organization.Name;
            textBoxWihSetArticul.Value = Product.Articul;
            textBoxWihSetDescription.Value = Product.Description;
            pictureBoxPhoto.Image = Product.ImageOutput;
            numericControlWithSetPrice.Value = Convert.ToDecimal(Product.Price);
            textInputEditPrice.Text = Product.Price.ToString("C2");
            numericControlWithSetDiscount.Value = Convert.ToDecimal(Product.Discount);
            textInputEditDiscount.Text = Product.DiscountSum.ToString("C2");
            textInputEditPriceWithDiscount.Text = Product.PriceWithDiscount.ToString("C2");
            textBoxWihSetCategory.Text = Product.Category;
            textBoxWihSetManufacture.Text = Product.Manufacture;
            textBoxWihSetSupplier.Text = Product.Supplier;
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
        public delegate void SaveOrganization(ProductClass organization);

        public event SaveOrganizationParameter ChangeName;
        public event SaveOrganizationParameter ChangeArticul;
        public event SaveOrganizationParameter ChangeDescripion;
        public event SaveOrganization ChangeOrganization;
        public event SaveOrganizationParameter ChangeCategory;
        public event SaveOrganizationParameter ChangeSupplier;
        public event SaveOrganizationParameter ChangeManufacture;

        public delegate void SaveOrganizationSetPhoto(byte[] paramter);
        public delegate void SaveOrganizationNoPhoto();

        public event SaveOrganizationSetPhoto SetPhoto;
        public event SaveOrganizationNoPhoto DropPhoto;


        public delegate void SaveOrganizationNumber(int number);
        public event SaveOrganizationNumber ChangeDiscount;

        public delegate void SaveOrganizationRealNumber(double number);
        public event SaveOrganizationRealNumber ChangePrice;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save = true;

            if (checkBoxArticul.Checked)
            {
                ProductUpdate.Articul = Product.Articul;
                ChangeArticul?.Invoke(Product.Articul);
            }

            if (checkBoxName.Checked)
            {
                OrganizationUpdate.Name = Organization.Name;
                ChangeName?.Invoke(organization.Name);
            }

            if (checkBoxDescription.Checked)
            {
                OrganizationUpdate.Description = Organization.Description;
                ChangeDescripion?.Invoke(organization.Description);
            }

            if (checkBoxManufacture.Checked)
            {
                OrganizationUpdate.Manufacture = Organization.Manufacture;
                ChangeManufacture?.Invoke(organization.Manufacture);
            }

            if (checkBoxSupplier.Checked)
            {
                OrganizationUpdate.Supplier = Organization.Supplier;
                ChangeSupplier?.Invoke(organization.Supplier);
            }

            if (checkBoxCategory.Checked)
            {
                OrganizationUpdate.Category = Organization.Category;
                ChangeCategory?.Invoke(organization.Category);
            }

            if (checkBoxPrice.Checked)
            {
                OrganizationUpdate.Price = Organization.Price;
                ChangePrice?.Invoke(organization.Price);
            }

            if (checkBoxDiscount.Checked)
            {
                OrganizationUpdate.Discount = Organization.Discount;
                ChangeDiscount?.Invoke(organization.Discount);
            }

            if (checkBoxImage.Checked)
            {
                ProductUpdate.Photo = Product.Photo;
                if(ProductUpdate.HaveImage)
                {
                    SetPhoto?.Invoke(ProductUpdate.BytesPhoto);
                }
                else
                {
                    DropPhoto?.Invoke();
                }
            }

            ChangeOrganization?.Invoke(OrganizationUpdate);
            buttonBack_Click(sender, e);
        }

        private void buttonRunWindowEdit_Click(object sender, EventArgs e)
        {
            ProductEditorForm form = new ProductEditorForm(organization);
            form.ChangeName += Form_ChangeName;
            form.ChangeDescripion += Form_ChangeDescripion;
            form.ChangeArticul += Form_ChangeArticul;
            form.DropPhoto += Form_DropPhoto;
            form.SetPhoto += Form_SetPhoto;
            form.ChangePrice += Form_ChangePrice;
            form.ChangeDiscount += Form_ChangeDiscount;
            form.ChangeManufacture += Form_ChangeManufacture;
            form.ChangeSupplier += Form_ChangeSupplier;
            form.ChangeCategory += Form_ChangeCategory;

            form.ChangeOrganization += Form_ChangeOrganization;

            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeCategory(string paramter)
        {
            Product.Category = paramter;
        }

        private void Form_ChangeSupplier(string paramter)
        {
            Product.Supplier = paramter;
        }

        private void Form_ChangeManufacture(string paramter)
        {
            Product.Manufacture = paramter;
        }

        private void Form_ChangeDiscount(int number)
        {
            Product.Discount = number;
        }

        private void Form_ChangePrice(double number)
        {
            Product.Price = number;
        }

        private void Form_SetPhoto(byte[] paramter)
        {
            Product.BytesPhoto = paramter;
        }

        private void Form_DropPhoto()
        {
            Product.Photo = "";
        }

        private void Form_ChangeArticul(string paramter)
        {
            Product.Articul = paramter;
        }

        private void Form_ChangeDescripion(string paramter)
        {
            Product.Description = paramter;
        }

        private void Form_ChangeOrganization(ProductClass organization)
        {
            UpdateOrganization();
        }

        private void Form_ChangeName(string paramter)
        {
            
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            bool check = true;
            SetCheck(check);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bool check = false;
            SetCheck(check);
        }

        void SetCheck(bool check)
        {

            checkBoxName.Checked = check;
            checkBoxArticul.Checked = check;
            checkBoxDescription.Checked = check;
            checkBoxImage.Checked = check;
            checkBoxDiscount.Checked = check;
            checkBoxPrice.Checked = check;
            checkBoxCategory.Checked = check;
            checkBoxSupplier.Checked = check;
            checkBoxManufacture.Checked = check;
        }

        private void buttonByManager_Click(object sender, EventArgs e)
        {
            ProductFile organization = new ProductFile(Organization);
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
                    if (fileClass.IsProduct)
                        Organization = fileClass.AsProduct.Content;
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

        private void textBoxWihSetArticul_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Articul = text;
        }

        private void textBoxWihSetDescription_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Organization.Description = text;
        }

        private void buttonDropImage_Click(object sender, EventArgs e)
        {
            Product.Photo = "";

            UpdateOrganization();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            ImageFile image = new ImageFile();
            if (organization.HaveImage)
            {
                image.Image = organization.Image;
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
                    organization.Image = new Bitmap(image.Image);
                }
                catch
                {

                }
            }
            image.Dispose();
            disk.Dispose();

            UpdateOrganization();
        }

        private void numericControlWithSetName_GetValue(decimal number)
        {
            Product.Price = Convert.ToDouble(number);
            UpdateOrganization();
        }

        private void numericControlWithSetDiscount_GetValue(decimal number)
        {
            Product.Discount = Convert.ToInt32(number);
            UpdateOrganization();
        }

        private void textBoxWihSetCategory_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Product.Category = text;
        }

        private void textBoxWihSetSupplier_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Product.Supplier = text;
        }

        private void textBoxWihSetManufacture_TextInputChanged(object sender, Control senderControl, TextInputEdit controlInput, object senderInput, TextBoxWihSet textInputContol, EventArgs e, string text)
        {
            Product.Manufacture = text;
        }
    }
}
