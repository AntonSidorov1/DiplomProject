
namespace FileManegerJson
{
    partial class CodeForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelImage = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelImage = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxByteCode = new System.Windows.Forms.TextBox();
            this.textBoxHCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.flowLayoutPanelImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelImage, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 506);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.buttonBack, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(53, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(694, 92);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonBack
            // 
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBack.Location = new System.Drawing.Point(23, 23);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(648, 46);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBoxCode
            // 
            this.textBoxCode.BackColor = System.Drawing.Color.White;
            this.textBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCode.Location = new System.Drawing.Point(20, 20);
            this.textBoxCode.Margin = new System.Windows.Forms.Padding(20);
            this.textBoxCode.Multiline = true;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.ReadOnly = true;
            this.textBoxCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCode.Size = new System.Drawing.Size(271, 233);
            this.textBoxCode.TabIndex = 1;
            // 
            // tableLayoutPanelImage
            // 
            this.tableLayoutPanelImage.ColumnCount = 2;
            this.tableLayoutPanelImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelImage.Controls.Add(this.textBoxHCode, 1, 1);
            this.tableLayoutPanelImage.Controls.Add(this.textBoxCode, 0, 0);
            this.tableLayoutPanelImage.Controls.Add(this.pictureBoxImage, 1, 0);
            this.tableLayoutPanelImage.Controls.Add(this.textBoxByteCode, 0, 1);
            this.tableLayoutPanelImage.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelImage.Name = "tableLayoutPanelImage";
            this.tableLayoutPanelImage.RowCount = 2;
            this.tableLayoutPanelImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelImage.Size = new System.Drawing.Size(622, 546);
            this.tableLayoutPanelImage.TabIndex = 2;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(331, 20);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(271, 233);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 2;
            this.pictureBoxImage.TabStop = false;
            // 
            // flowLayoutPanelImage
            // 
            this.flowLayoutPanelImage.AutoScroll = true;
            this.flowLayoutPanelImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelImage.Controls.Add(this.tableLayoutPanelImage);
            this.flowLayoutPanelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImage.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelImage.Location = new System.Drawing.Point(70, 118);
            this.flowLayoutPanelImage.Margin = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanelImage.Name = "flowLayoutPanelImage";
            this.flowLayoutPanelImage.Size = new System.Drawing.Size(660, 318);
            this.flowLayoutPanelImage.TabIndex = 3;
            this.flowLayoutPanelImage.WrapContents = false;
            this.flowLayoutPanelImage.SizeChanged += new System.EventHandler(this.flowLayoutPanelImage_SizeChanged);
            // 
            // textBoxByteCode
            // 
            this.textBoxByteCode.BackColor = System.Drawing.Color.White;
            this.textBoxByteCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxByteCode.Location = new System.Drawing.Point(20, 293);
            this.textBoxByteCode.Margin = new System.Windows.Forms.Padding(20);
            this.textBoxByteCode.Multiline = true;
            this.textBoxByteCode.Name = "textBoxByteCode";
            this.textBoxByteCode.ReadOnly = true;
            this.textBoxByteCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxByteCode.Size = new System.Drawing.Size(271, 233);
            this.textBoxByteCode.TabIndex = 3;
            // 
            // textBoxHCode
            // 
            this.textBoxHCode.BackColor = System.Drawing.Color.White;
            this.textBoxHCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHCode.Location = new System.Drawing.Point(331, 293);
            this.textBoxHCode.Margin = new System.Windows.Forms.Padding(20);
            this.textBoxHCode.Multiline = true;
            this.textBoxHCode.Name = "textBoxHCode";
            this.textBoxHCode.ReadOnly = true;
            this.textBoxHCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHCode.Size = new System.Drawing.Size(271, 233);
            this.textBoxHCode.TabIndex = 4;
            // 
            // CodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "CodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeForm";
            this.Load += new System.EventHandler(this.CodeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanelImage.ResumeLayout(false);
            this.tableLayoutPanelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.flowLayoutPanelImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImage;
        private System.Windows.Forms.TextBox textBoxByteCode;
        private System.Windows.Forms.TextBox textBoxHCode;
    }
}