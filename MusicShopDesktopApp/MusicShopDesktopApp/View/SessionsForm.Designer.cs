﻿
namespace MusicShopDesktopApp
{
    partial class SessionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.flowLayoutPanelSessions = new System.Windows.Forms.DataGridView();
            this.ColumnSession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCloseSession = new System.Windows.Forms.Button();
            this.textBoxSession = new System.Windows.Forms.TextBox();
            this.buttonCloseAll = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.panelVault.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowLayoutPanelSessions)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(988, 94);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 86);
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
            this.labelTitle.Size = new System.Drawing.Size(710, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "История входов";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(827, 15);
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
            this.panelVault.Size = new System.Drawing.Size(988, 79);
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
            this.statusStrip1.Size = new System.Drawing.Size(984, 23);
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
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.22335F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.77665F));
            this.tableLayoutPanel2.Controls.Add(this.buttonUpdate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanelSessions, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonCloseAll, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(988, 324);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpdate.Location = new System.Drawing.Point(15, 15);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(15);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(120, 31);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // flowLayoutPanelSessions
            // 
            this.flowLayoutPanelSessions.AllowUserToAddRows = false;
            this.flowLayoutPanelSessions.AllowUserToDeleteRows = false;
            this.flowLayoutPanelSessions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.flowLayoutPanelSessions.BackgroundColor = System.Drawing.Color.White;
            this.flowLayoutPanelSessions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flowLayoutPanelSessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSession});
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanelSessions, 3);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flowLayoutPanelSessions.DefaultCellStyle = dataGridViewCellStyle3;
            this.flowLayoutPanelSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSessions.Location = new System.Drawing.Point(3, 64);
            this.flowLayoutPanelSessions.Name = "flowLayoutPanelSessions";
            this.flowLayoutPanelSessions.RowHeadersVisible = false;
            this.flowLayoutPanelSessions.RowHeadersWidth = 51;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flowLayoutPanelSessions.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.flowLayoutPanelSessions.RowTemplate.Height = 24;
            this.flowLayoutPanelSessions.Size = new System.Drawing.Size(676, 257);
            this.flowLayoutPanelSessions.TabIndex = 1;
            this.flowLayoutPanelSessions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flowLayoutPanelSessions_CellContentClick);
            // 
            // ColumnSession
            // 
            this.ColumnSession.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSession.HeaderText = "Сессии";
            this.ColumnSession.MinimumWidth = 6;
            this.ColumnSession.Name = "ColumnSession";
            this.ColumnSession.ReadOnly = true;
            this.ColumnSession.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.buttonCloseSession, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxSession, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(685, 64);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(300, 257);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonCloseSession
            // 
            this.buttonCloseSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCloseSession.Enabled = false;
            this.buttonCloseSession.Location = new System.Drawing.Point(15, 218);
            this.buttonCloseSession.Margin = new System.Windows.Forms.Padding(15);
            this.buttonCloseSession.Name = "buttonCloseSession";
            this.buttonCloseSession.Size = new System.Drawing.Size(270, 24);
            this.buttonCloseSession.TabIndex = 0;
            this.buttonCloseSession.Text = "Закрыть сессию";
            this.buttonCloseSession.UseVisualStyleBackColor = true;
            this.buttonCloseSession.Click += new System.EventHandler(this.buttonCloseSession_Click);
            // 
            // textBoxSession
            // 
            this.textBoxSession.BackColor = System.Drawing.Color.White;
            this.textBoxSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSession.Location = new System.Drawing.Point(3, 3);
            this.textBoxSession.Multiline = true;
            this.textBoxSession.Name = "textBoxSession";
            this.textBoxSession.ReadOnly = true;
            this.textBoxSession.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSession.Size = new System.Drawing.Size(294, 197);
            this.textBoxSession.TabIndex = 1;
            this.textBoxSession.TextChanged += new System.EventHandler(this.textBoxSession_TextChanged);
            // 
            // buttonCloseAll
            // 
            this.buttonCloseAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCloseAll.Location = new System.Drawing.Point(165, 15);
            this.buttonCloseAll.Margin = new System.Windows.Forms.Padding(15);
            this.buttonCloseAll.Name = "buttonCloseAll";
            this.buttonCloseAll.Size = new System.Drawing.Size(217, 31);
            this.buttonCloseAll.TabIndex = 3;
            this.buttonCloseAll.Text = "Закрыть все сессии";
            this.buttonCloseAll.UseVisualStyleBackColor = true;
            this.buttonCloseAll.Click += new System.EventHandler(this.buttonCloseAll_Click);
            // 
            // SessionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 497);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelVault);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(538, 544);
            this.Name = "SessionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История входов";
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
            ((System.ComponentModel.ISupportInitialize)(this.flowLayoutPanelSessions)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
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
        private System.Windows.Forms.DataGridView flowLayoutPanelSessions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSession;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonCloseSession;
        private System.Windows.Forms.TextBox textBoxSession;
        private System.Windows.Forms.Button buttonCloseAll;
    }
}

