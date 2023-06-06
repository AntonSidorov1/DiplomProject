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
    public partial class ConnectionSettingsForm : Form
    {
        public ConnectionSettingsForm()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;
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

        private void buttonPasswordShow_Click(object sender, EventArgs e)
        {
            LoginForEditConnection login = new LoginForEditConnection();
            string password = login.GetPassword(Helper.SessionConnection).Password;
            MessageBox.Show("Пароль: " + password, "Пароль", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonConnectionStringEdit_Click(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm();
            Hide();
            connectionForm.ShowDialog();
            Show();
        }

        private void buttonPasswordChange_Click(object sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm(DataBaseConfiguration.Password);
            passwordForm.PasswordEvents.CheckPasswordStart = (password) =>
            {
                if (password.Password != "")
                    return true;

                DialogResult res = MessageBox.Show("Отсутствие пароля приведёт к уязвимости программы и информационной системы \n" +
                    "Вы согласны с этим?",
                    "Смена пароля",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                return res == DialogResult.Yes;
            };
            passwordForm.PasswordEvents.AfterEnteringCorrect = (password) =>
            {
                DataBaseConfiguration.Password = password;

                MessageBox.Show("Пароль успешно сменён", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Hide();
            passwordForm.ShowDialog();
            Show();
        }
    }
}
