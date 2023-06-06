
namespace FileManegerJson
{
    partial class SityEditForm
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
            this.buttonSetDialog = new System.Windows.Forms.Button();
            this.checkBoxKeyBord = new System.Windows.Forms.CheckBox();
            this.label = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSity = new System.Windows.Forms.Button();
            this.textInputNewValue = new FileManegerJson.TextInputEdit();
            this.buttonTexInput = new System.Windows.Forms.Button();
            this.buttonCamcel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLogotip = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSetDialog, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxKeyBord, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonBack, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSity, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textInputNewValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonTexInput, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonCamcel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 478);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonSetDialog
            // 
            this.buttonSetDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetDialog.Location = new System.Drawing.Point(186, 224);
            this.buttonSetDialog.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSetDialog.Name = "buttonSetDialog";
            this.buttonSetDialog.Size = new System.Drawing.Size(156, 80);
            this.buttonSetDialog.TabIndex = 6;
            this.buttonSetDialog.Text = "Задать через диалоговое окно";
            this.buttonSetDialog.UseVisualStyleBackColor = true;
            this.buttonSetDialog.Click += new System.EventHandler(this.buttonSetDialog_Click);
            // 
            // checkBoxKeyBord
            // 
            this.checkBoxKeyBord.AutoSize = true;
            this.checkBoxKeyBord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxKeyBord.Location = new System.Drawing.Point(355, 217);
            this.checkBoxKeyBord.Name = "checkBoxKeyBord";
            this.checkBoxKeyBord.Size = new System.Drawing.Size(170, 94);
            this.checkBoxKeyBord.TabIndex = 7;
            this.checkBoxKeyBord.Text = "Виртуальная клавиатура";
            this.checkBoxKeyBord.UseVisualStyleBackColor = true;
            this.checkBoxKeyBord.CheckedChanged += new System.EventHandler(this.checkBoxKeyBord_CheckedChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label, 3);
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(179, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(522, 50);
            this.label.TabIndex = 0;
            this.label.Text = "Город";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBack
            // 
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBack.Location = new System.Drawing.Point(707, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(174, 44);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSity
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonSity, 3);
            this.buttonSity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSity.Location = new System.Drawing.Point(179, 53);
            this.buttonSity.Name = "buttonSity";
            this.buttonSity.Size = new System.Drawing.Size(522, 44);
            this.buttonSity.TabIndex = 2;
            this.buttonSity.Text = "задать/Установить/Сохранить";
            this.buttonSity.UseVisualStyleBackColor = true;
            this.buttonSity.Click += new System.EventHandler(this.buttonSity_Click);
            // 
            // textInputNewValue
            // 
            this.textInputNewValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputNewValue.ClearVisible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.textInputNewValue, 3);
            this.textInputNewValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputNewValue.HaveKeyBord = false;
            this.textInputNewValue.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputNewValue.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputNewValue.InputKeyPressToBox = null;
            this.textInputNewValue.InputText = "";
            this.textInputNewValue.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputNewValue.Location = new System.Drawing.Point(180, 103);
            this.textInputNewValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textInputNewValue.MaxLength = 32767;
            this.textInputNewValue.MinimumSize = new System.Drawing.Size(124, 53);
            this.textInputNewValue.MultiLine = false;
            this.textInputNewValue.Name = "textInputNewValue";
            this.textInputNewValue.NoReadOnly = true;
            this.textInputNewValue.PasswordChar = '\0';
            this.textInputNewValue.ReadOnly = false;
            this.textInputNewValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputNewValue.ShortcutsEnabled = true;
            this.textInputNewValue.Size = new System.Drawing.Size(520, 108);
            this.textInputNewValue.TabIndex = 3;
            this.textInputNewValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputNewValue.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputNewValue.Title = "Название города";
            this.textInputNewValue.UseSystemPasswordChar = false;
            this.textInputNewValue.Value = "";
            this.textInputNewValue.VirtualKeyBord = false;
            // 
            // buttonTexInput
            // 
            this.buttonTexInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTexInput.Location = new System.Drawing.Point(538, 224);
            this.buttonTexInput.Margin = new System.Windows.Forms.Padding(10);
            this.buttonTexInput.Name = "buttonTexInput";
            this.buttonTexInput.Size = new System.Drawing.Size(156, 80);
            this.buttonTexInput.TabIndex = 8;
            this.buttonTexInput.Text = "Задать";
            this.buttonTexInput.UseVisualStyleBackColor = true;
            this.buttonTexInput.Click += new System.EventHandler(this.buttonTexInput_Click);
            // 
            // buttonCamcel
            // 
            this.buttonCamcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCamcel.Location = new System.Drawing.Point(186, 324);
            this.buttonCamcel.Margin = new System.Windows.Forms.Padding(10);
            this.buttonCamcel.Name = "buttonCamcel";
            this.buttonCamcel.Size = new System.Drawing.Size(156, 30);
            this.buttonCamcel.TabIndex = 9;
            this.buttonCamcel.Text = "Отмена";
            this.buttonCamcel.UseVisualStyleBackColor = true;
            this.buttonCamcel.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOK.Location = new System.Drawing.Point(538, 324);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(10);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(156, 30);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxLogotip, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(170, 44);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // pictureBoxLogotip
            // 
            this.pictureBoxLogotip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogotip.Image = global::FileManegerJson.Properties.Resources.Sity;
            this.pictureBoxLogotip.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogotip.Name = "pictureBoxLogotip";
            this.pictureBoxLogotip.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxLogotip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogotip.TabIndex = 0;
            this.pictureBoxLogotip.TabStop = false;
            // 
            // SityEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 478);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SityEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировани города";
            this.Load += new System.EventHandler(this.SityEditForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogotip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSity;
        private TextInputEdit textInputNewValue;
        private System.Windows.Forms.Button buttonSetDialog;
        private System.Windows.Forms.CheckBox checkBoxKeyBord;
        private System.Windows.Forms.Button buttonTexInput;
        private System.Windows.Forms.Button buttonCamcel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBoxLogotip;
    }
}