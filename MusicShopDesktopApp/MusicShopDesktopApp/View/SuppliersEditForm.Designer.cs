
namespace MusicShopDesktopApp
{
    partial class SuppliersEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuppliersEditForm));
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
            this.listBoxSuppliers = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.textInputSupplierName = new MusicShopDesktopApp.TextInput();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddSupplier = new System.Windows.Forms.Button();
            this.buttonDeleteSupplier = new System.Windows.Forms.Button();
            this.buttonSupplierCopyEdit = new System.Windows.Forms.Button();
            this.buttonSupplierEdit = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSupplierEditName = new System.Windows.Forms.Label();
            this.buttonEditVieWindow = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(733, 94);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 86);
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
            this.labelTitle.Size = new System.Drawing.Size(455, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Редактирование поставщиков";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(572, 15);
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
            this.panelVault.Size = new System.Drawing.Size(733, 79);
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
            this.statusStrip1.Size = new System.Drawing.Size(729, 23);
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
            this.tableLayoutPanel2.Controls.Add(this.listBoxSuppliers, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(733, 324);
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
            // listBoxSuppliers
            // 
            this.listBoxSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSuppliers.FormattingEnabled = true;
            this.listBoxSuppliers.ItemHeight = 17;
            this.listBoxSuppliers.Location = new System.Drawing.Point(3, 53);
            this.listBoxSuppliers.Name = "listBoxSuppliers";
            this.listBoxSuppliers.Size = new System.Drawing.Size(183, 268);
            this.listBoxSuppliers.TabIndex = 1;
            this.listBoxSuppliers.SelectedIndexChanged += new System.EventHandler(this.listBoxSuppliers_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.labelSupplier, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textInputSupplierName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(192, 53);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(538, 268);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSupplier.Location = new System.Drawing.Point(3, 0);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(263, 101);
            this.labelSupplier.TabIndex = 0;
            this.labelSupplier.Text = "label1";
            this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textInputSupplierName
            // 
            this.textInputSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputSupplierName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputSupplierName.GetTextProperty = null;
            this.textInputSupplierName.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputSupplierName.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputSupplierName.InputKeyPressToBox = null;
            this.textInputSupplierName.InputText = "";
            this.textInputSupplierName.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputSupplierName.Location = new System.Drawing.Point(273, 3);
            this.textInputSupplierName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputSupplierName.MaxLength = 32767;
            this.textInputSupplierName.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputSupplierName.MultiLine = false;
            this.textInputSupplierName.Name = "textInputSupplierName";
            this.textInputSupplierName.NoReadOnly = true;
            this.textInputSupplierName.PasswordChar = '\0';
            this.textInputSupplierName.ReadOnly = false;
            this.textInputSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputSupplierName.ShortcutsEnabled = true;
            this.textInputSupplierName.Size = new System.Drawing.Size(261, 95);
            this.textInputSupplierName.TabIndex = 1;
            this.textInputSupplierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputSupplierName.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputSupplierName.Title = "Новое имя поставщика";
            this.textInputSupplierName.UseSystemPasswordChar = false;
            this.textInputSupplierName.Value = "";
            this.textInputSupplierName.InputText_Changed += new System.Action<object, System.EventArgs>(this.textInputSupplierName_InputText_Changed);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.buttonAddSupplier, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonDeleteSupplier, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.buttonSupplierCopyEdit, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonSupplierEdit, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.buttonEditVieWindow, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 104);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(532, 161);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // buttonAddSupplier
            // 
            this.buttonAddSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddSupplier.Location = new System.Drawing.Point(269, 3);
            this.buttonAddSupplier.Name = "buttonAddSupplier";
            this.buttonAddSupplier.Size = new System.Drawing.Size(260, 44);
            this.buttonAddSupplier.TabIndex = 0;
            this.buttonAddSupplier.Text = "Добавить поставщика";
            this.buttonAddSupplier.UseVisualStyleBackColor = true;
            this.buttonAddSupplier.Click += new System.EventHandler(this.buttonAddSupplier_Click);
            // 
            // buttonDeleteSupplier
            // 
            this.buttonDeleteSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteSupplier.Location = new System.Drawing.Point(3, 53);
            this.buttonDeleteSupplier.Name = "buttonDeleteSupplier";
            this.buttonDeleteSupplier.Size = new System.Drawing.Size(260, 44);
            this.buttonDeleteSupplier.TabIndex = 1;
            this.buttonDeleteSupplier.Text = "Удалить текущего поставщика";
            this.buttonDeleteSupplier.UseVisualStyleBackColor = true;
            this.buttonDeleteSupplier.Click += new System.EventHandler(this.buttonDeleteSupplier_Click);
            // 
            // buttonSupplierCopyEdit
            // 
            this.buttonSupplierCopyEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSupplierCopyEdit.Location = new System.Drawing.Point(3, 3);
            this.buttonSupplierCopyEdit.Name = "buttonSupplierCopyEdit";
            this.buttonSupplierCopyEdit.Size = new System.Drawing.Size(260, 44);
            this.buttonSupplierCopyEdit.TabIndex = 2;
            this.buttonSupplierCopyEdit.Text = "Копировать для редактирования";
            this.buttonSupplierCopyEdit.UseVisualStyleBackColor = true;
            this.buttonSupplierCopyEdit.Click += new System.EventHandler(this.buttonSupplierCopyEdit_Click);
            // 
            // buttonSupplierEdit
            // 
            this.buttonSupplierEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSupplierEdit.Location = new System.Drawing.Point(269, 53);
            this.buttonSupplierEdit.Name = "buttonSupplierEdit";
            this.buttonSupplierEdit.Size = new System.Drawing.Size(260, 44);
            this.buttonSupplierEdit.TabIndex = 3;
            this.buttonSupplierEdit.Text = "Изменить поставщика";
            this.buttonSupplierEdit.UseVisualStyleBackColor = true;
            this.buttonSupplierEdit.Click += new System.EventHandler(this.buttonSupplierEdit_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.labelSupplierEditName, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(192, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(538, 44);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // labelSupplierEditName
            // 
            this.labelSupplierEditName.AutoSize = true;
            this.labelSupplierEditName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSupplierEditName.Location = new System.Drawing.Point(272, 0);
            this.labelSupplierEditName.Name = "labelSupplierEditName";
            this.labelSupplierEditName.Size = new System.Drawing.Size(263, 44);
            this.labelSupplierEditName.TabIndex = 0;
            this.labelSupplierEditName.Text = "label1";
            this.labelSupplierEditName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonEditVieWindow
            // 
            this.buttonEditVieWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditVieWindow.Location = new System.Drawing.Point(269, 103);
            this.buttonEditVieWindow.Name = "buttonEditVieWindow";
            this.buttonEditVieWindow.Size = new System.Drawing.Size(260, 55);
            this.buttonEditVieWindow.TabIndex = 4;
            this.buttonEditVieWindow.Text = "Редактировать отдельным окном";
            this.buttonEditVieWindow.UseVisualStyleBackColor = true;
            this.buttonEditVieWindow.Click += new System.EventHandler(this.buttonEditVieWindow_Click);
            // 
            // SuppliersEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 497);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(538, 544);
            this.Name = "SuppliersEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование поставщиков";
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
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
        private System.Windows.Forms.ListBox listBoxSuppliers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelSupplier;
        private TextInput textInputSupplierName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonAddSupplier;
        private System.Windows.Forms.Button buttonDeleteSupplier;
        private System.Windows.Forms.Button buttonSupplierCopyEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelSupplierEditName;
        private System.Windows.Forms.Button buttonSupplierEdit;
        private System.Windows.Forms.Button buttonEditVieWindow;
    }
}

