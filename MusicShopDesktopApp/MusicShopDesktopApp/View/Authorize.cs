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
    public partial class Authorize : Form
    {
        public Authorize(bool registrate = false, bool add = false)
        {
            this.registrate = registrate;
            this.add = add;
            InitializeComponent();
        }

        bool registrate = false;
        bool add = false;

        private void Model_Load(object sender, EventArgs e)
        {
            if(registrate)
            {
                Text = "Регистрация";
                labelTitle.Text = "Регистрация";
                buttonSignIn.Text = "Зарегистрироваться";
                checkBoxLogIn.Visible = true;
            }
            if(add)
            {
                Text = "Добавление пользователя";
                labelTitle.Text = "Добавление пользователя";
                buttonSignIn.Text = "Добавить";
                checkBoxLogIn.Visible = false;

            }

            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;
            buttonRegistrate.Visible = !registrate && !add;
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

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textInputPassword.UseSystemPasswordChar = !(sender as CheckBox).Checked;
            textInputPassword.PasswordChar = '\0';
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if(!DataBaseConfiguration.Check())
            {
                MessageBox.Show("Не удаётся подключиться к базе данных", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataBaseConnectionEdit connectionEdit = new DataBaseConnectionEdit();
            try
            {
                Helper.GetEnvirontmentByUser();
            }
            catch
            {
                if (!connectionEdit.Check())
                {
                    MessageBox.Show("Не удаётся подключиться к базе данных", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string login = textInputLogin.Value;
            string password = textInputPassword.Value;

            Account account = new Account
            {
                Login = login,
                Password = password
            };

            if(add)
            {
                if (login == "")
                {
                    MessageBox.Show("Введите логин", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (password == "")
                {


                    DialogResult result = MessageBox.Show("Пользователь без пароля уязвим \n" +
                        "Вы согласны с этим?", "Добавление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Пользователь не был создан", "Добавление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    int user = AccountsList.GetDatasListFromDB().AddUserToDB(new Account
                    {
                        Login = login,
                        Password = password
                    });
                    if (user < 1)
                        throw new Exception();

                    MessageBox.Show("Пользователь успешно добавлен", "Добавление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Невозможно добавить пользователя \n" +
                        " Возможно логин уже существует", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }


            if (!registrate)
            {
                try
                {
                    Helper.Session = SessionsController.
                        GetController().
                        SignIn(Helper.EnvirontmentSession, account);

                    MessageBox.Show("Вы успешно авторизировались", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                    return;
                }
                catch(UserException ex)
                {
                    MessageBox.Show(ex.Message, $"Ошибка авторизации ({ex.Code})", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(Exception ex)
                {

                    MessageBox.Show("Неверный логин или пароль, или пользователь заблокирован \n" +
                        "Или, пользователь не имеет ролей в системе \n" +
                        "Или, подключиться к базе данных не удаётся", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                if (login == "")
                {
                    MessageBox.Show("Введите логин", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (password == "")
                {
                    

                    DialogResult result = MessageBox.Show("Пользователь без пароля уязвим \n" +
                        "Вы согласны с этим?", "Регистрация", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(result == DialogResult.No)
                    {
                        MessageBox.Show("Пользователь не был создан", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    AccountsController controller = new AccountsController();
                    RegistrateSession session = controller.Registrate(account, Helper.Session);

                    MessageBox.Show("Вы успешно зарегистрировались", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!checkBoxLogIn.Checked)
                    {
                        Close();
                        return;
                    }
                    else
                    {
                        RegistrateEnvirontmentSession registrate = new RegistrateEnvirontmentSession(session.RegistrateToken);

                        registrate.EnvirontmentToken = SessionsController.GetController().SignOut(Helper.Session).EnvirontmentToken;

                        Helper.Session = SessionsController.
                        GetController().
                        SignInByRegistrateToken(registrate);

                        MessageBox.Show("Вы успешно авторизировались", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно зарегистрироваться \n" +
                        " Возможно логин уже существует", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRegistrate_Click(object sender, EventArgs e)
        {
            Authorize authorize = new Authorize(true);
            Hide();
            authorize.ShowDialog();
            Show();
            if (!Helper.UserIsGoest())
                Close();
        }
    }
}
