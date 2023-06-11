
namespace FileManegerJson
{
    partial class NumericText
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
            this.components = new System.ComponentModel.Container();
            FileManegerJson.EditTextByFile editTextByFile1 = new FileManegerJson.EditTextByFile();
            this.groupBoxTitle = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.textBoxInput = new FileManegerJson.KeyBordTextView();
            this.buttonpMines = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.groupBoxTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTitle
            // 
            this.groupBoxTitle.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTitle.Name = "groupBoxTitle";
            this.groupBoxTitle.Size = new System.Drawing.Size(317, 123);
            this.groupBoxTitle.TabIndex = 0;
            this.groupBoxTitle.TabStop = false;
            this.groupBoxTitle.Text = "groupBox1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Controls.Add(this.buttonPlus, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxInput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonpMines, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 102);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonPlus
            // 
            this.buttonPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlus.Location = new System.Drawing.Point(213, 3);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(44, 45);
            this.buttonPlus.TabIndex = 2;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonpPlus_Click);
            // 
            // textBoxInput
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxInput, 2);
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            editTextByFile1.Lines = new string[] {
        ""};
            editTextByFile1.Text = "";
            this.textBoxInput.EditText = editTextByFile1;
            this.textBoxInput.HaveKeyBord = false;
            this.textBoxInput.InputPole = true;
            this.textBoxInput.KeyBordForm = null;
            this.textBoxInput.Location = new System.Drawing.Point(53, 3);
            this.textBoxInput.MarginAll = 3;
            this.textBoxInput.MarginBottom = 3;
            this.textBoxInput.MarginLeft = 3;
            this.textBoxInput.MarginRight = 3;
            this.textBoxInput.MarginTop = 3;
            this.textBoxInput.MultiLine = false;
            this.textBoxInput.Multyline = false;
            this.textBoxInput.MultyLine = false;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.SelectionEnd = 0;
            this.textBoxInput.SelectionsStartBigEnd = false;
            this.textBoxInput.Size = new System.Drawing.Size(154, 22);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TagString = "0";
            this.textBoxInput.TextInPole = "";
            this.textBoxInput.TextMargin = new System.Windows.Forms.Padding(3);
            this.textBoxInput.TextPadding = new System.Windows.Forms.Padding(0);
            this.textBoxInput.TextRegion = null;
            this.textBoxInput.ValueInPole = "";
            this.textBoxInput.ValueInputToPole = true;
            this.textBoxInput.VirtualKeyBord = false;
            this.textBoxInput.GetText += new FileManegerJson.GetControlText(this.textBoxInput_GetText);
            this.textBoxInput.Enter += new System.EventHandler(this.textBoxInput_Enter);
            this.textBoxInput.MouseEnter += new System.EventHandler(this.textBoxInput_Enter);
            this.textBoxInput.MouseLeave += new System.EventHandler(this.textBoxInput_Leave);
            // 
            // buttonpMines
            // 
            this.buttonpMines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonpMines.Location = new System.Drawing.Point(3, 3);
            this.buttonpMines.Name = "buttonpMines";
            this.buttonpMines.Size = new System.Drawing.Size(44, 45);
            this.buttonpMines.TabIndex = 1;
            this.buttonpMines.Text = "-";
            this.buttonpMines.UseVisualStyleBackColor = true;
            this.buttonpMines.Click += new System.EventHandler(this.buttonpMines_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(263, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(45, 45);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // NumericText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTitle);
            this.Name = "NumericText";
            this.Size = new System.Drawing.Size(317, 123);
            this.Load += new System.EventHandler(this.NumericText_Load);
            this.groupBoxTitle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTitle;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private KeyBordTextView textBoxInput;
        private System.Windows.Forms.Button buttonpMines;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonClear;
    }
}
