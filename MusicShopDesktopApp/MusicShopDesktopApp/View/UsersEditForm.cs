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
    public partial class UsersEditForm : Form
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

        public UsersEditForm()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            resizePanelEdit.SizeUpdate();

            labelUser.Text = "";
            labelRole.Text = "";
            labelRoleName.Text = "";
            UpdateView();

            int index = 0;
            try
            {
                index = accounts.IndexByID(Helper.GetAccount().ID);
                if (index < 0)
                    throw new Exception();
            }
            catch
            {
                index = 0;
            }

            try
            {
                listBoxUsers.SelectedIndex = index;
            }
            catch
            {
                try
                {
                    listBoxUsers.SelectedIndex = 0;
                }
                catch
                {

                }
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

        bool UpdateView()
        {
            timerUpdate.Stop();

            if (!UpdateForm())
                return false;

            timerUpdate.Start();
            return true;
        }

        AccountsList accounts = new AccountsList();
        RolesList rolesList = new RolesList();
        bool UpdateForm()
        {
            if(Helper.UserIsGoest())
            {
                MessageBox.Show("Вы больше не авторизированы", "Редактирование пользоваетелей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }
            AccountWithRoles account = Helper.GetAccount();
            if (!account.IsDirector())
            {
                MessageBox.Show("Необходима роль директора или администратора", "Редактирование пользоваетелей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return false;
            }

            try
            {
                int index = listBoxRoles.SelectedIndex;
                if (index < 0)
                    index = 0;
                int role = 0;
                try
                {
                    role = rolesList[index].ID;
                }
                catch
                {

                }
                rolesList.GetDatasFromDB();
                listBoxRoles.Items.Clear();
                for(int i = 0; i< rolesList.Count; i++)
                {
                    listBoxRoles.Items.Add(rolesList[i].RoleRus);
                }
                try
                {
                    index = rolesList.IndexByID(role);
                    if (index < 0)
                        throw new Exception();
                }
                catch
                {
                    index = 0;
                }

                try
                {
                    listBoxRoles.SelectedIndex = index;
                }
                catch
                {
                    listBoxRoles.SelectedIndex = 0;
                }
            }
            catch
            {
                labelRoleName.Text = "";
            }


            try
            {
                int id = 0;
                int index = 0;
                try
                {
                    index = listBoxUsers.SelectedIndex;
                    if (index < 0)
                        throw new Exception();
                }
                catch
                {
                    index = 0;
                }

                try
                {
                    id = accounts[index].ID;
                }
                catch
                {

                }

                listBoxUsers.Items.Clear();
                accounts.GetDatasFromDB(false);

                for(int i = 0; i < accounts.Count; i++)
                {
                    listBoxUsers.Items.Add(accounts[i].Login);
                }

                index = 0;
                try
                {
                    index = accounts.IndexByID(id);
                    if (index < 0)
                        throw new Exception();
                }
                catch
                {
                    index = 0;
                }

                try
                {
                    listBoxUsers.SelectedIndex = index;
                }
                catch
                {
                    try
                    {
                        listBoxUsers.SelectedIndex = accounts.IndexByID(account.ID);
                    }
                    catch
                    {
                        try
                        {
                            listBoxUsers.SelectedIndex = 0;
                        }
                        catch
                        {

                        }
                    }
                }

            }
            catch
            {

            }
            return true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            timerUpdate_Tick(sender, e);
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxUsers.SelectedIndex;
            try
            {
                
                
                    if (index < 0)
                        throw new Exception();
                AccountWithID account = accounts[index];
                labelUser.Text = account.Data;
                buttonUserBlocked.Text = (account.NoBlocked?"Заблокировать": "Разблокировать");
                bool visible = account.NoEqualsLogin(Helper.GetAccount());
                buttonUserBlocked.Visible = visible;
                buttonUserRemove.Visible = visible;
                buttonRoleDelete.Visible = visible;
                buttonRoleAdd.Visible = visible;
                AccountWithRoles roles = account.GetUserWithRoles();
                int role = listBoxUserRoles.SelectedIndex;
                if (role < 0)
                    role = 0;
                try
                {
                    role = roles.Roles[role].ID;
                }
                catch
                {
                    role = 0;
                }
                listBoxUserRoles.Items.Clear();
                for (int i = 0; i < roles.Roles.Count; i++)
                {
                    listBoxUserRoles.Items.Add(roles.Roles[i].RoleRus);
                }

                try
                {
                    role = roles.Roles.IndexByID(role);
                    if (role < 0)
                        throw new Exception();
                }
                catch
                {
                    role = 0;
                }

                try
                {
                    listBoxUserRoles.SelectedIndex = role;
                }
                catch
                {
                    try
                    {
                        listBoxUserRoles.SelectedIndex = 0;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {
                listBoxUserRoles.Items.Clear();
                try
                {
                    labelUser.Text = accounts[index].Data;
                    buttonUserBlocked.Text = (accounts[index].NoBlocked ? "Заблокировать" : "Разблокировать");
                    bool visible = accounts[index].NoEqualsLogin(Helper.GetAccount());
                    buttonUserBlocked.Visible = visible;
                    buttonUserRemove.Visible = visible;
                    buttonRoleAdd.Visible = visible;
                }
                catch
                {
                    labelUser.Text = "";
                    buttonUserBlocked.Text = "";
                    buttonUserBlocked.Visible = false;
                    buttonRoleAdd.Visible = false;
                    buttonUserRemove.Visible = false;
                }

                labelRole.Text = "";
                buttonRoleDelete.Visible = false;
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if (!UpdateView())
            {
                return;
            }

            int index = listBoxUsers.SelectedIndex;
            PasswordForm passwordForm = new PasswordForm(accounts[index].Password);

            passwordForm.PasswordEvents.LoadEdit = () =>
            {
                AccountWithRoles account =  Helper.GetAccount();
                return account.IsDirector();
            };

            passwordForm.PasswordEvents.CheckPassword = (password) =>
            {
                if (password.Password == "")
                {
                    DialogResult result = MessageBox.Show("Пользователь без пароля уязвим \n" +
                        "Вы согласны с этим?", "Изменение пароля", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Пароль не был изменён", "Изменения пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
            };

            passwordForm.PasswordEvents.AfterEnteringCorrect = (password) =>
            {
                if (Helper.UserIsGoest())
                {
                    return;
                }
                if (accounts.ChangePassword(accounts[index].Login, password.Password)) 
                {
                    MessageBox.Show("Пароль успешно изменён", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Пароль не был изменён", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            Hide();
            passwordForm.ShowDialog();
            Show();
            UpdateView();
        }

        private void buttonUserBlocked_Click(object sender, EventArgs e)
        {

            if (!UpdateView())
                return;
            try
            {
                int index = listBoxUsers.SelectedIndex;
                Account account = accounts[index];
                accounts.ChangeBlocked(account.Login);
            }
            catch
            {

            }
            UpdateView();
        }

        private void buttonUserRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить пользователя", "Удаление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
            {
                UpdateForm();
                return;
            }
            if (!UpdateView())
                return;
            try
            {
                int index = listBoxUsers.SelectedIndex;
                AccountWithID account = accounts[index];
                accounts.DeleteFromDB(account.ID);
            }
            catch
            {

            }
            UpdateView();
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            if (!UpdateView())
                return;
            try
            {
                Authorize authorize = new Authorize(add: true);
                Hide();
                authorize.ShowDialog();
                Show();
            }
            catch
            {

            }
            UpdateView();
        }

        private void listBoxUserRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                index = listBoxUsers.SelectedIndex;
                if (index < 0)
                    throw new Exception();
                AccountWithID account = accounts[index];
                int role = (sender as ListBox).SelectedIndex;
                labelRole.Text = account.GetUserWithRoles().Roles[role].GetData();
            }
            catch
            {
                labelRole.Text = "";
            }
        }

        private void buttonRoleDelete_Click(object sender, EventArgs e)
        {
            if (!UpdateView())
                return;
            try
            {
                int index = 0;
                index = listBoxUsers.SelectedIndex;
                if (index < 0)
                    throw new Exception();
                AccountWithID account = accounts[index];
                int role = listBoxUserRoles.SelectedIndex;
                role = account.GetUserWithRoles().Roles[role].ID;
                accounts.DeleteRoleFromDB(account.ID, role);

            }
            catch
            {

            }
            UpdateForm();
        }

        private void listBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                index = (sender as ListBox).SelectedIndex;
                if (index < 0)
                    throw new Exception();
                
                labelRoleName.Text = rolesList[index].GetData();
            }
            catch
            {
                labelRoleName.Text = "";
            }
        }

        private void buttonRoleAdd_Click(object sender, EventArgs e)
        {
            if (!UpdateView())
                return;
            try
            {
                int index = 0;
                index = listBoxUsers.SelectedIndex;
                if (index < 0)
                    throw new Exception();
                AccountWithID account = accounts[index];
                int role = listBoxRoles.SelectedIndex;
                role = rolesList[role].ID;
                accounts.AddRoleForUserInDB(account.ID, role);

            }
            catch
            {

            }
            UpdateForm();
        }
    }
}
