
namespace MusicShopDesktopApp
{
    partial class ShopEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopEditForm));
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
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.загрузитьИзменитьСохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonByStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSity = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelOrganization = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textInputAddress = new MusicShopDesktopApp.TextInput();
            this.textInputName = new MusicShopDesktopApp.TextInput();
            this.textInputSchedule = new MusicShopDesktopApp.TextInput();
            this.textInputTelephone = new MusicShopDesktopApp.TextInput();
            this.textInputSitePath = new MusicShopDesktopApp.TextInput();
            this.textInputEmail = new MusicShopDesktopApp.TextInput();
            this.buttonNameSet = new System.Windows.Forms.Button();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.buttonPhone = new System.Windows.Forms.Button();
            this.buttonAddress = new System.Windows.Forms.Button();
            this.buttonSite = new System.Windows.Forms.Button();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.textInputShop = new MusicShopDesktopApp.TextInput();
            this.textInputPounktOfIssue = new MusicShopDesktopApp.TextInput();
            this.buttonShopSet = new System.Windows.Forms.Button();
            this.buttonPounktOfIssue = new System.Windows.Forms.Button();
            this.labelSite = new System.Windows.Forms.Label();
            this.buttonInfoStock = new System.Windows.Forms.Button();
            this.buttonOrgInfo = new System.Windows.Forms.Button();
            this.timerSaveShow = new System.Windows.Forms.Timer(this.components);
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(930, 94);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 86);
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
            this.labelTitle.Size = new System.Drawing.Size(652, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Торговый пункт (пункт получения)";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(769, 15);
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
            this.panelVault.Location = new System.Drawing.Point(0, 486);
            this.panelVault.Name = "panelVault";
            this.panelVault.Size = new System.Drawing.Size(930, 60);
            this.panelVault.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDate,
            this.toolStripStatusLabelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 33);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(926, 23);
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
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 30000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonUpdate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(930, 392);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpdate.Location = new System.Drawing.Point(3, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(183, 44);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.38775F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.93878F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.80952F));
            this.tableLayoutPanel3.Controls.Add(this.buttonSave, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonInfo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.menuStrip1, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(192, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(735, 44);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(209, 38);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInfo.Location = new System.Drawing.Point(218, 3);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(191, 38);
            this.buttonInfo.TabIndex = 1;
            this.buttonInfo.Text = "Информация";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьИзменитьСохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(412, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(323, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // загрузитьИзменитьСохранитьToolStripMenuItem
            // 
            this.загрузитьИзменитьСохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonByStore});
            this.загрузитьИзменитьСохранитьToolStripMenuItem.Name = "загрузитьИзменитьСохранитьToolStripMenuItem";
            this.загрузитьИзменитьСохранитьToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.загрузитьИзменитьСохранитьToolStripMenuItem.Text = "Другим окном";
            // 
            // buttonByStore
            // 
            this.buttonByStore.Name = "buttonByStore";
            this.buttonByStore.Size = new System.Drawing.Size(270, 26);
            this.buttonByStore.Text = "Как торговую точку";
            this.buttonByStore.Click += new System.EventHandler(this.buttonByStore_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.labelSity, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelStock, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelOrganization, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelSite, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.buttonInfoStock, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonOrgInfo, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(924, 336);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // labelSity
            // 
            this.labelSity.AutoSize = true;
            this.labelSity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSity.Location = new System.Drawing.Point(3, 0);
            this.labelSity.Name = "labelSity";
            this.labelSity.Size = new System.Drawing.Size(302, 40);
            this.labelSity.TabIndex = 0;
            this.labelSity.Text = "label1";
            this.labelSity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStock.Location = new System.Drawing.Point(311, 0);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(302, 40);
            this.labelStock.TabIndex = 1;
            this.labelStock.Text = "label1";
            this.labelStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOrganization
            // 
            this.labelOrganization.AutoSize = true;
            this.labelOrganization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOrganization.Location = new System.Drawing.Point(3, 40);
            this.labelOrganization.Name = "labelOrganization";
            this.labelOrganization.Size = new System.Drawing.Size(302, 40);
            this.labelOrganization.TabIndex = 2;
            this.labelOrganization.Text = "label1";
            this.labelOrganization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel4.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 250);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel5.Controls.Add(this.textInputAddress, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.textInputName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.textInputSchedule, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.textInputTelephone, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.textInputSitePath, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.textInputEmail, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.buttonNameSet, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonSchedule, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonPhone, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonAddress, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.buttonSite, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.buttonEmail, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.textInputShop, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.textInputPounktOfIssue, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.buttonShopSet, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.buttonPounktOfIssue, 3, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(914, 246);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // textInputAddress
            // 
            this.textInputAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputAddress.GetTextProperty = null;
            this.textInputAddress.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputAddress.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputAddress.InputKeyPressToBox = null;
            this.textInputAddress.InputText = "";
            this.textInputAddress.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputAddress.Location = new System.Drawing.Point(3, 113);
            this.textInputAddress.MaxLength = 32767;
            this.textInputAddress.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputAddress.MultiLine = false;
            this.textInputAddress.Name = "textInputAddress";
            this.textInputAddress.NoReadOnly = true;
            this.textInputAddress.PasswordChar = '\0';
            this.textInputAddress.ReadOnly = false;
            this.textInputAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputAddress.ShortcutsEnabled = true;
            this.textInputAddress.Size = new System.Drawing.Size(222, 64);
            this.textInputAddress.TabIndex = 1;
            this.textInputAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputAddress.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputAddress.Title = "Адрес";
            this.textInputAddress.UseSystemPasswordChar = false;
            this.textInputAddress.Value = "";
            this.textInputAddress.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputAddress_InputText_Changed);
            this.textInputAddress.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textInputAddress_RegionChanged);
            // 
            // textInputName
            // 
            this.textInputName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputName.GetTextProperty = null;
            this.textInputName.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputName.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputName.InputKeyPressToBox = null;
            this.textInputName.InputText = "";
            this.textInputName.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputName.Location = new System.Drawing.Point(3, 3);
            this.textInputName.MaxLength = 32767;
            this.textInputName.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputName.MultiLine = false;
            this.textInputName.Name = "textInputName";
            this.textInputName.NoReadOnly = true;
            this.textInputName.PasswordChar = '\0';
            this.textInputName.ReadOnly = false;
            this.textInputName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputName.ShortcutsEnabled = true;
            this.textInputName.Size = new System.Drawing.Size(222, 64);
            this.textInputName.TabIndex = 0;
            this.textInputName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputName.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputName.Title = "Название";
            this.textInputName.UseSystemPasswordChar = false;
            this.textInputName.Value = "";
            this.textInputName.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputName_InputText_Changed);
            this.textInputName.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textInputName_ReadOnlyChanged);
            // 
            // textInputSchedule
            // 
            this.textInputSchedule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputSchedule.GetTextProperty = null;
            this.textInputSchedule.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputSchedule.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputSchedule.InputKeyPressToBox = null;
            this.textInputSchedule.InputText = "";
            this.textInputSchedule.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputSchedule.Location = new System.Drawing.Point(231, 3);
            this.textInputSchedule.MaxLength = 32767;
            this.textInputSchedule.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputSchedule.MultiLine = false;
            this.textInputSchedule.Name = "textInputSchedule";
            this.textInputSchedule.NoReadOnly = true;
            this.textInputSchedule.PasswordChar = '\0';
            this.textInputSchedule.ReadOnly = false;
            this.textInputSchedule.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputSchedule.ShortcutsEnabled = true;
            this.textInputSchedule.Size = new System.Drawing.Size(222, 64);
            this.textInputSchedule.TabIndex = 0;
            this.textInputSchedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputSchedule.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputSchedule.Title = "Режим работы";
            this.textInputSchedule.UseSystemPasswordChar = false;
            this.textInputSchedule.Value = "";
            this.textInputSchedule.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputShedule_InputText_Changed);
            this.textInputSchedule.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textInputSchedule_ReadOnlyChanged);
            // 
            // textInputTelephone
            // 
            this.textInputTelephone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputTelephone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputTelephone.GetTextProperty = null;
            this.textInputTelephone.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputTelephone.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputTelephone.InputKeyPressToBox = null;
            this.textInputTelephone.InputText = "";
            this.textInputTelephone.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputTelephone.Location = new System.Drawing.Point(459, 3);
            this.textInputTelephone.MaxLength = 32767;
            this.textInputTelephone.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputTelephone.MultiLine = false;
            this.textInputTelephone.Name = "textInputTelephone";
            this.textInputTelephone.NoReadOnly = true;
            this.textInputTelephone.PasswordChar = '\0';
            this.textInputTelephone.ReadOnly = false;
            this.textInputTelephone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputTelephone.ShortcutsEnabled = true;
            this.textInputTelephone.Size = new System.Drawing.Size(222, 64);
            this.textInputTelephone.TabIndex = 0;
            this.textInputTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputTelephone.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputTelephone.Title = "Телефон";
            this.textInputTelephone.UseSystemPasswordChar = false;
            this.textInputTelephone.Value = "";
            this.textInputTelephone.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputTelephone_InputText_Changed);
            this.textInputTelephone.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textInputTelephone_ReadOnlyChanged);
            // 
            // textInputSitePath
            // 
            this.textInputSitePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputSitePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputSitePath.GetTextProperty = null;
            this.textInputSitePath.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputSitePath.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputSitePath.InputKeyPressToBox = null;
            this.textInputSitePath.InputText = "";
            this.textInputSitePath.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputSitePath.Location = new System.Drawing.Point(231, 113);
            this.textInputSitePath.MaxLength = 32767;
            this.textInputSitePath.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputSitePath.MultiLine = false;
            this.textInputSitePath.Name = "textInputSitePath";
            this.textInputSitePath.NoReadOnly = true;
            this.textInputSitePath.PasswordChar = '\0';
            this.textInputSitePath.ReadOnly = false;
            this.textInputSitePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputSitePath.ShortcutsEnabled = true;
            this.textInputSitePath.Size = new System.Drawing.Size(222, 64);
            this.textInputSitePath.TabIndex = 0;
            this.textInputSitePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputSitePath.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputSitePath.Title = "Путь на сайте";
            this.textInputSitePath.UseSystemPasswordChar = false;
            this.textInputSitePath.Value = "";
            this.textInputSitePath.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputSitePath_InputText_Changed);
            this.textInputSitePath.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textInputSitePath_ReadOnlyChanged);
            // 
            // textInputEmail
            // 
            this.textInputEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputEmail.GetTextProperty = null;
            this.textInputEmail.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputEmail.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputEmail.InputKeyPressToBox = null;
            this.textInputEmail.InputText = "";
            this.textInputEmail.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputEmail.Location = new System.Drawing.Point(459, 113);
            this.textInputEmail.MaxLength = 32767;
            this.textInputEmail.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputEmail.MultiLine = false;
            this.textInputEmail.Name = "textInputEmail";
            this.textInputEmail.NoReadOnly = true;
            this.textInputEmail.PasswordChar = '\0';
            this.textInputEmail.ReadOnly = false;
            this.textInputEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputEmail.ShortcutsEnabled = true;
            this.textInputEmail.Size = new System.Drawing.Size(222, 64);
            this.textInputEmail.TabIndex = 0;
            this.textInputEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputEmail.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputEmail.Title = "E-mail";
            this.textInputEmail.UseSystemPasswordChar = false;
            this.textInputEmail.Value = "";
            this.textInputEmail.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputEmail_InputText_Changed);
            this.textInputEmail.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textInputEmail_ReadOnlyChanged);
            // 
            // buttonNameSet
            // 
            this.buttonNameSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNameSet.Location = new System.Drawing.Point(4, 74);
            this.buttonNameSet.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNameSet.Name = "buttonNameSet";
            this.buttonNameSet.Size = new System.Drawing.Size(220, 32);
            this.buttonNameSet.TabIndex = 2;
            this.buttonNameSet.Text = "Задать";
            this.buttonNameSet.UseVisualStyleBackColor = true;
            this.buttonNameSet.Click += new System.EventHandler(this.buttonNameSet_Click);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSchedule.Location = new System.Drawing.Point(232, 74);
            this.buttonSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(220, 32);
            this.buttonSchedule.TabIndex = 2;
            this.buttonSchedule.Text = "Задать";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // buttonPhone
            // 
            this.buttonPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPhone.Location = new System.Drawing.Point(460, 74);
            this.buttonPhone.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPhone.Name = "buttonPhone";
            this.buttonPhone.Size = new System.Drawing.Size(220, 32);
            this.buttonPhone.TabIndex = 2;
            this.buttonPhone.Text = "Задать";
            this.buttonPhone.UseVisualStyleBackColor = true;
            this.buttonPhone.Click += new System.EventHandler(this.buttonPhone_Click);
            // 
            // buttonAddress
            // 
            this.buttonAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddress.Location = new System.Drawing.Point(4, 184);
            this.buttonAddress.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddress.Name = "buttonAddress";
            this.buttonAddress.Size = new System.Drawing.Size(220, 32);
            this.buttonAddress.TabIndex = 2;
            this.buttonAddress.Text = "Задать";
            this.buttonAddress.UseVisualStyleBackColor = true;
            this.buttonAddress.Click += new System.EventHandler(this.buttonAddress_Click);
            // 
            // buttonSite
            // 
            this.buttonSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSite.Location = new System.Drawing.Point(232, 184);
            this.buttonSite.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSite.Name = "buttonSite";
            this.buttonSite.Size = new System.Drawing.Size(220, 32);
            this.buttonSite.TabIndex = 2;
            this.buttonSite.Text = "Задать";
            this.buttonSite.UseVisualStyleBackColor = true;
            this.buttonSite.Click += new System.EventHandler(this.buttonSite_Click);
            // 
            // buttonEmail
            // 
            this.buttonEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEmail.Location = new System.Drawing.Point(460, 184);
            this.buttonEmail.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(220, 32);
            this.buttonEmail.TabIndex = 2;
            this.buttonEmail.Text = "Задать";
            this.buttonEmail.UseVisualStyleBackColor = true;
            this.buttonEmail.Click += new System.EventHandler(this.buttonEmail_Click);
            // 
            // textInputShop
            // 
            this.textInputShop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputShop.GetTextProperty = null;
            this.textInputShop.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputShop.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputShop.InputKeyPressToBox = null;
            this.textInputShop.InputText = "";
            this.textInputShop.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputShop.Location = new System.Drawing.Point(688, 3);
            this.textInputShop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputShop.MaxLength = 32767;
            this.textInputShop.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputShop.MultiLine = false;
            this.textInputShop.Name = "textInputShop";
            this.textInputShop.NoReadOnly = true;
            this.textInputShop.PasswordChar = '\0';
            this.textInputShop.ReadOnly = false;
            this.textInputShop.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputShop.ShortcutsEnabled = true;
            this.textInputShop.Size = new System.Drawing.Size(222, 64);
            this.textInputShop.TabIndex = 3;
            this.textInputShop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputShop.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputShop.Title = "Магазин";
            this.textInputShop.UseSystemPasswordChar = false;
            this.textInputShop.Value = "";
            this.textInputShop.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputShop_InputText_Changed);
            this.textInputShop.GetText += new MusicShopDesktopApp.TextInput.GetTextControl(this.textInputShop_GetText);
            // 
            // textInputPounktOfIssue
            // 
            this.textInputPounktOfIssue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputPounktOfIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputPounktOfIssue.GetTextProperty = null;
            this.textInputPounktOfIssue.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputPounktOfIssue.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputPounktOfIssue.InputKeyPressToBox = null;
            this.textInputPounktOfIssue.InputText = "";
            this.textInputPounktOfIssue.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputPounktOfIssue.Location = new System.Drawing.Point(688, 113);
            this.textInputPounktOfIssue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputPounktOfIssue.MaxLength = 32767;
            this.textInputPounktOfIssue.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputPounktOfIssue.MultiLine = false;
            this.textInputPounktOfIssue.Name = "textInputPounktOfIssue";
            this.textInputPounktOfIssue.NoReadOnly = true;
            this.textInputPounktOfIssue.PasswordChar = '\0';
            this.textInputPounktOfIssue.ReadOnly = false;
            this.textInputPounktOfIssue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputPounktOfIssue.ShortcutsEnabled = true;
            this.textInputPounktOfIssue.Size = new System.Drawing.Size(222, 64);
            this.textInputPounktOfIssue.TabIndex = 4;
            this.textInputPounktOfIssue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputPounktOfIssue.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputPounktOfIssue.Title = "Пункт получения";
            this.textInputPounktOfIssue.UseSystemPasswordChar = false;
            this.textInputPounktOfIssue.Value = "";
            this.textInputPounktOfIssue.GetText += new MusicShopDesktopApp.TextInput.GetTextControl(this.textInputPounktOfIssue_GetText);
            // 
            // buttonShopSet
            // 
            this.buttonShopSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShopSet.Location = new System.Drawing.Point(688, 74);
            this.buttonShopSet.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShopSet.Name = "buttonShopSet";
            this.buttonShopSet.Size = new System.Drawing.Size(222, 32);
            this.buttonShopSet.TabIndex = 5;
            this.buttonShopSet.Text = "Задать";
            this.buttonShopSet.UseVisualStyleBackColor = true;
            this.buttonShopSet.Click += new System.EventHandler(this.buttonShopSet_Click);
            // 
            // buttonPounktOfIssue
            // 
            this.buttonPounktOfIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPounktOfIssue.Location = new System.Drawing.Point(688, 184);
            this.buttonPounktOfIssue.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPounktOfIssue.Name = "buttonPounktOfIssue";
            this.buttonPounktOfIssue.Size = new System.Drawing.Size(222, 32);
            this.buttonPounktOfIssue.TabIndex = 6;
            this.buttonPounktOfIssue.Text = "Задать";
            this.buttonPounktOfIssue.UseVisualStyleBackColor = true;
            this.buttonPounktOfIssue.Click += new System.EventHandler(this.buttonPickupPointSet_Click);
            // 
            // labelSite
            // 
            this.labelSite.AutoSize = true;
            this.labelSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSite.Location = new System.Drawing.Point(311, 40);
            this.labelSite.Name = "labelSite";
            this.labelSite.Size = new System.Drawing.Size(302, 40);
            this.labelSite.TabIndex = 4;
            this.labelSite.Text = "label1";
            this.labelSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonInfoStock
            // 
            this.buttonInfoStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInfoStock.Location = new System.Drawing.Point(619, 3);
            this.buttonInfoStock.Name = "buttonInfoStock";
            this.buttonInfoStock.Size = new System.Drawing.Size(302, 34);
            this.buttonInfoStock.TabIndex = 5;
            this.buttonInfoStock.Text = "Информация о складе";
            this.buttonInfoStock.UseVisualStyleBackColor = true;
            this.buttonInfoStock.Click += new System.EventHandler(this.buttonInfoStock_Click);
            // 
            // buttonOrgInfo
            // 
            this.buttonOrgInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOrgInfo.Location = new System.Drawing.Point(619, 43);
            this.buttonOrgInfo.Name = "buttonOrgInfo";
            this.buttonOrgInfo.Size = new System.Drawing.Size(302, 34);
            this.buttonOrgInfo.TabIndex = 6;
            this.buttonOrgInfo.Text = "Информация о торговой сети";
            this.buttonOrgInfo.UseVisualStyleBackColor = true;
            this.buttonOrgInfo.Click += new System.EventHandler(this.buttonOrgInfo_Click);
            // 
            // timerSaveShow
            // 
            this.timerSaveShow.Enabled = true;
            this.timerSaveShow.Tick += new System.EventHandler(this.timerSaveShow_Tick);
            // 
            // ShopEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 546);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(538, 544);
            this.Name = "ShopEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Торговый пункт (пункт получения)";
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
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
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelSity;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelOrganization;
        private System.Windows.Forms.Timer timerSaveShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private TextInput textInputName;
        private TextInput textInputSchedule;
        private TextInput textInputTelephone;
        private TextInput textInputSitePath;
        private TextInput textInputEmail;
        private TextInput textInputAddress;
        private System.Windows.Forms.Label labelSite;
        private System.Windows.Forms.Button buttonNameSet;
        private System.Windows.Forms.Button buttonSchedule;
        private System.Windows.Forms.Button buttonPhone;
        private System.Windows.Forms.Button buttonAddress;
        private System.Windows.Forms.Button buttonSite;
        private System.Windows.Forms.Button buttonEmail;
        private System.Windows.Forms.Button buttonInfo;
        private TextInput textInputShop;
        private TextInput textInputPounktOfIssue;
        private System.Windows.Forms.Button buttonShopSet;
        private System.Windows.Forms.Button buttonPounktOfIssue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзменитьСохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonByStore;
        private System.Windows.Forms.Button buttonInfoStock;
        private System.Windows.Forms.Button buttonOrgInfo;
    }
}

