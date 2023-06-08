
namespace FileManegerJson
{
    partial class FormNoteEdit
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textInputNewValue = new FileManegerJson.TextInputEdit();
            this.buttonTextChange = new System.Windows.Forms.Button();
            this.buttonSetDialog = new System.Windows.Forms.Button();
            this.checkBoxKeyBord = new System.Windows.Forms.CheckBox();
            this.buttonFewWindow = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.54386F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.21691F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.97129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.26794F));
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textInputNewValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonTextChange, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetDialog, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxKeyBord, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonFewWindow, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(848, 446);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOK.Location = new System.Drawing.Point(431, 289);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(10);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(268, 44);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(158, 289);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(10);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(253, 44);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textInputNewValue
            // 
            this.textInputNewValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textInputNewValue.ClearVisible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.textInputNewValue, 2);
            this.textInputNewValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputNewValue.HaveKeyBord = false;
            this.textInputNewValue.InputBackColor = System.Drawing.SystemColors.Window;
            this.textInputNewValue.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputNewValue.InputKeyPressToBox = null;
            this.textInputNewValue.InputText = "";
            this.textInputNewValue.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputNewValue.Location = new System.Drawing.Point(152, 84);
            this.textInputNewValue.Margin = new System.Windows.Forms.Padding(4);
            this.textInputNewValue.MaxLength = 32767;
            this.textInputNewValue.MinimumSize = new System.Drawing.Size(148, 62);
            this.textInputNewValue.MultiLine = false;
            this.textInputNewValue.Name = "textInputNewValue";
            this.textInputNewValue.NoReadOnly = true;
            this.textInputNewValue.PasswordChar = '\0';
            this.textInputNewValue.ReadOnly = false;
            this.textInputNewValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInputNewValue.ShortcutsEnabled = true;
            this.textInputNewValue.Size = new System.Drawing.Size(553, 95);
            this.textInputNewValue.TabIndex = 2;
            this.textInputNewValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textInputNewValue.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textInputNewValue.Title = "Новое значение";
            this.textInputNewValue.UseSystemPasswordChar = false;
            this.textInputNewValue.Value = "";
            this.textInputNewValue.VirtualKeyBord = false;
            // 
            // buttonTextChange
            // 
            this.buttonTextChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTextChange.Location = new System.Drawing.Point(436, 15);
            this.buttonTextChange.Margin = new System.Windows.Forms.Padding(15);
            this.buttonTextChange.Name = "buttonTextChange";
            this.buttonTextChange.Size = new System.Drawing.Size(258, 50);
            this.buttonTextChange.TabIndex = 3;
            this.buttonTextChange.Text = "Загрузить/сохранить/заменить";
            this.buttonTextChange.UseVisualStyleBackColor = true;
            this.buttonTextChange.Click += new System.EventHandler(this.buttonTextChange_Click);
            // 
            // buttonSetDialog
            // 
            this.buttonSetDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetDialog.Location = new System.Drawing.Point(158, 193);
            this.buttonSetDialog.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSetDialog.Name = "buttonSetDialog";
            this.buttonSetDialog.Size = new System.Drawing.Size(253, 76);
            this.buttonSetDialog.TabIndex = 4;
            this.buttonSetDialog.Text = "Задать через диалоговое окно";
            this.buttonSetDialog.UseVisualStyleBackColor = true;
            this.buttonSetDialog.Click += new System.EventHandler(this.buttonSetDialog_Click);
            // 
            // checkBoxKeyBord
            // 
            this.checkBoxKeyBord.AutoSize = true;
            this.checkBoxKeyBord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxKeyBord.Location = new System.Drawing.Point(424, 186);
            this.checkBoxKeyBord.Name = "checkBoxKeyBord";
            this.checkBoxKeyBord.Size = new System.Drawing.Size(282, 90);
            this.checkBoxKeyBord.TabIndex = 5;
            this.checkBoxKeyBord.Text = "Виртуальная клавиатура";
            this.checkBoxKeyBord.UseVisualStyleBackColor = true;
            this.checkBoxKeyBord.CheckedChanged += new System.EventHandler(this.checkBoxKeyBord_CheckedChanged);
            // 
            // buttonFewWindow
            // 
            this.buttonFewWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFewWindow.Location = new System.Drawing.Point(163, 15);
            this.buttonFewWindow.Margin = new System.Windows.Forms.Padding(15);
            this.buttonFewWindow.Name = "buttonFewWindow";
            this.buttonFewWindow.Size = new System.Drawing.Size(243, 50);
            this.buttonFewWindow.TabIndex = 6;
            this.buttonFewWindow.Text = "Отдельным окном";
            this.buttonFewWindow.UseVisualStyleBackColor = true;
            this.buttonFewWindow.Click += new System.EventHandler(this.buttonFewWindow_Click);
            // 
            // FormNoteEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Lucida Console", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormNoteEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование";
            this.Load += new System.EventHandler(this.FormNoteEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private TextInputEdit textInputNewValue;
        private System.Windows.Forms.Button buttonTextChange;
        private System.Windows.Forms.Button buttonSetDialog;
        private System.Windows.Forms.CheckBox checkBoxKeyBord;
        private System.Windows.Forms.Button buttonFewWindow;
    }
}