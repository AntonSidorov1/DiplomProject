
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
            this.tableLayoutPanelEdit = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxInput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelEdit, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.textBoxInput.Size = new System.Drawing.Size(258, 98);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxInput.TextScrollBar = System.Windows.Forms.ScrollBars.None;
            this.textBoxInput.Title = "groupBox1";
            this.textBoxInput.UseSystemPasswordChar = false;
            this.textBoxInput.Value = "";
            this.textBoxInput.VirtualKeyBord = false;
            this.textBoxInput.UpdateText += new FileManegerJson.UpdateTextControl(this.textBoxInput_UpdateText);
            this.textBoxInput.InputText_Changed += new System.Action<object, System.EventArgs>(this.TextBoxInput_TextChanged);
            this.textBoxInput.ReadOnlyChanged += new System.Action<object, System.EventArgs>(this.textBoxInput_ReadOnlyChanged);
            this.textBoxInput.InputKeyPress += new System.Action<object, System.Windows.Forms.KeyPressEventArgs>(this.textBoxInput_KeyPress);
            this.textBoxInput.InputLeave += new System.Action<object, System.EventArgs>(this.textBoxInput_Leave);
            this.textBoxInput.InputEnter += new System.Action<object, System.EventArgs>(this.textBoxInput_Enter);
            this.textBoxInput.InputKeyDown += new System.Action<object, System.Windows.Forms.KeyEventArgs>(this.textBoxInput_KeyDown);
            this.textBoxInput.InputKeyUp += new System.Action<object, System.Windows.Forms.KeyEventArgs>(this.textBoxInput_KeyUp);
            // 
            // tableLayoutPanelEdit
            // 
            this.tableLayoutPanelEdit.ColumnCount = 2;
            this.tableLayoutPanelEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelEdit.Controls.Add(this.buttonSet, 0, 0);
            this.tableLayoutPanelEdit.Controls.Add(this.buttonShow, 1, 0);
            this.tableLayoutPanelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEdit.Location = new System.Drawing.Point(3, 107);
            this.tableLayoutPanelEdit.Name = "tableLayoutPanelEdit";
            this.tableLayoutPanelEdit.RowCount = 1;
            this.tableLayoutPanelEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelEdit.Size = new System.Drawing.Size(258, 44);
            this.tableLayoutPanelEdit.TabIndex = 2;
            // 
            // buttonSet
            // 
            this.buttonSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet.Location = new System.Drawing.Point(10, 10);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(109, 24);
            this.buttonSet.TabIndex = 1;
            this.buttonSet.Text = "Задать";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.VisibleChanged += new System.EventHandler(this.buttonSet_VisibleChanged);
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShow.Location = new System.Drawing.Point(139, 10);
            this.buttonShow.Margin = new System.Windows.Forms.Padding(10);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(109, 24);
            this.buttonShow.TabIndex = 2;
            this.buttonShow.Text = "Просмотреть";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
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
            this.tableLayoutPanelEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TextInputEdit textBoxInput;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEdit;
        private System.Windows.Forms.Button buttonShow;
    }
}
