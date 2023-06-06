
namespace FileManegerJson
{
    partial class LangugeEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LanguageTable = new System.Windows.Forms.DataGridView();
            this.MinesRows = new System.Windows.Forms.Button();
            this.PlusRows = new System.Windows.Forms.Button();
            this.PlusColumn = new System.Windows.Forms.Button();
            this.MinesColumn = new System.Windows.Forms.Button();
            this.LanguageName = new System.Windows.Forms.TextBox();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Back = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageTable)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LanguageTable
            // 
            this.LanguageTable.AllowUserToAddRows = false;
            this.LanguageTable.AllowUserToDeleteRows = false;
            this.LanguageTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LanguageTable.ColumnHeadersVisible = false;
            this.LanguageTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LanguageTable.Location = new System.Drawing.Point(37, 33);
            this.LanguageTable.Name = "LanguageTable";
            this.LanguageTable.RowHeadersVisible = false;
            this.LanguageTable.RowHeadersWidth = 51;
            this.LanguageTable.RowTemplate.Height = 24;
            this.LanguageTable.Size = new System.Drawing.Size(370, 278);
            this.LanguageTable.TabIndex = 0;
            // 
            // MinesRows
            // 
            this.MinesRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinesRows.Location = new System.Drawing.Point(37, 3);
            this.MinesRows.Name = "MinesRows";
            this.MinesRows.Size = new System.Drawing.Size(370, 24);
            this.MinesRows.TabIndex = 1;
            this.MinesRows.Text = "-";
            this.MinesRows.UseVisualStyleBackColor = true;
            this.MinesRows.Click += new System.EventHandler(this.MinesRows_Click);
            // 
            // PlusRows
            // 
            this.PlusRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlusRows.Location = new System.Drawing.Point(37, 317);
            this.PlusRows.Name = "PlusRows";
            this.PlusRows.Size = new System.Drawing.Size(370, 24);
            this.PlusRows.TabIndex = 2;
            this.PlusRows.Text = "+";
            this.PlusRows.UseVisualStyleBackColor = true;
            this.PlusRows.Click += new System.EventHandler(this.PlusRows_Click);
            // 
            // PlusColumn
            // 
            this.PlusColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlusColumn.Location = new System.Drawing.Point(413, 33);
            this.PlusColumn.Name = "PlusColumn";
            this.PlusColumn.Size = new System.Drawing.Size(28, 278);
            this.PlusColumn.TabIndex = 3;
            this.PlusColumn.Text = "+";
            this.PlusColumn.UseVisualStyleBackColor = true;
            this.PlusColumn.Click += new System.EventHandler(this.PlusColumn_Click);
            // 
            // MinesColumn
            // 
            this.MinesColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinesColumn.Location = new System.Drawing.Point(3, 33);
            this.MinesColumn.Name = "MinesColumn";
            this.MinesColumn.Size = new System.Drawing.Size(28, 278);
            this.MinesColumn.TabIndex = 4;
            this.MinesColumn.Text = "-";
            this.MinesColumn.UseVisualStyleBackColor = true;
            this.MinesColumn.Click += new System.EventHandler(this.MinesColumn_Click);
            // 
            // LanguageName
            // 
            this.LanguageName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LanguageName.Location = new System.Drawing.Point(3, 175);
            this.LanguageName.Name = "LanguageName";
            this.LanguageName.Size = new System.Drawing.Size(438, 22);
            this.LanguageName.TabIndex = 5;
            // 
            // SaveFile
            // 
            this.SaveFile.Filter = "Lang-files (*.lang)|*.lang| Json-files (*.json)|*.json|TXT-Files (*.txt)|*.txt|CS" +
    "V-Files (*.csv)|*.csv|STXT-Files (*.stxt)|*.stxt|All Files (*.*)|*.*";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonSave.Location = new System.Drawing.Point(3, 3);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(444, 44);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Filter = "Lang-files (*.lang)|*.lang| Json-files (*.json)|*.json|TXT-Files (*.txt)|*.txt|CS" +
    "V-Files (*.csv)|*.csv|STXT-Files (*.stxt)|*.stxt|All Files (*.*)|*.*";
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOpen.Location = new System.Drawing.Point(3, 53);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(444, 44);
            this.ButtonOpen.TabIndex = 7;
            this.ButtonOpen.Text = "Открыть";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Controls.Add(this.LanguageTable, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.MinesRows, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlusColumn, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.MinesColumn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PlusRows, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 344);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Controls.Add(this.LanguageName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(453, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(444, 344);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 172);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.ButtonSave, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ButtonOpen, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Back, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.OK, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(900, 450);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // Back
            // 
            this.Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back.Location = new System.Drawing.Point(453, 3);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(444, 44);
            this.Back.TabIndex = 10;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // OK
            // 
            this.OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK.Location = new System.Drawing.Point(453, 53);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(444, 44);
            this.OK.TabIndex = 11;
            this.OK.Text = "ОК";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Visible = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // LangugeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "LangugeForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LanguageTable)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LanguageTable;
        private System.Windows.Forms.Button MinesRows;
        private System.Windows.Forms.Button PlusRows;
        private System.Windows.Forms.Button PlusColumn;
        private System.Windows.Forms.Button MinesColumn;
        private System.Windows.Forms.TextBox LanguageName;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button OK;
    }
}

