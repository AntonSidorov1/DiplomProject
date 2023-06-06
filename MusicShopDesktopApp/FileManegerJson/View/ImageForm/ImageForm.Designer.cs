
namespace FileManegerJson
{
    partial class ImageForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Back = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.textBoxProperty = new System.Windows.Forms.TextBox();
            this.textBoxIndexName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuImage = new FileManegerJson.ContextMenuFileClass();
            this.SaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.saveJson = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.contextMenuImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Back, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxImage, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxProperty, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxIndexName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Back
            // 
            this.Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Location = new System.Drawing.Point(103, 3);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(396, 74);
            this.Back.TabIndex = 0;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.White;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.ForeColor = System.Drawing.Color.Black;
            this.textBoxName.Location = new System.Drawing.Point(103, 83);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(396, 30);
            this.textBoxName.TabIndex = 1;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(103, 133);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(396, 264);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 2;
            this.pictureBoxImage.TabStop = false;
            // 
            // textBoxProperty
            // 
            this.textBoxProperty.BackColor = System.Drawing.Color.White;
            this.textBoxProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProperty.Location = new System.Drawing.Point(505, 133);
            this.textBoxProperty.Multiline = true;
            this.textBoxProperty.Name = "textBoxProperty";
            this.textBoxProperty.ReadOnly = true;
            this.textBoxProperty.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProperty.Size = new System.Drawing.Size(396, 264);
            this.textBoxProperty.TabIndex = 3;
            // 
            // textBoxIndexName
            // 
            this.textBoxIndexName.BackColor = System.Drawing.Color.White;
            this.textBoxIndexName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIndexName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIndexName.ForeColor = System.Drawing.Color.Black;
            this.textBoxIndexName.Location = new System.Drawing.Point(505, 83);
            this.textBoxIndexName.Name = "textBoxIndexName";
            this.textBoxIndexName.ReadOnly = true;
            this.textBoxIndexName.Size = new System.Drawing.Size(396, 30);
            this.textBoxIndexName.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSave.Location = new System.Drawing.Point(505, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(396, 74);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // contextMenuImage
            // 
            this.contextMenuImage.File = null;
            this.contextMenuImage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveImage,
            this.saveJson});
            this.contextMenuImage.Name = "contextMenuImage";
            this.contextMenuImage.Size = new System.Drawing.Size(203, 52);
            // 
            // SaveImage
            // 
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(202, 24);
            this.SaveImage.Text = "Как изображение";
            this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // saveJson
            // 
            this.saveJson.Name = "saveJson";
            this.saveJson.Size = new System.Drawing.Size(202, 24);
            this.saveJson.Text = "Как Json";
            this.saveJson.Click += new System.EventHandler(this.какJsonToolStripMenuItem_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изображение";
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.contextMenuImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TextBox textBoxProperty;
        private System.Windows.Forms.TextBox textBoxIndexName;
        private System.Windows.Forms.Button buttonSave;
        private ContextMenuFileClass contextMenuImage;
        private System.Windows.Forms.ToolStripMenuItem SaveImage;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.ToolStripMenuItem saveJson;
    }
}