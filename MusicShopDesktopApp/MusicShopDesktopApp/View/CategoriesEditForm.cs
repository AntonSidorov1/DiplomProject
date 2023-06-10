using FileManegerJson;
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
    public partial class CategoriesEditForm : Form
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

        public CategoriesEditForm()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            labelCategory.Text = "";
            labelCategoryData.Text = "";
            labelCategoryEditName.Text = "";

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

        CategoriesList categories = new CategoriesList();
        CategoriesFiltersList categoriesFilters = new CategoriesFiltersList();
        CategoriesFiltersList categoriesFiltersEdit = new CategoriesFiltersList();
        Category categoryEdit = new Category();

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
            if (Helper.UserIsGoest())
            {
                MessageBox.Show("Вы больше не авторизированы", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            if (!Helper.GetAccount().IsOrdersManager())
            {
                MessageBox.Show("Необходима роль менеджера по складу или администратора",
                    "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            labelCategoryEditName.Text = categoryEdit.Name;
            UpdateCategoriesFilters();
            
            return true;
        }



        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }


        void UpdateCategoriesFilters()
        {
            timerUpdate.Stop();

            int categoryFilterID = 0;
            int categoryFilterEditID = 0;
            try
            {
                categoryFilterID = categoriesFilters.Get(comboBoxWithNameCategoryFilters.SelectedIndex).ID;
            }
            catch
            {

            }
            try
            {
                categoryFilterEditID = categoriesFiltersEdit.Get(comboBoxEditFilters.SelectedIndex).ID;
            }
            catch
            {

            }

            try
            {
                categoriesFilters.SetList(CategoriesFiltersController.GetController()
                    .GetCategoriesFilters(Helper.GetSession()));
                comboBoxWithNameCategoryFilters.Items.Clear();
                for (int i = 0; i < categoriesFilters.Count; i++)
                {
                    comboBoxWithNameCategoryFilters.Items.Add(categoriesFilters[i].Name);
                }
            }
            catch
            {

            }

            try
            {
                categoriesFiltersEdit.GetFromBD();
                categoriesFiltersEdit.RemoveAllByID(0);
                comboBoxEditFilters.Items.Clear();
                for (int i = 0; i < categoriesFiltersEdit.Count; i++)
                {
                    comboBoxEditFilters.Items.Add(categoriesFiltersEdit[i].Name);
                }
            }
            catch
            {

            }


            try
            {
                categoryFilterID = categoriesFilters.IndexOfByID(categoryFilterID);
                if (categoryFilterID >= 0)
                {
                    try
                    {

                        comboBoxWithNameCategoryFilters.SelectedIndex = categoryFilterID;
                    }
                    catch
                    {
                        comboBoxWithNameCategoryFilters.SelectedIndex = 0;
                    }
                }
                else
                    throw new Exception();
            }
            catch
            {
                try
                {

                    comboBoxWithNameCategoryFilters.SelectedIndex = 0;
                }
                catch
                {

                }
            }

            try
            {
                categoryFilterEditID = categoriesFiltersEdit.IndexOfByID(categoryFilterEditID);
                if (categoryFilterEditID >= 0)
                {
                    try
                    {

                        comboBoxEditFilters.SelectedIndex = categoryFilterEditID;
                    }
                    catch
                    {
                        comboBoxEditFilters.SelectedIndex = 0;
                    }
                }
                else
                    throw new Exception();
            }
            catch
            {
                try
                {

                    comboBoxEditFilters.SelectedIndex = 0;
                }
                catch
                {

                }
            }
            UpdateCategories();
        }

        void UpdateCategories()
        {
            timerUpdate.Stop();

            int categoryFilterID = 0;
            try
            {
                categoryFilterID = categoriesFilters.Get(comboBoxWithNameCategoryFilters.SelectedIndex).ID;
            }
            catch
            {

            }
            int categoryID = 0;

            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                categoryID = category.ID;
                labelCategory.Text = category.RealName;
            }
            catch
            {
                labelCategory.Text = "";
                categoryID = 0;
            }

            try
            {
                categories.GetFromBD();
                categories.SetCategoriesCheck(categoryFilterID, categoryID, radioButtonTree.Checked);
                listBoxCategories.Items.Clear();
                for (int i = 0; i < categories.Count; i++)
                {
                    listBoxCategories.Items.Add(categories[i].Name);
                }
            }
            catch
            {

            }


            listBoxCategories.SelectedIndexChanged -= listBoxCategories_SelectedIndexChanged;
            try
            {
                categoryID = categories.IndexOfByID(categoryID);

                if (categoryID >= 0)
                {
                    try
                    {
                        listBoxCategories.SelectedIndex = categoryID;

                    }
                    catch
                    {
                        listBoxCategories.SelectedIndex = 0;
                    }
                }
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                labelCategory.Text = category.RealName;
                labelCategoryData.Text = category.Data;

            }
            catch
            {
                labelCategory.Text = "";
                labelCategoryData.Text = "";
            }
            listBoxCategories.SelectedIndexChanged += listBoxCategories_SelectedIndexChanged;

            UpdateProducts(false);
        }




        private void radioButtonTree_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                listBoxCategories.SelectedIndex = 0;
            }
            catch
            {

            }
            UpdateCategories();
        }

        private void radioButtonLine_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxWithNameCategoryFilters_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            UpdateCategories();
        }

        private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProducts();
        }

        void UpdateProducts(bool updateCategories = true)
        {

            if (radioButtonLine.Checked)
            {
                updateCategories = false;
            }
            if (updateCategories)
            {
                UpdateCategories();
                return;
            }
            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                int categoryID = category.ID;
                labelCategory.Text = category.RealName;
                labelCategoryData.Text = category.Data;
                buttonCopyEdit.Visible = categoryID > 0;
            }
            catch (Exception e)
            {
                labelCategory.Text = "";
                labelCategoryData.Text = "";
            }

        }

        private void comboBoxEditFilters_SelectedIndexChanged(object arg1, EventArgs arg2)
        {

            try
            {
                categoryEdit.Filter = categoriesFiltersEdit.Get(comboBoxEditFilters.SelectedIndex);
            }
            catch
            {

            }
        }

        private void buttonAddToRootCategory_Click(object sender, EventArgs e)
        {
            AddCategory(0);
        }

        private void buttonAddToNowCategory_Click(object sender, EventArgs e)
        {
            int categoryID = 0;

            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                categoryID = category.ID;
            }
            catch (Exception ex)
            {
                
            }
            AddCategory(categoryID);

        }

        void AddCategory(int rootID)
        {
            if (!UpdateForm())
                return;

            if(categories.AddCategoryToDB(categoryEdit, rootID))
            {
                MessageBox.Show("Категория успешно добавлена", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось добавить категорию", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            categoryEdit = new Category();
            textInputCategoryName.Text = categoryEdit.Name;


            UpdateForm();
        }

        private void textInputCategoryName_InputText_Changed(object arg1, EventArgs arg2)
        {
            categoryEdit.Name = textInputCategoryName.Text;
        }

        private void buttonCopyEdit_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                categoryEdit = category.CopyRealName();
                textInputCategoryName.Text = categoryEdit.Name;

                try
                {
                    int index = categoriesFiltersEdit.IndexOfByID(category.Filter);
                    index = index > 0? index: 0;
                    comboBoxEditFilters.SelectedIndex = index;
                }
                catch
                {
                    comboBoxEditFilters.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                
            }
            if (!UpdateForm())
                return;
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить категорию", "Удаление категории", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
            {
                UpdateForm();
                return;
            }

            if (!UpdateForm())
                return;
            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                int categoryID = category.ID;
                if (category.RootCategoryID == 0 || radioButtonLine.Checked)
                    listBoxCategories.SelectedIndex = 0;
                else
                {
                    try
                    {
                        listBoxCategories.SelectedIndex = 1;
                    }
                    catch
                    {
                        listBoxCategories.SelectedIndex = 0;
                    }
                }
                if (categories.DeleteFromDB(categoryID))
                {
                    MessageBox.Show("Категория успешно удалена", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось удалить категорию", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            UpdateForm();
        }

        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (categories.ContainsByID(categoryEdit.RootCategoryID))
                UpdateCategory(categoryEdit.RootCategoryID);
            else
            {
                MessageBox.Show("Данной надкатегории больше не существует", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCutToNowCategory_Click(object sender, EventArgs e)
        {
            int categoryID = 0;

            try
            {
                Category category = categories.Get(listBoxCategories.SelectedIndex);
                categoryID = category.ID;
            }
            catch (Exception ex)
            {

            }
            UpdateCategory(categoryID);
        }

        void UpdateCategory(int categoryID)
        {
            if (!UpdateForm())
                return;
            try
            {
                if (!CategoriesList.GetListFromDB().ContainsByID(categoryEdit))
                {
                    MessageBox.Show("Данной категории больше не существует \n" +
                        "Попробуйте добавить данную категорию", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (categories.UpdateCategoryToDB(categoryEdit, categoryID))
                {
                    MessageBox.Show("Категория успешно изменена", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Не удалось изменить категорию", "Редактирование категорий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            categoryEdit = new Category();
            textInputCategoryName.Text = categoryEdit.Name;

            UpdateForm();
        }

        private void buttonEditVieWindows_Click(object sender, EventArgs e)
        {
            CategoryEditForm form = new CategoryEditForm(categoryEdit.CopyEdit());
            form.ChangeName += Form_ChangeName;
            form.ChangeFilter += Form_ChangeFilter;
            Hide();
            form.ShowDialog();
            Show();
        }

        private void Form_ChangeFilter(string paramter)
        {
            int index = categoriesFilters.IndexByIdInLower(paramter) - 1;
            if(index >= 0)
            {
                comboBoxEditFilters.SelectedIndex = index;
            }
        }

        private void Form_ChangeName(string paramter)
        {
            categoryEdit.Name = paramter;
            textInputCategoryName.Text = paramter;
        }
    }
}
