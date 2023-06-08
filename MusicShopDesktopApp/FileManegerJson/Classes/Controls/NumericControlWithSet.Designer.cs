
namespace FileManegerJson
{
    partial class NumericControlWithSet
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
            this.buttonSet = new System.Windows.Forms.Button();
            this.textBoxInput = new FileManegerJson.NumericControlEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSet, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxInput, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonSet
            // 
            this.buttonSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet.Location = new System.Drawing.Point(10, 110);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(223, 30);
            this.buttonSet.TabIndex = 0;
            this.buttonSet.Text = "Задать";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBoxInput.DecimalPlaces = 0;
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInput.Incriment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxInput.InputBackColor = System.Drawing.SystemColors.Window;
            this.textBoxInput.InputEnebled = true;
            this.textBoxInput.InputForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxInput.InputKeyPressToBox = null;
            this.textBoxInput.InputNoReadOnly = true;
            this.textBoxInput.InputReadOnly = false;
            this.textBoxInput.Location = new System.Drawing.Point(3, 3);
            this.textBoxInput.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textBoxInput.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.NoReadOnly = true;
            this.textBoxInput.ReadOnly = false;
            this.textBoxInput.Size = new System.Drawing.Size(237, 94);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.Title = "groupBox1";
            this.textBoxInput.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxInput.GetValue += new FileManegerJson.NumericControlEdit.GetControl(this.textBoxInput_GetValue);
            // 
            // NumericControlWithSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NumericControlWithSet";
            this.Size = new System.Drawing.Size(243, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSet;
        private NumericControlEdit textBoxInput;
    }
}
