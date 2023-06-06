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
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            PasswordEvents = new PasswordController();
        }


        public PasswordForm(string password) : this()
        {
            textInputPassword.Text = password;
        }

        public PasswordForm(Secret password) : this(password.Password)
        {

        }

        public new void Show()
        {
            base.Show();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

            notifyIconApp.Text = Text;

            
        }

        bool loadEdit()
        {
            return PasswordEvents.LoadEdit?.Invoke() ?? true;
        }

        bool beforeInput()
        {
            return PasswordEvents.BeforeInput?.Invoke() ?? false;
        }

        bool checkPassword(Secret password)
        {
            return PasswordEvents.CheckPassword?.Invoke(password) ?? true;
        }

        bool checkPasswordStart(Secret password)
        {
            return PasswordEvents.CheckPasswordStart?.Invoke(password) ?? true;
        }

        void afterEnteringCorrect(string password)
        {
            PasswordEvents.AfterEnteringCorrect?.Invoke(new Secret(password));
        }

        PasswordController passwordEvents;

        public PasswordController PasswordEvents
        {
            get => passwordEvents;
            set => passwordEvents = value;
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

        private void checkBoxShopPassword_CheckedChanged(object sender, EventArgs e)
        {
            textInputPassword.PasswordChar = '\0';
            textInputPassword.UseSystemPasswordChar = !(sender as CheckBox).Checked;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string text = textInputPassword.Value;
            if(!checkPasswordStart(new Secret(text)))
            {
                return;
            }
            if(!checkPassword(new Secret(text)))
            {
                return;
            }

            Hide();

            afterEnteringCorrect(textInputPassword.Value);

            buttonCancel_Click(sender, e);
        }

        private void PasswordForm_Shown(object sender, EventArgs e)
        {
            if (!loadEdit())
            {
                Close();
                return;
            }


            if (beforeInput())
                buttonOK_Click(sender, e);
        }
    }
}
