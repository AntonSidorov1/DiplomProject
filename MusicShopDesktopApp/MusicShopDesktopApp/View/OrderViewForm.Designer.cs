
namespace MusicShopDesktopApp
{
    partial class OrderViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderViewForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.ColumnRun = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRepeart = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGive = new System.Windows.Forms.Button();
            this.textInputNumber = new MusicShopDesktopApp.TextInput();
            this.textInputInfo = new MusicShopDesktopApp.TextInput();
            this.textInputPickupPoint = new MusicShopDesktopApp.TextInput();
            this.menuStripStatusCange = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOrderCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOrderRun = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOrderExpectRecipient = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonWaitForGoods = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNoOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTakeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSetOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.menuStripStatusCange.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(931, 94);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 86);
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
            this.labelTitle.Size = new System.Drawing.Size(653, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Информация о заказе";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(770, 15);
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
            this.panelVault.Location = new System.Drawing.Point(0, 499);
            this.panelVault.Name = "panelVault";
            this.panelVault.Size = new System.Drawing.Size(931, 79);
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
            this.statusStrip1.Size = new System.Drawing.Size(927, 23);
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
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonUpdate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textInputNumber, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(931, 405);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpdate.Location = new System.Drawing.Point(10, 10);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(10);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(127, 66);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 313);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.26059F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.73941F));
            this.tableLayoutPanel3.Controls.Add(this.textInputInfo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textInputPickupPoint, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewProducts, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(921, 309);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnRun,
            this.ColumnInfo});
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProducts.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersVisible = false;
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.tableLayoutPanel3.SetRowSpan(this.dataGridViewProducts, 2);
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(535, 289);
            this.dataGridViewProducts.TabIndex = 2;
            this.dataGridViewProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellContentClick);
            this.dataGridViewProducts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellContentDoubleClick);
            // 
            // ColumnRun
            // 
            this.ColumnRun.Frozen = true;
            this.ColumnRun.HeaderText = "Просмотреть";
            this.ColumnRun.MinimumWidth = 6;
            this.ColumnRun.Name = "ColumnRun";
            this.ColumnRun.ReadOnly = true;
            this.ColumnRun.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRun.Width = 125;
            // 
            // ColumnInfo
            // 
            this.ColumnInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnInfo.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnInfo.HeaderText = "Информация";
            this.ColumnInfo.MinimumWidth = 6;
            this.ColumnInfo.Name = "ColumnInfo";
            this.ColumnInfo.ReadOnly = true;
            this.ColumnInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.buttonCancel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonRepeart, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(416, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(146, 80);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(140, 34);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRepeart
            // 
            this.buttonRepeart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRepeart.Location = new System.Drawing.Point(3, 43);
            this.buttonRepeart.Name = "buttonRepeart";
            this.buttonRepeart.Size = new System.Drawing.Size(140, 34);
            this.buttonRepeart.TabIndex = 1;
            this.buttonRepeart.Text = "Повторить";
            this.buttonRepeart.UseVisualStyleBackColor = true;
            this.buttonRepeart.Click += new System.EventHandler(this.buttonRepeart_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.buttonGive, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.menuStripStatusCange, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(568, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(196, 80);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // buttonGive
            // 
            this.buttonGive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGive.Location = new System.Drawing.Point(3, 43);
            this.buttonGive.Name = "buttonGive";
            this.buttonGive.Size = new System.Drawing.Size(190, 34);
            this.buttonGive.TabIndex = 0;
            this.buttonGive.Text = "Выдать";
            this.buttonGive.UseVisualStyleBackColor = true;
            this.buttonGive.Click += new System.EventHandler(this.buttonGive_Click);
            // 
            // textInputNumber
            // 
            this.textInputNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputNumber.InputBackColor = System.Drawing.Color.White;
            this.textInputNumber.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputNumber.InputText = "";
            this.textInputNumber.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputNumber.Location = new System.Drawing.Point(151, 3);
            this.textInputNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputNumber.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputNumber.MultiLine = false;
            this.textInputNumber.Name = "textInputNumber";
            this.textInputNumber.NoReadOnly = false;
            this.textInputNumber.PasswordChar = '\0';
            this.textInputNumber.ReadOnly = true;
            this.textInputNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputNumber.Size = new System.Drawing.Size(258, 80);
            this.textInputNumber.TabIndex = 1;
            this.textInputNumber.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputNumber.Title = "Номер заказа";
            this.textInputNumber.UseSystemPasswordChar = false;
            this.textInputNumber.Value = "";
            // 
            // textInputInfo
            // 
            this.textInputInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputInfo.InputBackColor = System.Drawing.Color.White;
            this.textInputInfo.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputInfo.InputText = "";
            this.textInputInfo.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputInfo.Location = new System.Drawing.Point(559, 3);
            this.textInputInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputInfo.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputInfo.MultiLine = true;
            this.textInputInfo.Name = "textInputInfo";
            this.textInputInfo.NoReadOnly = false;
            this.textInputInfo.PasswordChar = '\0';
            this.textInputInfo.ReadOnly = true;
            this.textInputInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textInputInfo.Size = new System.Drawing.Size(358, 148);
            this.textInputInfo.TabIndex = 0;
            this.textInputInfo.TextScrollBar = System.Windows.Forms.ScrollBars.Both;
            this.textInputInfo.Title = "Информация о заказе";
            this.textInputInfo.UseSystemPasswordChar = false;
            this.textInputInfo.Value = "";
            // 
            // textInputPickupPoint
            // 
            this.textInputPickupPoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputPickupPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputPickupPoint.InputBackColor = System.Drawing.Color.White;
            this.textInputPickupPoint.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputPickupPoint.InputText = "";
            this.textInputPickupPoint.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputPickupPoint.Location = new System.Drawing.Point(559, 157);
            this.textInputPickupPoint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputPickupPoint.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputPickupPoint.MultiLine = true;
            this.textInputPickupPoint.Name = "textInputPickupPoint";
            this.textInputPickupPoint.NoReadOnly = false;
            this.textInputPickupPoint.PasswordChar = '\0';
            this.textInputPickupPoint.ReadOnly = true;
            this.textInputPickupPoint.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textInputPickupPoint.Size = new System.Drawing.Size(358, 149);
            this.textInputPickupPoint.TabIndex = 1;
            this.textInputPickupPoint.TextScrollBar = System.Windows.Forms.ScrollBars.Both;
            this.textInputPickupPoint.Title = "Пункт получения";
            this.textInputPickupPoint.UseSystemPasswordChar = false;
            this.textInputPickupPoint.Value = "";
            // 
            // menuStripStatusCange
            // 
            this.menuStripStatusCange.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            this.menuStripStatusCange.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripStatusCange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStripStatusCange.Location = new System.Drawing.Point(0, 0);
            this.menuStripStatusCange.Name = "menuStripStatusCange";
            this.menuStripStatusCange.Size = new System.Drawing.Size(196, 30);
            this.menuStripStatusCange.TabIndex = 1;
            this.menuStripStatusCange.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOrderCreate,
            this.buttonOrderRun,
            this.buttonOrderExpectRecipient,
            this.buttonWaitForGoods,
            this.buttonNoOrder,
            this.buttonTakeOrder,
            this.buttonSetOrder});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 26);
            this.toolStripMenuItem1.Text = "Изменить статус";
            // 
            // buttonOrderCreate
            // 
            this.buttonOrderCreate.Name = "buttonOrderCreate";
            this.buttonOrderCreate.Size = new System.Drawing.Size(360, 26);
            this.buttonOrderCreate.Text = "Создан";
            this.buttonOrderCreate.Click += new System.EventHandler(this.buttonOrderCreate_Click);
            // 
            // buttonOrderRun
            // 
            this.buttonOrderRun.Name = "buttonOrderRun";
            this.buttonOrderRun.Size = new System.Drawing.Size(360, 26);
            this.buttonOrderRun.Text = "В пути";
            this.buttonOrderRun.Click += new System.EventHandler(this.buttonOrderRun_Click);
            // 
            // buttonOrderExpectRecipient
            // 
            this.buttonOrderExpectRecipient.Name = "buttonOrderExpectRecipient";
            this.buttonOrderExpectRecipient.Size = new System.Drawing.Size(360, 26);
            this.buttonOrderExpectRecipient.Text = "Ожидает получателя";
            this.buttonOrderExpectRecipient.Click += new System.EventHandler(this.buttonOrderExpectRecipient_Click);
            // 
            // buttonWaitForGoods
            // 
            this.buttonWaitForGoods.Name = "buttonWaitForGoods";
            this.buttonWaitForGoods.Size = new System.Drawing.Size(360, 26);
            this.buttonWaitForGoods.Text = "Ожидает поступления товаров";
            this.buttonWaitForGoods.Click += new System.EventHandler(this.buttonWaitForGoods_Click);
            // 
            // buttonNoOrder
            // 
            this.buttonNoOrder.Name = "buttonNoOrder";
            this.buttonNoOrder.Size = new System.Drawing.Size(360, 26);
            this.buttonNoOrder.Text = "Потерян";
            this.buttonNoOrder.Click += new System.EventHandler(this.buttonNoOrder_Click);
            // 
            // buttonTakeOrder
            // 
            this.buttonTakeOrder.Name = "buttonTakeOrder";
            this.buttonTakeOrder.Size = new System.Drawing.Size(360, 26);
            this.buttonTakeOrder.Text = "Принят";
            this.buttonTakeOrder.Click += new System.EventHandler(this.buttonTakeOrder_Click);
            // 
            // buttonSetOrder
            // 
            this.buttonSetOrder.Name = "buttonSetOrder";
            this.buttonSetOrder.Size = new System.Drawing.Size(360, 26);
            this.buttonSetOrder.Text = "Собран";
            this.buttonSetOrder.Click += new System.EventHandler(this.buttonSetOrder_Click);
            // 
            // OrderViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(931, 578);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripStatusCange;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(800, 570);
            this.Name = "OrderViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о заказе";
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
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.menuStripStatusCange.ResumeLayout(false);
            this.menuStripStatusCange.PerformLayout();
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
        private TextInput textInputNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private TextInput textInputInfo;
        private TextInput textInputPickupPoint;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRepeart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonGive;
        private System.Windows.Forms.MenuStrip menuStripStatusCange;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buttonOrderCreate;
        private System.Windows.Forms.ToolStripMenuItem buttonOrderRun;
        private System.Windows.Forms.ToolStripMenuItem buttonOrderExpectRecipient;
        private System.Windows.Forms.ToolStripMenuItem buttonWaitForGoods;
        private System.Windows.Forms.ToolStripMenuItem buttonNoOrder;
        private System.Windows.Forms.ToolStripMenuItem buttonTakeOrder;
        private System.Windows.Forms.ToolStripMenuItem buttonSetOrder;
    }
}

