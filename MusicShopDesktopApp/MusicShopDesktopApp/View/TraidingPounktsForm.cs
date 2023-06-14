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
using FileManegerJson;
using Microsoft.VisualBasic;

namespace MusicShopDesktopApp
{
    public partial class TraidingPounktsForm : Form
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

        int sityIndex = 0, organizationID = 0, stockID = 0, pointID = 0;

        public TraidingPounktsForm()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            UpdateView();

            if (!Helper.TraidHelper.Checked)
                return;
            SetData();
        }

        public void SetData()
        { 

            try
            {
                comboBoxWithNameSities.SelectedIndex = sities.IndexOfByID(Helper.TraidHelper.Sity.ID)+1;
            }
            catch
            {

            }
            try
            {
                comboBoxWithNameOrganization.SelectedIndex = sities.IndexOfByID(Helper.TraidHelper.Organization.ID)+1;
            }
            catch
            {

            }
            try
            {
                listWithNameStocks.CurrentCell = listWithNameStocks.Rows[stocks.IndexOfByID(Helper.TraidHelper.Stock.ID)+1].Cells[0];
            }
            catch
            {

            }
            try
            {
                dataGridViewPounkts.CurrentCell = dataGridViewPounkts.Rows[points.IndexOfByID(Helper.TraidHelper.TradingPoint.ID)+1].Cells[0];
            }
            catch
            {

            }
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

        private void comboBoxWithNameSities_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            try
            {
                int stockIndex = 0;
                try
                {
                    stockIndex = GetStockID();
                }
                catch
                {

                }

                GetStocks();

                try
                {
                    SetStockPoint(stockIndex);
                }
                catch
                {
                    listWithNameStocks.CurrentCell = listWithNameStocks.Rows[0].Cells[0];
                }
            }
            catch
            {

            }
        }


        void UpdateView()
        {
            timerUpdate.Stop();

            UpdateForm();

            timerUpdate.Start();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        OrganizationsList organizations = new OrganizationsList();
        SitiesList sities = new SitiesList();
        void UpdateForm()
        {
            buttonPointEdit.Visible = Helper.GetAccount().IsAdmin();
            try
            {
                sities = SitiesController.GetController().GetSities(Helper.GetSession());
                if (comboBoxWithNameSities.SelectedIndex >= 0)
                {
                    sityIndex = comboBoxWithNameSities.SelectedIndex;
                }
                else
                {
                    sityIndex = 0;
                }
                comboBoxWithNameSities.Items.Clear();
                comboBoxWithNameSities.Items.Add("Все города");
                comboBoxWithNameSities.Items.AddRange(sities.GetObjectsList());
                comboBoxWithNameSities.SelectedIndex = sityIndex;
            }
            catch
            {

            }
            try
            {
                organizations = OrganizationsController.GetController().GetOrganizations(Helper.GetSession());
                if (comboBoxWithNameOrganization.SelectedIndex >= 0)
                {
                    organizationID = comboBoxWithNameOrganization.SelectedIndex;
                }
                else
                {
                    organizationID = 0;
                }
                comboBoxWithNameOrganization.Items.Clear();
                comboBoxWithNameOrganization.Items.Add("Все организации");
                comboBoxWithNameOrganization.Items.AddRange(organizations.GetObjectsList());
                comboBoxWithNameOrganization.SelectedIndex = organizationID;
            }
            catch
            {

            }
        }

        private void listWithNameStocks_SelectedIndexChanged(object arg1, EventArgs arg2)
        {
            try
            {
                organizationID = comboBoxWithNameOrganization.SelectedIndex;
                if(organizationID < 1)
                {
                    textBoxOrganization.Text = "";
                    linkLabelOrgSite.Text = "";
                }
                else
                {
                    Organization organization = organizations[organizationID - 1];
                    textBoxOrganization.Text = organization.Data.Replace("\n", Environment.NewLine);
                    linkLabelOrgSite.Text = organization.Site;
                }
            }
            catch
            {
                textBoxOrganization.Text = "";
                linkLabelOrgSite.Text = "";
            }
            try
            {
                int stockIndex = 0;
                try
                {
                    stockIndex = GetTraidPointID();
                }
                catch
                {

                }
                GetPounkts();

                try
                {
                    SetTraidingPoint(stockIndex);
                }
                catch
                {
                    dataGridViewPounkts.CurrentCell = dataGridViewPounkts.Rows[0].Cells[0];
                }
            }
            catch
            {

            }

            GetLogotip();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void listWithNameStocks_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                stockID = e.RowIndex;
                if (stockID < 1)
                {
                    textBoxStock.Text = "";
                }
                else
                {
                    Stock organization = stocks[stockID - 1];
                    textBoxStock.Text = organization.Data.Replace("\n", Environment.NewLine);
                }
            }
            catch
            {
                textBoxStock.Text = "";
            }
            try
            {
                int stockIndex = 0;
                try
                {
                    stockIndex = GetTraidPointID();
                }
                catch
                {

                }
                GetPounkts();

                try
                {
                    SetTraidingPoint(stockIndex);
                }
                catch
                {
                    dataGridViewPounkts.CurrentCell = dataGridViewPounkts.Rows[0].Cells[0];
                }
            }
            catch
            {

            }
        }

        StocksList stocks = new StocksList();

        private void dataGridViewPounkts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pointID = e.RowIndex;
                if (pointID < 1)
                {
                    textBoxPounkt.Text = "";
                    linkLabelPointSite.Text = "";
                }
                else
                {
                    TradingPoint organization = points[pointID - 1];
                    textBoxPounkt.Text = organization.Data.Replace("\n", Environment.NewLine);
                    linkLabelPointSite.Text = organization.Site;
                }
            }
            catch
            {
                textBoxStock.Text = "";
                linkLabelPointSite.Text = "";
            }

            GetLogotip();
        }

        private void linkLabelOrgSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = (sender as LinkLabel).Text;
            if(link != "")
            {
                try
                {
                    Process.Start(link);
                }
                catch
                {

                }
            }
        }

        void GetStocks()
        {
            try
            {
                sityIndex = comboBoxWithNameSities.SelectedIndex;
                int sityID = 0;
                if (sityIndex > 0)
                {
                    sityID = sities[sityIndex - 1].ID;
                }
                stocks = StocksController.GetController().GetStocks(Helper.GetSession(), sityID);

                try
                {
                    
                    listWithNameStocks.Rows.Clear();
                    listWithNameStocks.Rows.Add("Все склады");
                    for (int i = 0; i < stocks.Count; i++)
                    {
                        listWithNameStocks.Rows.Add(stocks[i].RegistrateData);
                    }
                }
                catch
                {

                }
            }
            catch
            {

            }
            try
            {
                int stockIndex = 0;
                try
                {
                    stockIndex = GetTraidPointID();
                }
                catch
                {

                }
                GetPounkts();

                try
                {
                    SetTraidingPoint(stockIndex);
                }
                catch
                {
                    dataGridViewPounkts.CurrentCell = dataGridViewPounkts.Rows[0].Cells[0];
                }
            }
            catch
            {

            }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int stockIndex = 0;
                try
                {
                    stockIndex = GetTraidPointID();
                }
                catch
                {

                }
                GetPounkts();

                try
                {
                    SetTraidingPoint(stockIndex);
                }
                catch
                {
                    dataGridViewPounkts.CurrentCell = dataGridViewPounkts.Rows[0].Cells[0];
                }
            }
            catch
            {

            }
        }

        private void buttonGetOrganization_Click(object sender, EventArgs e)
        {
            int pointID = GetTraidPointID();
            if (pointID < 1)
            {
                return;
            }

            TradingPoint point = points.GetByID(pointID);
            int orgID = organizations.IndexOfByID(point.OrganizationID);
            try
            {
                comboBoxWithNameOrganization.SelectedIndex = orgID + 1;
            }
            catch
            {

            }
            SetTraidingPoint(point.ID);
        }

        private void buttonGetStock_Click(object sender, EventArgs e)
        {
            int pointID = GetTraidPointID();
            if (pointID < 1)
            {
                return;
            }
            TradingPoint point = points.GetByID(pointID);
            int orgID = stocks.IndexOfByID(point.StockID);
            try
            {
                listWithNameStocks.CurrentCell = listWithNameStocks.Rows[orgID + 1].Cells[0];
            }
            catch
            {

            }
            SetTraidingPoint(point.ID);
        }

        int GetTraidPointID()
        {
            try
            {
                return points[dataGridViewPounkts.CurrentCell.RowIndex - 1].ID;
            }
            catch
            {
                return 0;
            }
        }

        int GetStockID()
        {
            try
            {
                return stocks[listWithNameStocks.CurrentCell.RowIndex - 1].ID;
            }
            catch
            {
                return 0;
            }
        }

        public void SetTraidingPoint(int id)
        {
            try
            {
                dataGridViewPounkts.CurrentCell = dataGridViewPounkts.Rows[points.IndexOfByID(id) + 1].Cells[0];
            }
            catch
            {
                try
                {
                    dataGridViewPounkts.CurrentCell = dataGridViewPounkts.Rows[0].Cells[0];
                }
                catch
                {

                }
            }
        }

        public void SetStockPoint(int id)
        {
            try
            {
                listWithNameStocks.CurrentCell = listWithNameStocks.Rows[stocks.IndexOfByID(id) + 1].Cells[0];
            }
            catch
            {
                try
                {
                    listWithNameStocks.CurrentCell = listWithNameStocks.Rows[0].Cells[0];
                }
                catch
                {

                }
            }
        }

        private void getSityByPoint_Click(object sender, EventArgs e)
        {
            int pointID = GetTraidPointID();
            if (pointID < 1)
            {
                return;
            }
            TradingPoint point = points.GetByID(pointID);
            int orgID = sities.IndexOfByID(point.Stock.SityID);
            try
            {
                comboBoxWithNameSities.SelectedIndex = orgID + 1;
            }
            catch
            {

            }
            SetTraidingPoint(point.ID);
        }

        private void getSityByStock_Click(object sender, EventArgs e)
        {
            int pointID = GetStockID();
            if (pointID < 1)
            {
                return;
            }
            Stock point = stocks.GetByID(pointID);
            int orgID = sities.IndexOfByID(point.SityID);
            try
            {
                comboBoxWithNameSities.SelectedIndex = orgID + 1;
            }
            catch
            {

            }
            SetStockPoint(point.ID);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            clear();
            MessageBox.Show("Установленный торговый пункт успешно сброшен", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timerUpdate.Start();
        }

        void clear()
        {
            Helper.TraidHelper.Clear();
        }

        private void toolStripMenuItemShop_Click(object sender, EventArgs e)
        {
            clear();
            SetDataPoint();

            try
            {
                Helper.TraidHelper.PounktType = PounktType.Shop;
                if (dataGridViewPounkts.CurrentCell.RowIndex > 0)
                {
                    try
                    {
                        TradingPoint point = points[dataGridViewPounkts.CurrentCell.RowIndex - 1];
                        if (point.ExistenceShop)
                            Helper.TraidHelper.TradingPoint = point;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }

            MessageOutput();

            Helper.TraidHelper.SetData();
            SetData();
        }



        private void toolStripMenuItemStock_Click(object sender, EventArgs e)
        {
            clear();
            SetDataPoint();

            try
            {
                Helper.TraidHelper.PounktType = PounktType.Stock;
                if (dataGridViewPounkts.CurrentCell.RowIndex > 0)
                {
                    try
                    {
                        TradingPoint point = points[dataGridViewPounkts.CurrentCell.RowIndex - 1];
                        if (point.ExistencePounktOfIssue)
                            Helper.TraidHelper.TradingPoint = point;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
            MessageOutput();


            Helper.TraidHelper.SetData();
            SetData();
        }

        void MessageOutput()
        {
            MessageBox.Show("Торговый пункт успешно установлен", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);

            timerUpdate.Start();
        }

        void SetDataPoint()
        {
            timerUpdate.Stop();

            Helper.TraidHelper.Checked = true;

            if(comboBoxWithNameSities.SelectedIndex > 0)
            {
                try
                {
                    Helper.TraidHelper.Sity = sities[comboBoxWithNameSities.SelectedIndex - 1];
                }
                catch
                {

                }
            }

            if (comboBoxWithNameOrganization.SelectedIndex > 0)
            {
                try
                {
                    Helper.TraidHelper.Organization = organizations[comboBoxWithNameOrganization.SelectedIndex - 1];
                }
                catch
                {

                }
            }

            try
            {
                if (listWithNameStocks.CurrentCell.RowIndex > 0)
                {
                    try
                    {
                        Helper.TraidHelper.Stock = stocks[listWithNameStocks.CurrentCell.RowIndex - 1];
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        private void buttonAddSity_Click(object sender, EventArgs e)
        {
            EditSity(new Sity(), sender, e);
        }


        public void EditSity(Sity sity, object sender, EventArgs e)
        {
            SityEditForm form = new SityEditForm(sity.Name);
            Hide();

            form.ShowDialog();
            Show();
            if(!form.Save)
            {

                buttonUpdate_Click(sender, e);
                return;
            }



            sity.Name = form.Value;
            if(sity.Name.Length<1)
            {
                MessageBox.Show("Необходимо название города", "Город", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if(sity.ID < 1)
            {
                if(sity.AddToDB())
                {
                    MessageBox.Show("Город успешно добавлен", "Добавление города", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось добавить город", "Добавление города", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (sity.UpdateAtDB())
                {
                    MessageBox.Show("Город успешно изменён", "Изменение города", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось изменить город", "Изменение города", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            buttonUpdate_Click(sender, e);
        }

        private void buttonEditSity_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();
            int index = comboBoxWithNameSities.SelectedIndex;
            if(index < 1)
            {
                MessageBox.Show("Город не выбран", "Изменение городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Sity sity = new Sity();
                try
                {
                    sity = sities[index - 1];
                    int id = sity.ID;
                }
                catch(ArgumentException ex)
                {
                    MessageBox.Show("Выбранный город больше не существует", "Изменение городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный город больше не существует", "Изменение городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный город больше не существует", "Изменение городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }




                EditSity(sity, sender, e);
            }
        }

        private void buttonDropSity_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();
            int index = comboBoxWithNameSities.SelectedIndex;

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить город", "Удаление города", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.No)
            {
                buttonUpdate_Click(sender, e);
                return;
            }

            if (index < 1)
            {
                MessageBox.Show("Город не выбран", "удаление города", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Sity sity = new Sity();
                try
                {
                    sity = sities[index - 1];
                    int id = sity.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный город больше не существует", "Удаление городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный город больше не существует", "Удаление городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный город больше не существует", "Удаление городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                if (sity.DeleteFromDB())
                {
                    MessageBox.Show("Город успешно удалён", "Удаление города", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить город", "Удаление города", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            buttonUpdate_Click(sender, e);
            buttonUpdate_Click(sender, e);
        }

        private void buttonDropOrg_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить организацию", "Удаление организации", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                buttonUpdate_Click(sender, e);
                return;
            }

            int index = comboBoxWithNameOrganization.SelectedIndex;
            if (index < 1)
            {
                MessageBox.Show("Организация не выбран", "Удаление организации", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Organization sity = new Organization();
                try
                {
                    sity = organizations[index - 1];
                    int id = sity.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранная организация больше не существует", "Удаление организации", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный город больше не существует", "Удаление организации", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранная организация больше не существует", "Удаление организации", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                if (sity.DeleteFromDB())
                {
                    MessageBox.Show("Организация успешно удалена", "Удаление организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить организацию", "Удаление организации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            buttonUpdate_Click(sender, e);
            buttonUpdate_Click(sender, e);
        }

        private void buttonAddOrg_Click(object sender, EventArgs e)
        {
            EditOrg(new Organization(), sender, e);
        }

        private void buttonEditOrg_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();
            int index = comboBoxWithNameOrganization.SelectedIndex;
            if (index < 1)
            {
                MessageBox.Show("Организация не выбрана", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Organization sity = new Organization();
                try
                {
                    sity = organizations[index - 1];
                    int id = sity.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранная организация больше не существует", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный организация больше не существует", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный организация больше не существует", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }




                EditOrg(sity, sender, e);
            }
        }


        public void EditOrg(Organization organization, object sender, EventArgs e)
        {
            Hide();

            OrganizationsForm form = new OrganizationsForm(organization);
            Hide();
            form.ShowDialog();
            Show();

            buttonUpdate_Click(sender, e);
        }

        private void buttonStockDrop_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить склад", "Удаление склада", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                buttonUpdate_Click(sender, e);
                return;
            }

            int index = listWithNameStocks.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Склад не выбран", "Удаление склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Stock sity = new Stock();
                try
                {
                    sity = stocks[index - 1];
                    int id = sity.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Удаление склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Удаление склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Удаление склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                if (sity.DeleteFromDB())
                {
                    MessageBox.Show("Склад успешно удалён", "Удаление склада", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить склад", "Удаление склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            buttonUpdate_Click(sender, e);
            buttonUpdate_Click(sender, e);
        }

        private void buttonStockAdd_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            int index = comboBoxWithNameSities.SelectedIndex;
            if (index < 1)
            {
                DialogResult dialog = MessageBox.Show("Город не выбран. Вы хотите создать склад с городом по умолчанию?", "Изменение склада", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.No)
                {
                    MessageBox.Show("Город не выбран", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonUpdate_Click(sender, e);
                    return;
                }
                else
                {
                    index = 1;
                }
            }
            if (index > 0)
            {
                Sity sity = new Sity();
                try
                {
                    sity = sities[index - 1];
                    int id = sity.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный город больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный город больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный город больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }


                Stock stock = new Stock
                {
                    Sity = sity.CopySity()
                };

                EditStock(stock, sender, e);
            }
        }

        private void buttonStockEdit_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();
            int index = listWithNameStocks.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Склад не выбран", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Stock sity = new Stock();
                try
                {
                    sity = stocks[index - 1];
                    int id = sity.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }


                EditStock(sity, sender, e);
            }
        }


        public void EditStock(Stock stock, object sender, EventArgs e)
        {
            Hide();

            StockForm form = new StockForm(stock);
            Hide();
            form.ShowDialog();
            Show();

            buttonUpdate_Click(sender, e);
        }

        private void buttonDropPoint_Click(object sender, EventArgs e)
        {
            timerUpdate.Start();

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить торговый пункт", "Удаление торгового пункта", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                buttonUpdate_Click(sender, e);
                return;
            }

            int index = dataGridViewPounkts.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Торговый пункт не выбран", "Удаление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                TradingPoint sity = new TradingPoint();
                try
                {
                    sity = points[index - 1];
                    int id = sity.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Удаление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Удаление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Удаление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                if (sity.DeleteFromDB())
                {
                    MessageBox.Show("Выбранный торговый пункт удалён", "Удаление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить торговый пункт", "Удаление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            buttonUpdate_Click(sender, e);
            buttonUpdate_Click(sender, e);
        }

        private void buttonPointAdd_Click(object sender, EventArgs e)
        {
            TradingPoint tradingPoint = new TradingPoint();

            timerUpdate.Stop();
            int index = listWithNameStocks.CurrentCell.RowIndex;


            if (index < 1)
            {
                MessageBox.Show("Выберите склад", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Stock sity = new Stock();
                try
                {
                    sity = stocks[index - 1];
                    int id = sity.ID;
                    tradingPoint.Stock = sity;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
            }

            index = comboBoxWithNameOrganization.SelectedIndex;
            if (index < 1)
            {
                MessageBox.Show("Выберите организацию", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Organization sity = new Organization();
                try
                {
                    sity = organizations[index - 1];
                    int id = sity.ID;
                    tradingPoint.Organization = sity;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранная организация больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранная организация больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранная организация больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }

            }


            EditTraidingPoint(tradingPoint, sender, e);
        }

        private void buttonChangePoint_Click(object sender, EventArgs e)
        {
            TradingPoint tradingPoint = new TradingPoint();

            timerUpdate.Stop();
            int index = comboBoxWithNameSities.SelectedIndex;


            index = dataGridViewPounkts.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Торговый пункт не выбран", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                
                try
                {
                    tradingPoint = points[index - 1];
                    int id = tradingPoint.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
            }

            EditTraidingPoint(tradingPoint, sender, e);
        }

        public void EditTraidingPoint(TradingPoint point, object sender, EventArgs e)
        {
            ShopEditForm shopEdit = new ShopEditForm(point);
            Hide();
            shopEdit.ShowDialog();
            Show();

            buttonUpdate_Click(sender, e);
        }

        private void buttonShopSet_Click(object sender, EventArgs e)
        {
            TradingPoint tradingPoint = new TradingPoint();
            timerUpdate.Stop();
            int index = comboBoxWithNameSities.SelectedIndex;


            index = dataGridViewPounkts.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Торговый пункт не выбран", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {

                try
                {
                    tradingPoint = points[index - 1];
                    int id = tradingPoint.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
            }

            FormNoteEdit form = new FormNoteEdit(tradingPoint.Shop.Name);
            Hide();
            form.ShowDialog();
            Show();
            if(!form.Save)
            {

                timerUpdate.Start();
                buttonUpdate_Click(sender, e);
                return;
            }
            tradingPoint.Shop.Name = form.Value;

            //tradingPoint.Shop.Name = Interaction.InputBox("Введите новое название", "Редактирование магазина", tradingPoint.Shop.Name);
            if (tradingPoint.SetShopAtDB())
            { 
                MessageBox.Show("Магазин успешно изменён", "Редактирование магазина", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить магазин", "Редактирование магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            buttonUpdate_Click(sender, e);
        }

        private void buttonPointOfIssueSet_Click(object sender, EventArgs e)
        {
            TradingPoint tradingPoint = new TradingPoint();
            timerUpdate.Stop();
            int index = comboBoxWithNameSities.SelectedIndex;


            index = dataGridViewPounkts.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Торговый пункт не выбран", "Изменение пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {

                try
                {
                    tradingPoint = points[index - 1];
                    int id = tradingPoint.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
            }

            FormNoteEdit form = new FormNoteEdit(tradingPoint.PounktOfIssue.Name);
            Hide();
            form.ShowDialog();
            Show();
            if (!form.Save)
            {

                timerUpdate.Start();
                buttonUpdate_Click(sender, e);
                return;
            }
            tradingPoint.PounktOfIssue.Name = form.Value;

            //tradingPoint.PounktOfIssue.Name = Interaction.InputBox("Введите новое название", "Редактирование пункта выдачи", tradingPoint.PounktOfIssue.Name);
            if (tradingPoint.SetPounktOfIssueAtDB())
            {
                MessageBox.Show("Пункт выдачи успешно изменён", "Редактирование пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить пункт выдачи", "Редактирование пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            buttonUpdate_Click(sender, e);
        }

        private void buttonShopDrop_Click(object sender, EventArgs e)
        {
            TradingPoint tradingPoint = new TradingPoint();
            timerUpdate.Stop();
            int index = comboBoxWithNameSities.SelectedIndex;


            index = dataGridViewPounkts.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Торговый пункт не выбран", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {

                try
                {
                    tradingPoint = points[index - 1];
                    int id = tradingPoint.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
            }

            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить магазин?", "Редактирование магазина", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                if (tradingPoint.DeleteShopFromDB())
                {
                    MessageBox.Show("Пункт выдачи успешно удалён", "Редактирование магазина", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить магазин", "Редактирование магазина", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            timerUpdate.Start();
            buttonUpdate_Click(sender, e);
        }

        private void buttonDropPounktOfIssue_Click(object sender, EventArgs e)
        {
            TradingPoint tradingPoint = new TradingPoint();
            timerUpdate.Stop();
            int index = comboBoxWithNameSities.SelectedIndex;


            index = dataGridViewPounkts.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Торговый пункт не выбран", "Изменение пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {

                try
                {
                    tradingPoint = points[index - 1];
                    int id = tradingPoint.ID;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
            }

            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить магазин?", "Редактирование пункта выдачи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                if (tradingPoint.DeletePounktOfIssueFromDB())
                {
                    MessageBox.Show("Пункт выдачи успешно удалён", "Редактирование пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить пункт выдачи", "Редактирование пункта выдачи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            timerUpdate.Start();
            buttonUpdate_Click(sender, e);
        }

        private void buttonSityShow_Click(object sender, EventArgs e)
        {
            if (comboBoxWithNameSities.SelectedIndex < 1)
            {
                MessageBox.Show("Выберите город", "просмотр города", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Sity sity = new Sity();
            try
            {
                sity = sities[comboBoxWithNameSities.SelectedIndex - 1];
                SityEditForm form = new SityEditForm(sity.Name);
                form.SetReadOnly(false);
                Hide();

                form.ShowDialog();
                Show();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Выбранный город больше не существует", "Изменение городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Выбранный город больше не существует", "Изменение городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            catch
            {
                MessageBox.Show("Выбранный город больше не существует", "Изменение городов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }


        }

        private void buttonStockShow_Click(object sender, EventArgs e)
        {
            int index = listWithNameStocks.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Склад не выбран", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Stock sity = new Stock();
                try
                {
                    sity = stocks[index - 1];
                    int id = sity.ID;

                    StockPointEditForm form = new StockPointEditForm(sity.CopyEdit());
                    form.SetReadOnly(false);
                    Hide();
                    form.ShowDialog();
                    Show();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный склад больше не существует", "Изменение склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }


            }
        }

        private void buttonOrganizationShow_Click(object sender, EventArgs e)
        {
            int index = comboBoxWithNameOrganization.SelectedIndex;
            if (index < 1)
            {
                MessageBox.Show("Организация не выбрана", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {
                Organization sity = new Organization();
                try
                {
                    sity = organizations[index - 1];
                    int id = sity.ID;
                    OrganizationEditForm form = new OrganizationEditForm(sity.CopyOrganizationEdit());
                    form.SetReadOnly(false);
                    Hide();
                    form.ShowDialog();
                    Show();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранная организация больше не существует", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный организация больше не существует", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный организация больше не существует", "Изменение организаций", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }




            }
        }

        private void buttonPointShow_Click(object sender, EventArgs e)
        {
            TradingPoint tradingPoint = new TradingPoint();

            timerUpdate.Stop();
            int index = comboBoxWithNameSities.SelectedIndex;


            index = dataGridViewPounkts.CurrentCell.RowIndex;
            if (index < 1)
            {
                MessageBox.Show("Торговый пункт не выбран", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                buttonUpdate_Click(sender, e);
                return;
            }
            if (index > 0)
            {

                try
                {
                    tradingPoint = points[index - 1];
                    int id = tradingPoint.ID;
                    ShopEditForm shopEdit = new ShopEditForm(tradingPoint);
                    shopEdit.SetReadOnly(false);
                    Hide();
                    shopEdit.ShowDialog();
                    Show();
                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
                catch
                {
                    MessageBox.Show("Выбранный торговый пункт больше не существует", "Изменение торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    buttonUpdate_Click(sender, e);
                    return;
                }
            }

            //EditTraidingPoint(tradingPoint, sender, e);
        }

        TradingPointsList points = new TradingPointsList();
        void GetPounkts()
        {
            try
            {
                sityIndex = comboBoxWithNameSities.SelectedIndex;
                int sityID = 0;
                if (sityIndex > 0)
                {
                    sityID = sities[sityIndex - 1].ID;
                }
                organizationID = comboBoxWithNameOrganization.SelectedIndex;
                int orgID = 0;
                if (organizationID > 0)
                {
                    orgID = organizations[organizationID - 1].ID;
                }
                int stockIndex = 0;
                try
                {
                    stockID = listWithNameStocks.CurrentCell.RowIndex;
                    if (stockID > 0)
                    {
                        stockIndex = stocks[stockID - 1].ID;
                    }
                }
                catch
                {

                }
                points = TradingPointsController.GetController().GetTradingPoints(Helper.GetSession(), sityID, stockIndex, orgID);

                if(radioButtonShops.Checked)
                {
                    points = points.GetShops();
                }
                else if (radioButtonPointsOfIssue.Checked)
                {
                    points = points.GetPounktsOfIssue();
                }
                else if(radioButtonBothTypes.Checked)
                {
                    points = points.GetShops().GetPounktsOfIssue();
                }

                try
                {
                    
                    dataGridViewPounkts.Rows.Clear();
                    dataGridViewPounkts.Rows.Add("Все пункты");
                    for (int i = 0; i < points.Count; i++)
                    {
                        dataGridViewPounkts.Rows.Add(points[i].RegistrateData);
                    }
                }
                catch
                {

                }
            }
            catch
            {

            }
        }


        public void GetLogotip()
        {
            try
            {
                int orgID = comboBoxWithNameOrganization.SelectedIndex;
                if(orgID < 1)
                {
                    orgID = dataGridViewPounkts.CurrentCell.RowIndex;
                    if (orgID < 1)
                        throw new Exception();

                    Organization org = points[orgID - 1].Organization.GetOrganization(organizations);
                    pictureBoxWithNameLogotip.Image = new Bitmap(org.LogotipImage, 100, 100);

                    return;
                }
                Organization organization = organizations[orgID - 1];
                pictureBoxWithNameLogotip.Image = new Bitmap(organization.LogotipImage, 100, 100);
            }
            catch
            {
                pictureBoxWithNameLogotip.Image = new Bitmap(100, 100);
            }
        }
    }
}
