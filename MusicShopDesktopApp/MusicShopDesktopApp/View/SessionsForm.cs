using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    public partial class SessionsForm : Form
    {
        public SessionsForm()
        {
            InitializeComponent();
        }

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

        private void Model_Load(object sender, EventArgs e)
        {
            this.Text += " - " + Application.ProductName + " - " + Application.ProductVersion;

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

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            buttonUpdate_Click(sender, e);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateView();
        }

        SessionsWithEnvirontmentList sessions = new SessionsWithEnvirontmentList();
        int indexSession = 0;

        SessionWithEnvirontment session => sessions[indexSession];

        public void UpdateView(int count = 20)
        {
            timerUpdate.Stop();
            try
            {
                sessions = SessionsController.GetController().Get(Helper.GetSession());
                   
                while(flowLayoutPanelSessions.Rows.Count > 0)
                {
                    flowLayoutPanelSessions.Rows.Clear();
                }

                for(int i = 0; i < sessions.Count; i++)
                {
                    int row = flowLayoutPanelSessions.Rows.Add();
                    flowLayoutPanelSessions.Rows[row].Cells[0].Value = sessions[i].ToString();
                    Color color = Color.White;
                    Color select = Color.Blue;

                    if(sessions[i].Active)
                    {

                        if (sessions[i].This)
                        {
                            color = Color.Pink;
                            select = Color.LightBlue;
                        }
                        else
                        {
                            color = Color.LightGray;
                            select = Color.AliceBlue;
                        }
                    }
                    else
                    {
                        if(!sessions[i].Successfully)
                        {
                            color = Color.OrangeRed;
                            select = Color.Green;
                        }
                        else
                        {
                            color = Color.White;
                            select = Color.Blue;
                        }
                    }

                    flowLayoutPanelSessions.Rows[row].DefaultCellStyle.BackColor = color;
                        flowLayoutPanelSessions.Rows[row].DefaultCellStyle.SelectionBackColor = select;

                    flowLayoutPanelSessions.Rows[row].DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                flowLayoutPanelSessions_CellContentClick(flowLayoutPanelSessions, new DataGridViewCellEventArgs(0, indexSession));

            }
            catch(Exception e)
            {
                if (count > 0)
                {
                    Task taskThis = new Task(() =>
                    {
                        UpdateView(count - 1);
                        
                    });
                    Task task = new Task(() =>
                    {
                        Thread.Sleep(AddressesList.GetRandomMilliSeconds());
                        taskThis.Start();
                    });
                    task.RunSynchronously();
                    return;
                }
                MessageBox.Show(e.Message, "История входов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            timerUpdate.Start();
        }

        private void ButtonSession_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanelSessions_SizeChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < (sender as FlowLayoutPanel).Controls.Count; i++)
            {
                (sender as FlowLayoutPanel).Controls[i].Width = (sender as FlowLayoutPanel).Width - 100;
            }
        }

        private void flowLayoutPanelSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexSession = e.RowIndex;
            }
            catch
            {
                
                if(flowLayoutPanelSessions.Rows.Count > 0)
                {
                    flowLayoutPanelSessions_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
                }
                return;
            }

            try
            {
                textBoxSession.Text = session.ToString().Replace("\n", Environment.NewLine);
            }
            catch
            {

            }
        }

        private void textBoxSession_TextChanged(object sender, EventArgs e)
        {
            buttonCloseSession.Enabled = (sender as TextBox).Text != "";

            if(!buttonCloseSession.Enabled)
            {
                return;
            }

            try
            {
                buttonCloseSession.Enabled = session.Active;
            }
            catch
            {

            }

            if (!buttonCloseSession.Enabled)
                return;

            try
            {
                buttonCloseSession.Enabled = !session.This;
            }
            catch
            {

            }
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SessionsController.GetController().CloseSession(session))
                    throw new Exception();

                MessageBox.Show("Сессия успешно закрыта",
                    "Закрытие сессии",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                UpdateView();
            }
            catch
            {
                MessageBox.Show("Неудалось закрыть сессию \n" +
                    " - Возможно она больше не активна \n" +
                    " - Возможно она больше не уществует",
                    "Закрытие сессии",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonCloseAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите закрыть все сессии, кроме текущей", "Закрытие сессий", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.No)
            {
                UpdateView();
                return;
            }

            try
            {
                if (!SessionsController.GetController().CloseAllSessions(Helper.GetSession()))
                    throw new Exception();

                MessageBox.Show("Все сессии, кроме текущей, успешно закрыты",
                    "Закрытие сессий",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                UpdateView();
            }
            catch
            {
                MessageBox.Show("Неудалось закрыть сессии \n",
                    "Закрытие сессий",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
