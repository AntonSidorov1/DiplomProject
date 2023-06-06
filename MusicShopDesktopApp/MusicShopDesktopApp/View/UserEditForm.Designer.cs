
namespace MusicShopDesktopApp
{
    partial class UserEditForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEditForm));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLogotip = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelVault = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.buttonUserData = new System.Windows.Forms.Button();
            this.buttonUpdateFIO = new System.Windows.Forms.Button();
            this.buttonGetAddresses = new System.Windows.Forms.Button();
            this.buttonTelefonsEdit = new System.Windows.Forms.Button();
            this.buttonEmails = new System.Windows.Forms.Button();
            this.buttonLoginHistory = new System.Windows.Forms.Button();
            this.buttonDropAccount = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Red;
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTitle.Controls.Add(this.tableLayoutPanel1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.panelTitle.Size = new System.Drawing.Size(682, 94);
            this.panelTitle.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxLogotip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonExit, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(678, 86);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxLogotip
            // 
            this.pictureBoxLogotip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxLogotip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogotip.Image = global::MusicShopDesktopApp.Properties.Resources.Logotip1;
            this.pictureBoxLogotip.Location = new System.Drawing.Point(8, 8);
            this.pictureBoxLogotip.Margin = new System.Windows.Forms.Padding(8);
            this.pictureBoxLogotip.Name = "pictureBoxLogotip";
            this.pictureBoxLogotip.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxLogotip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogotip.TabIndex = 0;
            this.pictureBoxLogotip.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Lucida Console", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(94, 8);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(404, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Редактирование аккаунта";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(521, 15);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(15);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(142, 56);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Назад";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelVault
            // 
            this.panelVault.BackColor = System.Drawing.Color.Red;
            this.panelVault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelVault.Controls.Add(this.statusStrip1);
            this.panelVault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVault.Location = new System.Drawing.Point(0, 418);
            this.panelVault.Name = "panelVault";
            this.panelVault.Size = new System.Drawing.Size(682, 79);
            this.panelVault.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDate,
            this.toolStripStatusLabelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 52);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(678, 23);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDate
            // 
            this.toolStripStatusLabelDate.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelDate.Name = "toolStripStatusLabelDate";
            this.toolStripStatusLabelDate.Size = new System.Drawing.Size(218, 17);
            this.toolStripStatusLabelDate.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(218, 17);
            this.toolStripStatusLabelTime.Text = "toolStripStatusLabel1";
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "notifyIcon1";
            this.notifyIconApp.Visible = true;
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanelMain, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(682, 324);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelMain.Controls.Add(this.labelLogin);
            this.flowLayoutPanelMain.Controls.Add(this.buttonChangePassword);
            this.flowLayoutPanelMain.Controls.Add(this.buttonUserData);
            this.flowLayoutPanelMain.Controls.Add(this.buttonUpdateFIO);
            this.flowLayoutPanelMain.Controls.Add(this.buttonGetAddresses);
            this.flowLayoutPanelMain.Controls.Add(this.buttonTelefonsEdit);
            this.flowLayoutPanelMain.Controls.Add(this.buttonEmails);
            this.flowLayoutPanelMain.Controls.Add(this.buttonLoginHistory);
            this.flowLayoutPanelMain.Controls.Add(this.buttonDropAccount);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(83, 23);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(516, 278);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.WrapContents = false;
            this.flowLayoutPanelMain.SizeChanged += new System.EventHandler(this.flowLayoutPanelMain_SizeChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLogin.Location = new System.Drawing.Point(3, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(458, 17);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.AutoSize = true;
            this.buttonChangePassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonChangePassword.Location = new System.Drawing.Point(3, 20);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(458, 50);
            this.buttonChangePassword.TabIndex = 0;
            this.buttonChangePassword.Text = "Сменить пароль";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // buttonUserData
            // 
            this.buttonUserData.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUserData.Location = new System.Drawing.Point(3, 76);
            this.buttonUserData.Name = "buttonUserData";
            this.buttonUserData.Size = new System.Drawing.Size(458, 50);
            this.buttonUserData.TabIndex = 1;
            this.buttonUserData.Text = "Данные пользователя";
            this.buttonUserData.UseVisualStyleBackColor = true;
            this.buttonUserData.Click += new System.EventHandler(this.buttonUserData_Click);
            // 
            // buttonUpdateFIO
            // 
            this.buttonUpdateFIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUpdateFIO.Location = new System.Drawing.Point(3, 132);
            this.buttonUpdateFIO.Name = "buttonUpdateFIO";
            this.buttonUpdateFIO.Size = new System.Drawing.Size(458, 50);
            this.buttonUpdateFIO.TabIndex = 2;
            this.buttonUpdateFIO.Text = "Изменить ФИО";
            this.buttonUpdateFIO.UseVisualStyleBackColor = true;
            this.buttonUpdateFIO.Click += new System.EventHandler(this.buttonUpdateFIO_Click);
            // 
            // buttonGetAddresses
            // 
            this.buttonGetAddresses.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGetAddresses.Location = new System.Drawing.Point(3, 188);
            this.buttonGetAddresses.Name = "buttonGetAddresses";
            this.buttonGetAddresses.Size = new System.Drawing.Size(458, 50);
            this.buttonGetAddresses.TabIndex = 4;
            this.buttonGetAddresses.Text = "Телефоны и Email-адреса";
            this.buttonGetAddresses.UseVisualStyleBackColor = true;
            this.buttonGetAddresses.Click += new System.EventHandler(this.buttonGetAddresses_Click);
            // 
            // buttonTelefonsEdit
            // 
            this.buttonTelefonsEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTelefonsEdit.Location = new System.Drawing.Point(3, 244);
            this.buttonTelefonsEdit.Name = "buttonTelefonsEdit";
            this.buttonTelefonsEdit.Size = new System.Drawing.Size(458, 50);
            this.buttonTelefonsEdit.TabIndex = 5;
            this.buttonTelefonsEdit.Text = "Редактировать телефоны";
            this.buttonTelefonsEdit.UseVisualStyleBackColor = true;
            this.buttonTelefonsEdit.Click += new System.EventHandler(this.buttonTelefonsEdit_Click);
            // 
            // buttonEmails
            // 
            this.buttonEmails.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEmails.Location = new System.Drawing.Point(3, 300);
            this.buttonEmails.Name = "buttonEmails";
            this.buttonEmails.Size = new System.Drawing.Size(458, 50);
            this.buttonEmails.TabIndex = 6;
            this.buttonEmails.Text = "Редактировать Email-адреса";
            this.buttonEmails.UseVisualStyleBackColor = true;
            this.buttonEmails.Click += new System.EventHandler(this.buttonEmails_Click);
            // 
            // buttonLoginHistory
            // 
            this.buttonLoginHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLoginHistory.Location = new System.Drawing.Point(3, 356);
            this.buttonLoginHistory.Name = "buttonLoginHistory";
            this.buttonLoginHistory.Size = new System.Drawing.Size(458, 50);
            this.buttonLoginHistory.TabIndex = 8;
            this.buttonLoginHistory.Text = "История входов";
            this.buttonLoginHistory.UseVisualStyleBackColor = true;
            this.buttonLoginHistory.Click += new System.EventHandler(this.buttonLoginHistory_Click);
            // 
            // buttonDropAccount
            // 
            this.buttonDropAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDropAccount.Location = new System.Drawing.Point(3, 412);
            this.buttonDropAccount.Name = "buttonDropAccount";
            this.buttonDropAccount.Size = new System.Drawing.Size(458, 50);
            this.buttonDropAccount.TabIndex = 7;
            this.buttonDropAccount.Text = "Удалить аккаунт";
            this.buttonDropAccount.UseVisualStyleBackColor = true;
            this.buttonDropAccount.Click += new System.EventHandler(this.buttonDropAccount_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 30000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 497);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(700, 544);
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование аккаунта";
            this.Load += new System.EventHandler(this.Model_Load);
            this.panelTitle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).EndInit();
            this.panelVault.ResumeLayout(false);
            this.panelVault.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxLogotip;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panelVault;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Button buttonUserData;
        private System.Windows.Forms.Button buttonUpdateFIO;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button buttonGetAddresses;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Button buttonTelefonsEdit;
        private System.Windows.Forms.Button buttonEmails;
        private System.Windows.Forms.Button buttonDropAccount;
        private System.Windows.Forms.Button buttonLoginHistory;
    }
}

