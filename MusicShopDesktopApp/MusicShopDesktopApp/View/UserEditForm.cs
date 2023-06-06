using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileManegerJson;
using Microsoft.VisualBasic;

namespace MusicShopDesktopApp
{
    public partial class UserEditForm : Form
    {
        public UserEditForm()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;
            UpdateView();
        }

        public new void Show()
        {
            base.Show();
            UpdateView();
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

        bool UpdateView(int count = 20)
        {
            timerUpdate.Stop();
            try
            {
                AccountWithRoles account = Helper.GetAccount();
                labelLogin.Text = $"{account.Login}\n" +
                    $"{account.FIO}";

                

                if (Helper.UserIsGoest())
                {

                    throw new Exception();
                }
            }
            catch
            {
                if (count > 0)
                    return UpdateView(count - 1);

                MessageBox.Show("Вы больше не авторизированы в системе", "Редактирование аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();

                return false;
            }


            int with = flowLayoutPanelMain.Width;
            Control.ControlCollection controls = flowLayoutPanelMain.Controls;
            for(int i = 0; i < controls.Count; i++)
            {
                controls[i].Width = with - 40;
            }
            timerUpdate.Start();
            return true;
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

        private void flowLayoutPanelMain_SizeChanged(object sender, EventArgs e)
        {

            int with = flowLayoutPanelMain.Width;
            Control.ControlCollection controls = flowLayoutPanelMain.Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                controls[i].Width = with - 40;
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if(!UpdateView())
            {
                return;
            }

            PasswordForm passwordForm = new PasswordForm(Helper.GetAccount().Password);

            passwordForm.PasswordEvents.LoadEdit = () =>
            {
                Helper.GetAccount();
                return !Helper.UserIsGoest();
            };

            passwordForm.PasswordEvents.CheckPassword = (password) =>
            {
                if(password.Password == "")
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
                if(Helper.UserIsGoest())
                {
                    return;
                }
                AccountsController controller = new AccountsController();
                SecretSession secret = new SecretSession()
                {
                    Token = Helper.Session.Token,
                    Password = password.Password
                };
                if(controller.ChangePassword(secret))
                {
                    MessageBox.Show("Пароль успешно изменён", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            Hide();
            passwordForm.ShowDialog();
            Show();
        }

        private void buttonUserData_Click(object sender, EventArgs e)
        {
            if (!UpdateView())
            {
                return;
            }
            AccountWithRoles account = Helper.GetAccount();

            string data = $"Логин: {account.Login} \n" +
                $"Пароль: {account.Password} \n" +
                $"ФИО: {account.FIO.Initials} \n" +
                $"Роли: \n" ;

            for (int i = 0; i < account.Roles.Count; i++)
            {
                data += $"{i+1}) {account.Roles[i].GetData()} \n";
            }

            MessageBox.Show(data,
                "Данные пользователя",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonUpdateFIO_Click(object sender, EventArgs e)
        {
            if (!UpdateView())
            {
                return;
            }
            string fio = Helper.GetAccount().FIO.Initials;
            //fio = Interaction.InputBox("Введите ФИО", "Изменение ФИО", fio, Left + 100, Top + 100);

            FormNoteEdit form = new FormNoteEdit(fio);
            Hide();
            form.ShowDialog();
            Show();
            if(!form.Save)
            {
                UpdateView();
                return;
            }
            fio = form.Value;

            if (!UpdateView())
            {
                return;
            }
            FIO initials = new FIO(fio);
            if(AccountsController.GetController().SetFIO(initials.GetInitialsSession(Helper.Session.Token)))
            {
                MessageBox.Show("ФИО успешно изменены", "Смена ФИО", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось изменить ФИО", "Смена ФИО", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateView();

        }

        private void buttonGetAddresses_Click(object sender, EventArgs e)
        {
            if (!UpdateView())
            {
                return;
            }

            AccountWithAddress account = new AccountWithAddress();
            try
            {
                account = Helper.GetAccount().GetWithAddress();
                MessageBox.Show(account.GetAdresses(), "Телефоны и Email-адреса", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
            UpdateView();

            
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void buttonTelefonsEdit_Click(object sender, EventArgs e)
        {
            AdressesEdit adresses = new AdressesEdit(AddressType.Telefon);
            Hide();
            adresses.ShowDialog();
            Show();
        }

        private void buttonEmails_Click(object sender, EventArgs e)
        {
            AdressesEdit adresses = new AdressesEdit(AddressType.Email);
            Hide();
            adresses.ShowDialog();
            Show();
        }

        private void buttonDropAccount_Click(object sender, EventArgs e)
        {
            timerUpdate.Stop();

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить аккаунт?", "Удаление аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(result == DialogResult.Yes)
            {
                if(!UpdateView())
                {
                    return;
                }

                bool success = AccountsController.GetController().DeleteUser(Helper.GetSession());
                if(success)
                {
                    MessageBox.Show("Аккаунт успешно удалён", "Удаление аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось удалить аккаунт \n" +
                        "Возможно аккаунт больше не существует, или вы больше не авторизированы", "Удаление аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (UpdateView())
                        timerUpdate.Start();
                    return;
                }
                Close();
            }

        }

        private void buttonLoginHistory_Click(object sender, EventArgs e)
        {
            SessionsForm sessionsForm = new SessionsForm();
            Hide();
            sessionsForm.ShowDialog();
            Show();
        }
    }
}
