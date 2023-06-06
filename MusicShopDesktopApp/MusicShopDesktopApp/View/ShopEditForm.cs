﻿using Microsoft.VisualBasic;
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
    public partial class ShopEditForm : Form
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

        public ShopEditForm()
        {
            InitializeComponent();
        }

        TradingPoint point = new TradingPoint();

        public ShopEditForm(TradingPoint tradingPoint):this()
        {
            point = tradingPoint;
        }

        string text = "";

        string textID => text + " " + point.ID;

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
                if (!sities.ContainsByID(point.Stock.Sity))
                    throw new Exception();
                try
                {
                    StocksList stocks = StocksList.GetListFromDB();

                    if (!stocks.ContainsByID(point.Stock))
                        throw new Exception();
                    point.Stock = stocks.GetByID(point.Stock);
                }
                catch
                {
                    MessageBox.Show("Склад больше не существует", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Город больше не существует", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            buttonSave.Visible = point.Saving() && point.ID < 1;
            labelSity.Text = "Город - " + point.Stock.Sity.Name;
            labelStock.Text = "Склад - " + point.Stock.Name;

            try
            {
                OrganizationsList organizations = OrganizationsList.GetListFromDB();

                if (!organizations.ContainsByID(point.Organization))
                    throw new Exception();
                point.Organization = organizations.GetByID(point.Organization);
            }
            catch
            {
                MessageBox.Show("Организация больше не существует", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            labelOrganization.Text = "Организация - " + point.Organization.Name;
            labelSite.Text = "Сайт организации - " + point.Organization.Site;

            if (point.ID > 0)
            {
                return UpdateShop();
            }

            return true;
        }

        public bool UpdateShop()
        {
            try
            {
                TradingPointsList organizations = TradingPointsList.GetListFromDB();

                if (!organizations.ContainsByID(point))
                    throw new Exception();
                point = organizations.GetByID(point);
            }
            catch
            {
                MessageBox.Show("Данный торговый пункт больше не существует", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            textInputAddress.Text = point.Address;
            textInputEmail.Text = point.Contact.Email;
            textInputName.Text = point.Name;
            textInputSchedule.Text = point.Schedule;
            textInputSitePath.Text = point.SitePath;
            textInputTelephone.Text = point.Contact.Telephone;

            textInputAddress.ReadOnly = true;
            textInputEmail.ReadOnly = true;
            textInputName.ReadOnly = true;
            textInputSchedule.ReadOnly = true;
            textInputSitePath.ReadOnly = true;
            textInputTelephone.ReadOnly = true;

            return true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void timerSaveShow_Tick(object sender, EventArgs e)
        {
            buttonSave.Visible = point.Saving() && point.ID < 1;
        }

        private void textInputName_InputText_Changed(object arg1, EventArgs arg2)
        {
            point.Name = textInputName.Text;
        }

        private void textInputAddress_InputText_Changed(object arg1, EventArgs arg2)
        {
            point.Address = textInputAddress.Text;
        }

        private void textInputShedule_InputText_Changed(object arg1, EventArgs arg2)
        {
            point.Schedule = textInputSchedule.Text;
        }

        private void textInputSitePath_InputText_Changed(object arg1, EventArgs arg2)
        {
            point.SitePath = textInputSitePath.Text;
        }

        private void textInputTelephone_InputText_Changed(object arg1, EventArgs arg2)
        {
            point.Contact.Telephone = textInputTelephone.Text;
        }

        private void textInputEmail_InputText_Changed(object arg1, EventArgs arg2)
        {
            point.Contact.Email = textInputEmail.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            textInputAddress_InputText_Changed(sender, e);
            textInputEmail_InputText_Changed(sender, e);
            textInputName_InputText_Changed(sender, e);
            textInputShedule_InputText_Changed(sender, e);
            textInputSitePath_InputText_Changed(sender, e);
            textInputTelephone_InputText_Changed(sender, e);

            if (!UpdateForm())
                return;
            if (point.AddToDB())
            {
                MessageBox.Show("Торговый пункт успешно добавлен", "Добавление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Не удалось добавить торговый пункт", "Добавление торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonNameSet_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();
            point.Name = Interaction.InputBox("Введите новое название", "Редактирование склада", point.Name);

            if (point.UpdateNameAtDB())
            {
                MessageBox.Show("Название торгового пункта успешно изменено", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить название торгового пункта", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            point.Schedule = Interaction.InputBox("Введите новый режим работы", "Редактирование торгового пункта", point.Schedule);

            if (point.UpdateScheduleAtDB())
            {
                MessageBox.Show("Режим работы торгового пункта успешно изменён", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить режим работы торгового пункта", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        private void buttonPhone_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            point.Contact.Telephone = Interaction.InputBox("Введите новый телефон", "Редактирование торгового пункта", point.Contact.Telephone);

            if (point.UpdatePhoneAtDB())
            {
                MessageBox.Show("Телефон торгового пункта успешно изменён", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить телефон торгового пункта", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        private void buttonAddress_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            point.Address = Interaction.InputBox("Введите новый адрес", "Редактирование торгового пункта", point.Address);

            if (point.UpdateAddressAtDB())
            {
                MessageBox.Show("Адрес торгового пункта успешно изменён", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить адрес торгового пункта", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        private void buttonSite_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            point.SitePath = Interaction.InputBox("Введите новый путь на сайте", "Редактирование торгового пункта", point.SitePath);

            if (point.UpdateSiteAtDB())
            {
                MessageBox.Show("Сайт торгового пункта успешно изменён", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить сайт торгового пункта", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            if (!UpdateForm())
                return;
            timerUpdate.Stop();

            point.Contact.Email = Interaction.InputBox("Введите новый E-mail", "Редактирование торгового пункта", point.Contact.Email);

            if (point.UpdateEmailAtDB())
            {
                MessageBox.Show("E-mail торгового пункта успешно изменён", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить E-mail торгового пункта", "Редактирование торгового пункта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerUpdate.Start();
            if (!UpdateForm())
                return;
        }

        private void textInputName_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            buttonNameSet.Visible = textInputName.ReadOnly;
        }

        private void textInputSchedule_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            buttonSchedule.Visible = textInputSchedule.ReadOnly;
        }

        private void textInputTelephone_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            buttonPhone.Visible = textInputTelephone.ReadOnly;
        }

        private void textInputAddress_RegionChanged(object sender, EventArgs e)
        {
            buttonAddress.Visible = textInputAddress.ReadOnly;
        }

        private void textInputSitePath_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            buttonSite.Visible = textInputSitePath.ReadOnly;
        }

        private void textInputEmail_ReadOnlyChanged(object arg1, EventArgs arg2)
        {
            buttonEmail.Visible = textInputEmail.ReadOnly;
        }
    }
}