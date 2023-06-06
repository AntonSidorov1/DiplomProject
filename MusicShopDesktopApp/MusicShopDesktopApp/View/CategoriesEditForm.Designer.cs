
namespace MusicShopDesktopApp
{
    partial class CategoriesEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriesEditForm));
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
            this.comboBoxWithNameCategoryFilters = new MusicShopDesktopApp.ComboBoxWithName();
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonLine = new System.Windows.Forms.RadioButton();
            this.radioButtonTree = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCategory = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCategoryData = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxEditFilters = new MusicShopDesktopApp.ComboBoxWithName();
            this.textInputCategoryName = new MusicShopDesktopApp.TextInput();
            this.labelCategoryEditName = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpdateCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCutToNowCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddToRootCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddToNowCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCopyEdit = new System.Windows.Forms.Button();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(873, 94);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 86);
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
            this.labelTitle.Size = new System.Drawing.Size(595, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Редактирование категорий";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(712, 15);
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
            this.panelVault.Size = new System.Drawing.Size(873, 79);
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
            this.statusStrip1.Size = new System.Drawing.Size(869, 23);
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 228F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonUpdate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(873, 324);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpdate.Location = new System.Drawing.Point(3, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(222, 44);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.comboBoxWithNameCategoryFilters, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listBoxCategories, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(222, 268);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // comboBoxWithNameCategoryFilters
            // 
            this.comboBoxWithNameCategoryFilters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.comboBoxWithNameCategoryFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxWithNameCategoryFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWithNameCategoryFilters.DropDownWith = 202;
            this.comboBoxWithNameCategoryFilters.Location = new System.Drawing.Point(4, 3);
            this.comboBoxWithNameCategoryFilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxWithNameCategoryFilters.Name = "comboBoxWithNameCategoryFilters";
            this.comboBoxWithNameCategoryFilters.NoReadOnly = true;
            this.comboBoxWithNameCategoryFilters.ReadOnly = false;
            this.comboBoxWithNameCategoryFilters.SelectedIndex = -1;
            this.comboBoxWithNameCategoryFilters.SelectedItem = null;
            this.comboBoxWithNameCategoryFilters.Size = new System.Drawing.Size(214, 66);
            this.comboBoxWithNameCategoryFilters.TabIndex = 0;
            this.comboBoxWithNameCategoryFilters.Title = "Фильтры категорий";
            this.comboBoxWithNameCategoryFilters.ToolTipTextVisible = true;
            this.comboBoxWithNameCategoryFilters.SelectedIndexChanged += new System.Action<object, System.EventArgs>(this.comboBoxWithNameCategoryFilters_SelectedIndexChanged);
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.ItemHeight = 17;
            this.listBoxCategories.Location = new System.Drawing.Point(3, 159);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(216, 106);
            this.listBoxCategories.TabIndex = 1;
            this.listBoxCategories.SelectedIndexChanged += new System.EventHandler(this.listBoxCategories_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 78);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Структура категорий";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.radioButtonLine);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonTree);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(210, 55);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // radioButtonLine
            // 
            this.radioButtonLine.AutoSize = true;
            this.radioButtonLine.Checked = true;
            this.radioButtonLine.Location = new System.Drawing.Point(3, 3);
            this.radioButtonLine.Name = "radioButtonLine";
            this.radioButtonLine.Size = new System.Drawing.Size(109, 21);
            this.radioButtonLine.TabIndex = 0;
            this.radioButtonLine.TabStop = true;
            this.radioButtonLine.Text = "Линейная";
            this.radioButtonLine.UseVisualStyleBackColor = true;
            this.radioButtonLine.CheckedChanged += new System.EventHandler(this.radioButtonLine_CheckedChanged);
            // 
            // radioButtonTree
            // 
            this.radioButtonTree.AutoSize = true;
            this.radioButtonTree.Location = new System.Drawing.Point(3, 30);
            this.radioButtonTree.Name = "radioButtonTree";
            this.radioButtonTree.Size = new System.Drawing.Size(139, 21);
            this.radioButtonTree.TabIndex = 1;
            this.radioButtonTree.TabStop = true;
            this.radioButtonTree.Text = "Древовидная";
            this.radioButtonTree.UseVisualStyleBackColor = true;
            this.radioButtonTree.CheckedChanged += new System.EventHandler(this.radioButtonTree_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelCategory, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(231, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(639, 44);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCategory.Location = new System.Drawing.Point(3, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(194, 44);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "label1";
            this.labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(231, 53);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(639, 268);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelCategoryData, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(195, 128);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущая категория";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCategoryData
            // 
            this.labelCategoryData.AutoSize = true;
            this.labelCategoryData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCategoryData.Location = new System.Drawing.Point(3, 27);
            this.labelCategoryData.Name = "labelCategoryData";
            this.labelCategoryData.Size = new System.Drawing.Size(189, 101);
            this.labelCategoryData.TabIndex = 1;
            this.labelCategoryData.Text = "label2";
            this.labelCategoryData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(204, 3);
            this.groupBox2.Name = "groupBox2";
            this.tableLayoutPanel5.SetRowSpan(this.groupBox2, 2);
            this.groupBox2.Size = new System.Drawing.Size(432, 262);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Редактируемая категория";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.comboBoxEditFilters, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.textInputCategoryName, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.labelCategoryEditName, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.menuStrip2, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.menuStrip1, 0, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(426, 239);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // comboBoxEditFilters
            // 
            this.comboBoxEditFilters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.comboBoxEditFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEditFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditFilters.DropDownWith = 202;
            this.comboBoxEditFilters.Location = new System.Drawing.Point(218, 3);
            this.comboBoxEditFilters.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.comboBoxEditFilters.Name = "comboBoxEditFilters";
            this.comboBoxEditFilters.NoReadOnly = true;
            this.comboBoxEditFilters.ReadOnly = false;
            this.comboBoxEditFilters.SelectedIndex = -1;
            this.comboBoxEditFilters.SelectedItem = null;
            this.comboBoxEditFilters.Size = new System.Drawing.Size(203, 80);
            this.comboBoxEditFilters.TabIndex = 1;
            this.comboBoxEditFilters.Title = "Фильтры категорий";
            this.comboBoxEditFilters.ToolTipTextVisible = true;
            this.comboBoxEditFilters.SelectedIndexChanged += new System.Action<object, System.EventArgs>(this.comboBoxEditFilters_SelectedIndexChanged);
            // 
            // textInputCategoryName
            // 
            this.textInputCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputCategoryName.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputCategoryName.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputCategoryName.InputKeyPressToBox = null;
            this.textInputCategoryName.InputText = "";
            this.textInputCategoryName.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputCategoryName.Location = new System.Drawing.Point(4, 3);
            this.textInputCategoryName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputCategoryName.MaxLength = 32767;
            this.textInputCategoryName.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputCategoryName.MultiLine = false;
            this.textInputCategoryName.Name = "textInputCategoryName";
            this.textInputCategoryName.NoReadOnly = true;
            this.textInputCategoryName.PasswordChar = '\0';
            this.textInputCategoryName.ReadOnly = false;
            this.textInputCategoryName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputCategoryName.ShortcutsEnabled = true;
            this.textInputCategoryName.Size = new System.Drawing.Size(205, 80);
            this.textInputCategoryName.TabIndex = 0;
            this.textInputCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputCategoryName.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputCategoryName.Title = "Название";
            this.textInputCategoryName.UseSystemPasswordChar = false;
            this.textInputCategoryName.Value = "";
            this.textInputCategoryName.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputCategoryName_InputText_Changed);
            // 
            // labelCategoryEditName
            // 
            this.labelCategoryEditName.AutoSize = true;
            this.labelCategoryEditName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCategoryEditName.Location = new System.Drawing.Point(3, 86);
            this.labelCategoryEditName.Name = "labelCategoryEditName";
            this.labelCategoryEditName.Size = new System.Drawing.Size(207, 50);
            this.labelCategoryEditName.TabIndex = 2;
            this.labelCategoryEditName.Text = "label2";
            this.labelCategoryEditName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(213, 136);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(213, 28);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonUpdateCategory,
            this.buttonCutToNowCategory});
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // buttonUpdateCategory
            // 
            this.buttonUpdateCategory.Name = "buttonUpdateCategory";
            this.buttonUpdateCategory.Size = new System.Drawing.Size(336, 26);
            this.buttonUpdateCategory.Text = "В той же категории";
            this.buttonUpdateCategory.Click += new System.EventHandler(this.buttonUpdateCategory_Click);
            // 
            // buttonCutToNowCategory
            // 
            this.buttonCutToNowCategory.Name = "buttonCutToNowCategory";
            this.buttonCutToNowCategory.Size = new System.Drawing.Size(336, 26);
            this.buttonCutToNowCategory.Text = "Переместить в текущую категорию";
            this.buttonCutToNowCategory.Click += new System.EventHandler(this.buttonCutToNowCategory_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 136);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(213, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddToRootCategory,
            this.buttonAddToNowCategory});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // buttonAddToRootCategory
            // 
            this.buttonAddToRootCategory.Name = "buttonAddToRootCategory";
            this.buttonAddToRootCategory.Size = new System.Drawing.Size(242, 26);
            this.buttonAddToRootCategory.Text = "В корень категорий";
            this.buttonAddToRootCategory.Click += new System.EventHandler(this.buttonAddToRootCategory_Click);
            // 
            // buttonAddToNowCategory
            // 
            this.buttonAddToNowCategory.Name = "buttonAddToNowCategory";
            this.buttonAddToNowCategory.Size = new System.Drawing.Size(242, 26);
            this.buttonAddToNowCategory.Text = "В текущую категорию";
            this.buttonAddToNowCategory.Click += new System.EventHandler(this.buttonAddToNowCategory_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.buttonCopyEdit, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.buttonDeleteCategory, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 137);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(195, 128);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // buttonCopyEdit
            // 
            this.buttonCopyEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCopyEdit.Location = new System.Drawing.Point(3, 3);
            this.buttonCopyEdit.Name = "buttonCopyEdit";
            this.buttonCopyEdit.Size = new System.Drawing.Size(189, 44);
            this.buttonCopyEdit.TabIndex = 0;
            this.buttonCopyEdit.Text = "Копировать для редактирования";
            this.buttonCopyEdit.UseVisualStyleBackColor = true;
            this.buttonCopyEdit.Click += new System.EventHandler(this.buttonCopyEdit_Click);
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteCategory.Location = new System.Drawing.Point(3, 53);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(189, 44);
            this.buttonDeleteCategory.TabIndex = 1;
            this.buttonDeleteCategory.Text = "Удалить";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // CategoriesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(873, 497);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(538, 544);
            this.Name = "CategoriesEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование категорий";
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
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
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
        private ComboBoxWithName comboBoxWithNameCategoryFilters;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonLine;
        private System.Windows.Forms.RadioButton radioButtonTree;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCategoryData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private TextInput textInputCategoryName;
        private ComboBoxWithName comboBoxEditFilters;
        private System.Windows.Forms.Label labelCategoryEditName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonAddToRootCategory;
        private System.Windows.Forms.ToolStripMenuItem buttonAddToNowCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button buttonCopyEdit;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonUpdateCategory;
        private System.Windows.Forms.ToolStripMenuItem buttonCutToNowCategory;
    }
}

