﻿
namespace FileManegerJson
{
    partial class TextBoxWihSet
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxInput = new FileManegerJson.TextInputEdit();
            this.buttonSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxInput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSet, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.40206F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.59794F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 154);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBoxInput.ClearVisible = true;
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInput.HaveKeyBord = false;
            this.textBoxInput.InputBackColor = System.Drawing.SystemColors.Window;
            this.textBoxInput.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxInput.InputKeyPressToBox = null;
            this.textBoxInput.InputText = "";
            this.textBoxInput.InputTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxInput.Location = new System.Drawing.Point(3, 3);
            this.textBoxInput.MaxLength = 32767;
            this.textBoxInput.MinimumSize = new System.Drawing.Size(100, 50);
            this.textBoxInput.MultiLine = false;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.NoReadOnly = true;
            this.textBoxInput.PasswordChar = '\0';
            this.textBoxInput.ReadOnly = false;
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxInput.ShortcutsEnabled = true;
            this.textBoxInput.Size = new System.Drawing.Size(258, 91);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxInput.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textBoxInput.Title = "groupBox1";
            this.textBoxInput.UseSystemPasswordChar = false;
            this.textBoxInput.Value = "";
            this.textBoxInput.VirtualKeyBord = false;
            this.textBoxInput.InputText_Changed += new System.Action<object, System.EventArgs>(this.TextBoxInput_TextChanged);
            this.textBoxInput.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textBoxInput_ReadOnlyChanged);
            this.textBoxInput.InputKeyPress += new System.Action<object, System.Windows.Forms.KeyPressEventArgs>(this.textBoxInput_KeyPress);
            this.textBoxInput.InputLeave += new System.Action<object, System.EventArgs>(this.textBoxInput_Leave);
            this.textBoxInput.InputEnter += new System.Action<object, System.EventArgs>(this.textBoxInput_Enter);
            this.textBoxInput.InputKeyDown += new System.Action<object, System.Windows.Forms.KeyEventArgs>(this.textBoxInput_KeyDown);
            this.textBoxInput.InputKeyUp += new System.Action<object, System.Windows.Forms.KeyEventArgs>(this.textBoxInput_KeyUp);
            // 
            // buttonSet
            // 
            this.buttonSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet.Location = new System.Drawing.Point(3, 100);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(258, 51);
            this.buttonSet.TabIndex = 1;
            this.buttonSet.Text = "Задать";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // TextBoxWihSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TextBoxWihSet";
            this.Size = new System.Drawing.Size(264, 154);
            this.Load += new System.EventHandler(this.TextBoxWihSet_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TextInputEdit textBoxInput;
        private System.Windows.Forms.Button buttonSet;
    }
}